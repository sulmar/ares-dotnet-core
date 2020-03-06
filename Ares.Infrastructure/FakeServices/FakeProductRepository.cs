using Ares.Domain.Models;
using Ares.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.Extensions.Options;

namespace Ares.Infrastructure.FakeServices
{
    public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
    {
        public FakeProductRepository(Faker<Product> faker, IOptions<FakeOptions> options) : base(faker, options)
        {
        }

        public IEnumerable<Product> Get(string color)
        {
            return entities.Where(p => p.Color == color).ToList();
        }
    }

    //public class FakeCustomerRepository : ICustomerRepository
    //{
    //    private ICollection<Customer> customers;

    //    public FakeCustomerRepository(Faker<Customer> faker)
    //    {
    //        customers = faker.Generate(100);
    //    }

    //    public void Add(Customer customer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Customer> Get()
    //    {
    //        return customers;
    //    }

    //    public Customer Get(int id)
    //    {
    //        // return customers.Where(c => c.Id == id).SingleOrDefault();

    //        return customers.SingleOrDefault(c => c.Id == id);
    //    }
    //}
}
