using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WPFAspire.BusinessInterfaces.Models
{
    public class EditContactModel
    {
        public EditContactModel()
        {
            EmailAddresses = new List<EmailModel>();
            PhoneNumbers = new List<PhoneModel>();
        }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public string FisrtName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IList<EmailModel> EmailAddresses { get; set; }

        public IList<PhoneModel> PhoneNumbers { get; set; }
    }
}
