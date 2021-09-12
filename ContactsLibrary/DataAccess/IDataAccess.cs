using System.Collections.Generic;

namespace ContactsLibrary.DataAccess
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString, bool isStoredProcedure = false);
        void SaveData<T>(string sqlStatement, T parameters, string connectionString, bool isStoredProcedure = false);
    }
}