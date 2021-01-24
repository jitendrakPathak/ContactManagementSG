using System;
namespace ContactManagement.Models
{
    public class PhoneNumberModel
    {
        public PhoneNumberModel()
        {
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
}
