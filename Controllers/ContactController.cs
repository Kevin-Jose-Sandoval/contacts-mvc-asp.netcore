using Microsoft.AspNetCore.Mvc;

using ContactsApi.Data;
using ContactsApi.Models;

namespace ContactsApi.Controllers
{
    public class ContactController : Controller
    {
        ContactData _ContactData = new ContactData();

        public IActionResult List()
        {
            // return a contact list
            var actualList = _ContactData.List();
            return View(actualList);
        }

        public IActionResult Add()
        {
            // return only a view
            return View();
        }

        [HttpPost]
        public IActionResult Add(ContactModel newContact)
        {
            // receive an object save it to the database
            if(!ModelState.IsValid)
                return View();

            var response = _ContactData.AddContact(newContact);
            
            if(response)
                return RedirectToAction("List");
            else
                return View();
        }

        public IActionResult Update(int contactId)
        {
            // return only a view
            var contact = _ContactData.GetContact(contactId);

            return View(contact);
        }

        [HttpPost]
        public IActionResult Update(ContactModel newContact)
        {
            if (!ModelState.IsValid)
                return View();

            var response = _ContactData.UpdateContact(newContact);

            if (response)
                return RedirectToAction("List");
            else
                return View();
        }

        public IActionResult Delete(int contactId)
        {
            // return only a view
            var contact = _ContactData.GetContact(contactId);

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(ContactModel newContact)
        {
            var response = _ContactData.DeleteContact(newContact.ContactId);

            if (response)
                return RedirectToAction("List");
            else
                return View();
        }
    }
}
