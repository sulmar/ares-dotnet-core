using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.Validations.Models
{
    public class Customer
    {
        public Customer(string firstName, string email)
        {
            FirstName = firstName;
            Email = email;
        }

        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
