using Ares.Domain.Models;
using Ares.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bogus;

namespace Ares.Infrastructure.FakeServices
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private ICollection<Customer> customers;

        public FakeCustomerRepository(Faker<Customer> faker)
        {
            customers = faker.Generate(100);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            // return customers.Where(c => c.Id == id).SingleOrDefault();

            return customers.SingleOrDefault(c => c.Id == id);
        }
    }
}
