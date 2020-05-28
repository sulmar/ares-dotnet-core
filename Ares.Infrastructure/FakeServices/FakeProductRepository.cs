using Ares.Domain.Models;
using Ares.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.Extensions.Options;
using Bogus.Extensions;
using Ares.Domain.Models.SearchCriterias;
using System.Runtime.InteropServices;

namespace Ares.Infrastructure.FakeServices
{
    public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
    {
        public FakeProductRepository(Faker<Product> faker, IOptions<FakeOptions> options) : base(faker, options)
        {
        }

        private bool Filter(Product product, string color)
        {
            return product.Color == color;
        }

        // SQL: select * from dbo.Products where Color = 'red' and Name like 'a%'

        public IEnumerable<Product> Get(string color)
        {
            //ICollection<Product> results = new List<Product>();

            //foreach (var product in entities)
            //{
            //    if (Filter(product, "red"))
            //    {
            //        results.Add(product);
            //    }
            //}

            //return results;

            // metoda anonimowa
            //FilterDelegate += delegate(Product product)
            //{
            //    return product.Color = "red";
            //}

            // select * 
            // from entities as product
            // where Color = 'red' and Name like 'a%' 
            // order by Name desc, UnitPrice asc, Id desc


            var query4 = from product in entities
                        where product.Color == color && product.Name.StartsWith("a")
                        orderby product.Name descending, product.UnitPrice ascending, product.Id descending
                        select product;

            var query = entities
                     .Where(product => product.Color == color && product.Name.StartsWith("a"))
                     .OrderByDescending(product => product.Name)
                     .ThenBy(product => product.UnitPrice)
                     .ThenByDescending(product => product.Id);
            
             IQueryable<Product> query3 = entities.AsQueryable()
                     .Where(product => product.Color == color)
                     .Where(product => product.Name.StartsWith("a"))
                     .OrderBy(product => product.Name)
                     .Select( product => product)
                     .Skip(5)
                     .Take(10);


            IEnumerable<Product> query2 = entities
                .Where(product =>
                    {
                        bool validColor = product.Color == color;

                        return validColor;
                    });
                    
                    

            // javascript   - funkcje strzałkowe ->
            // R  f <- x + y

            return query.ToList();
        }

        public IEnumerable<Product> Get(ProductSearchCriteria criteria)
        {
            IQueryable<Product> products = entities.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Color))
            {
                products = products.Where(p => p.Color == criteria.Color);
            }

            if (criteria.FromUnitPrice.HasValue)
            {
                products = products.Where(p => p.UnitPrice >= criteria.FromUnitPrice);
            }

            if (criteria.ToUnitPrice.HasValue)
            {
                products = products.Where(p => p.UnitPrice <= criteria.ToUnitPrice);
            }

            return products.ToList();
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
