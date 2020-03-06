using Ares.Domain.Models;
using Ares.Domain.Services;
using System.Collections.Generic;
using Bogus;
using System.Linq;
using Microsoft.Extensions.Options;

namespace Ares.Infrastructure.FakeServices
{
    public class FakeOptions
    {
        public int Quantity { get; set; }
    }

    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected ICollection<TEntity> entities;

        public FakeEntityRepository(Faker<TEntity> faker, IOptions<FakeOptions> options)
        {
            entities = faker.Generate(options.Value.Quantity);
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public virtual void Remove(int id)
        {
            entities.Remove(Get(id));
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
