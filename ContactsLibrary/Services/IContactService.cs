using ContactsLibrary.Models;
using System.Collections.Generic;

namespace ContactsLibrary.Services
{
    public interface IContactService
    {
        void CreateContact(ContactModel contactModel);
        void DeleteContact(int id);
        List<ContactModel> GetAllContacts();
        ContactModel GetContact(int id);
        void UpdateContact(ContactModel contactModel);
    }
}