using Ares.Domain.Models;
using Bogus;
using System;

namespace Ares.Infrastructure.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.UnitPrice, f => Math.Round( f.Random.Decimal(10, 200), 2));
            Ignore(p => p.LastAccess);
        }
    }
}
