using Ares.Domain.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Infrastructure.Fakers
{

    // dotnet add package Bogus
    public class CustomerFaker : Faker<Customer> 
    {
        public CustomerFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Salary, f => f.Finance.Amount(100, 1000));
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.3f));
        }
    }
}
