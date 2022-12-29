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
    }
}
