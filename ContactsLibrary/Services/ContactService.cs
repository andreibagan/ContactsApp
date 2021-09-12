using ContactsLibrary.DataAccess;
using ContactsLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactsLibrary.Services
{
    public class ContactService : IContactService
    {
        private readonly IDataAccess _dataAccess;
        private const string _connectionStringName = "SQLiteDb";

        public ContactService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void CreateContact(ContactModel contactModel)
        {
            string sql = @"insert into Contacts (Name, MobilePhone, JobTitle, BirthDate) values
                            (@Name, @MobilePhone, @JobTitle, @BirthDate)";

            _dataAccess.SaveData(sql, new { contactModel.Name, contactModel.MobilePhone, contactModel.JobTitle, contactModel.BirthDate }, _connectionStringName);
        }

        public List<ContactModel> GetAllContacts()
        {
            string sql = "select Id, Name, MobilePhone, JobTitle, BirthDate from Contacts";

            return _dataAccess.LoadData<ContactModel, dynamic>(sql, new { }, _connectionStringName);
        }

        public ContactModel GetContact(int id)
        {
            string sql = @"select Id, Name, MobilePhone, JobTitle, BirthDate
                           from Contacts
                           where Id = @Id";

            return _dataAccess.LoadData<ContactModel, dynamic>(sql, new { Id = id }, _connectionStringName).FirstOrDefault();
        }

        public void UpdateContact(ContactModel contactModel)
        {
            string sql = @"update Contacts
                           set Name = @Name, MobilePhone = @MobilePhone, JobTitle = @JobTitle, BirthDate = @BirthDate
                           where Id = @Id";

            _dataAccess.SaveData(sql, new { contactModel.Id, contactModel.Name, contactModel.MobilePhone, contactModel.JobTitle, contactModel.BirthDate }, _connectionStringName);
        }

        public void DeleteContact(int id)
        {
            string sql = @"delete from Contacts
                           where Id = @Id";

            _dataAccess.SaveData(sql, new { Id = id }, _connectionStringName);
        }
    }
}
