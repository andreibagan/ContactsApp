using ContactsLibrary.Models;
using ContactsUI.ViewModels;
using System;

namespace ContactsUI.Converter
{
    public static class Mapper
    {
        public static ContactModel ConvertContactViewModelToContactModel(ContactViewModel contactViewModel)
        {
            return new ContactModel
            {
                Id = contactViewModel.Id,
                Name = contactViewModel.Name,
                MobilePhone = contactViewModel.MobilePhone,
                JobTitle = contactViewModel.JobTitle,
                BirthDate = contactViewModel.BirthDate.ToShortDateString()
            };
        }

        public static ContactViewModel ConvertContactModelToContactViewModel(ContactModel contactModel)
        {
            return new ContactViewModel
            {
                Id = contactModel.Id,
                Name = contactModel.Name,
                MobilePhone = contactModel.MobilePhone,
                JobTitle = contactModel.JobTitle,
                BirthDate = DateTime.Parse(contactModel.BirthDate)
            };
        }
    }
}
