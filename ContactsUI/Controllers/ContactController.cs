using ContactsLibrary.Services;
using ContactsUI.Attributes;
using ContactsUI.Converter;
using ContactsUI.Helpers;
using ContactsUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactsUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {
            List<ContactViewModel> contactViewModels = new List<ContactViewModel>();
            var contactModels = _contactService.GetAllContacts();
            contactModels.ForEach(c => contactViewModels.Add(Mapper.ConvertContactModelToContactViewModel(c)));
            return View(contactViewModels);
        }

        [NoDirectAccess]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                _contactService.CreateContact(Mapper.ConvertContactViewModelToContactModel(contactViewModel));

                List<ContactViewModel> contactViewModels = new List<ContactViewModel>();
                var contactModels = _contactService.GetAllContacts();
                contactModels.ForEach(c => contactViewModels.Add(Mapper.ConvertContactModelToContactViewModel(c)));

                return Json(new { isValid = true, html = RazorHelper.RenderRazorViewToString(this, "_ViewAll", contactViewModels) });
            }

            return Json(new { isValid = false, html = RazorHelper.RenderRazorViewToString(this, "Create", contactViewModel) });
        }

        [NoDirectAccess]
        public ActionResult Edit(int id)
        {
            var contactModel = _contactService.GetContact(id);
            var contactViewModel = Mapper.ConvertContactModelToContactViewModel(contactModel);
            return View(contactViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var contactModel = Mapper.ConvertContactViewModelToContactModel(contactViewModel);
                _contactService.UpdateContact(contactModel);

                List<ContactViewModel> contactViewModels = new List<ContactViewModel>();
                var contactModels = _contactService.GetAllContacts();
                contactModels.ForEach(c => contactViewModels.Add(Mapper.ConvertContactModelToContactViewModel(c)));

                return Json(new { isValid = true, html = RazorHelper.RenderRazorViewToString(this, "_ViewAll", contactViewModels) });
            }

            return Json(new { isValid = false, html = RazorHelper.RenderRazorViewToString(this, "Edit", contactViewModel) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _contactService.DeleteContact(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
