using System.Linq;
using System.Collections.Generic;
using WPFAspire.BusinessInterfaces;
using WPFAspire.BusinessInterfaces.Models;
using WPFAspire.Database;
using WPFAspire.Database.Entities;

namespace WPFAspire.BusinessLogic.Services
{
    public class ContactServicecs : IContactService
    {
        private readonly AspireDbContext context;

        public ContactServicecs(AspireDbContext context)
        {
            this.context = context;
        }

        public void AddContact(AddContactModel model)
        {
            var emails = model.EmailAddresses.Select(x => new Email()
            {
                Adreess = x.Address,
            }).ToList();

            var phones = model.PhoneNumbers.Select(x => new Phone()
            {
                Number = x.Number,
            }).ToList();

            var contact = new Contact()
            {
                FirstName = model.FisrtName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Phones = phones,
                Emails = emails
            };

            context.Contacts.Add(contact);
            context.SaveChanges();
        }

        public void EditContact(EditContactModel model)
        {
            var contact = context.Contacts.FirstOrDefault(x => x.Id == model.ContactId);

            var newEmails = model.EmailAddresses.Where(x => x.EmailId == 0).Select(x => new Email()
            {
                Adreess = x.Address,
            }).ToList();

            var newPhones = model.PhoneNumbers.Where(x => x.PhoneId == 0).Select(x => new Phone()
            {
                Number = x.Number,
            }).ToList();

            contact.FirstName = model.FisrtName;
            contact.LastName = model.LastName;
            contact.DateOfBirth = model.DateOfBirth;

            foreach (var phone in newPhones)
            {
                contact.Phones.Add(phone);
            }

            foreach (var email in newEmails)
            {
                contact.Emails.Add(email);
            }

            //TODO add update and delete existing phones and emails

            context.Contacts.Update(contact);
            context.SaveChanges();
        }

        public ContactViewModel GetContact(int id)
        {
            ContactViewModel viewModel = null;

            var contact = context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact != null)
            {
                viewModel = Map(contact);
            }

            return viewModel;
        }

        public IList<ContactViewModel> SearchContacts(SearchContactModel model)
        {
            IList<ContactViewModel> viewModels = new List<ContactViewModel>();
            var contacts = context.Contacts.Where(x => 
                (model.FirstName == string.Empty || x.FirstName == model.FirstName) && 
                (model.LastName == string.Empty || x.LastName == model.LastName)).ToList();

            foreach (var contact in contacts)
            {
                viewModels.Add(Map(contact));
            }

            return viewModels;
        }

        private ContactViewModel Map(Contact contact)
        {
            return new ContactViewModel()
            {
                ContactId = contact.Id,
                FisrtName = contact.FirstName,
                LastName = contact.LastName,
                DateOfBirth = contact.DateOfBirth,
                EmailAddresses = contact.Emails.Select(x => new EmailModel()
                {
                    EmailId = x.Id,
                    Address = x.Adreess
                }).ToList(),
                PhoneNumbers = contact.Phones.Select(x => new PhoneModel()
                {
                    PhoneId = x.Id,
                    Number = x.Number
                }).ToList()
            };
        }
    }
}
