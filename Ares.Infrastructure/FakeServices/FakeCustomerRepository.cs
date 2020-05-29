using Ares.Domain.Models;
using Ares.Domain.Services;
using System;
using System.Text;
using System.Linq;
using Bogus;
using System.Data;
using Microsoft.Extensions.Options;

namespace Ares.Infrastructure.FakeServices
{


    public class FakeCustomerRepository : FakeEntityRepository<Customer>, ICustomerRepository
{
    public FakeCustomerRepository(Faker<Customer> faker,
        IOptions<FakeOptions> options) : base(faker, options)
    {
    }

    public override void Remove(int id)
    {
        Customer customer = Get(id);
        customer.IsRemoved = true;
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
