using System;
using System.Collections.Generic;
using System.Linq;

namespace WPFAspire.BusinessInterfaces.Models
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            EmailAddresses = new List<EmailModel>();
            PhoneNumbers = new List<PhoneModel>();
        }

        public int ContactId { get; set; }

        public string FisrtName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IList<EmailModel> EmailAddresses { get; set; }

        public IList<PhoneModel> PhoneNumbers { get; set; }

        public string Emails { get { return string.Join(",", EmailAddresses.Select(x => x.Address)); } }

        public string Phones { get { return string.Join(",", PhoneNumbers.Select(x => x.Number)); } }
    }
}
