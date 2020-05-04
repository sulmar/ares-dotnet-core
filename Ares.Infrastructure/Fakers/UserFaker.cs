using Ares.Domain.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Infrastructure.Fakers
{
    public class UserFaker : Faker<User>
    {
        public UserFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.UserId, (f, u) => $"user{u.Id}");
            RuleFor(p => p.HashedPassword, "12345");
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.IsLocked, f => false);
        }
    }
}
