using System;
using System.Collections.Generic;

namespace ContactManagement.Models
{
    public class ContactModel
    {
        public ContactModel()
        {
            PhoneNumbers = new HashSet<PhoneNumberModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<PhoneNumberModel> PhoneNumbers { get; set; }
    }
}
