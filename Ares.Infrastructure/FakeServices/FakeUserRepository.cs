using Ares.Domain.Models;
using Ares.Domain.Services;
using Bogus;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Ares.Infrastructure.FakeServices
{
    public class FakeUserRepository : FakeEntityRepository<User>, 
        IUserRepository, IAuthorizationService
    {
        public FakeUserRepository(Faker<User> faker, 
            IOptions<FakeOptions> options) : base(faker, options)
        {
        }

        public bool TryAuthorize(string userId, string hashedPassword, out User user)
        {
            user = entities.SingleOrDefault(u => u.UserId == userId && u.HashedPassword == hashedPassword);

            return user != null;
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
