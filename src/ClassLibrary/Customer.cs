using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime SignedUpDate { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public bool Disabled { get; set; }
    }
}
