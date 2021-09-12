using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace ContactsLibrary.DataAccess
{
    public class SQLiteDataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public SQLiteDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            CommandType commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            CommandType commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters, commandType: commandType);
            }
        }
    }
}
