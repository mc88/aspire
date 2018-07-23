using System;
using System.Collections.Generic;

namespace WPFAspire.Database.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IList<Email> Emails { get; set; }

        public IList<Phone> Phones { get; set; }
    }
}
