using Ares.Validations.IServices;
using Ares.Validations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.Validations.Services
{
    public class FakeCustomerService : ICustomerService
    {

        private readonly IEnumerable<Customer> customers;

        public FakeCustomerService()
        {
            customers = new List<Customer>
            {
                new Customer("Jane", "jane@test.com"),
                new Customer("Claire", "claire@test.com"),
                new Customer("Dave", "dave@test.com"),
            };
        }

        public bool ExistsEmail(string email)
        {
            return customers.Select(c => c.Email).Contains(email);
        }
    }
}
