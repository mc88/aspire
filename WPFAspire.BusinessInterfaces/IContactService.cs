using System.Collections.Generic;
using WPFAspire.BusinessInterfaces.Models;

namespace WPFAspire.BusinessInterfaces
{
    public interface IContactService
    {
        void AddContact(AddContactModel model);

        void EditContact(EditContactModel model);

        ContactViewModel GetContact(int id);

        IList<ContactViewModel> SearchContacts(SearchContactModel model);
    }
}
