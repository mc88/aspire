using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WPFAspire.BusinessInterfaces;
using WPFAspire.BusinessInterfaces.Models;

namespace WPFAspire.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPost]
        [Route("AddContact")]
        public void AddContact([FromBody] AddContactModel contact)
        {
            if (ModelState.IsValid)
            {
                contactService.AddContact(contact);
            }
        }

        [HttpPost]
        public void EditContact(EditContactModel contact)
        {
            if (ModelState.IsValid)
            {
                contactService.EditContact(contact);
            }
        }

        [HttpGet]
        [Route("GetContact/{id}")]
        public ContactViewModel GetContact(int id)
        {
            ContactViewModel contact = contactService.GetContact(id);
            return contact;
        }

        [HttpPost]
        public IList<ContactViewModel> SearchContacts(SearchContactModel searchModel)
        {
            IList<ContactViewModel> contacts = contactService.SearchContacts(searchModel);

            return contacts;
        }
    }
}