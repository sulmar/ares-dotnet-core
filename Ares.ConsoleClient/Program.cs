using Ares.Domain.Services;
using Ares.Infrastructure.Fakers;
using Ares.Infrastructure.FakeServices;
using Microsoft.Extensions.Options;
using System;

namespace Ares.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            GetProductsTest();

            // ExtentionMethodTests.Test();

           // GenericTypesTests.Test();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


            //Phone phone = new Phone();
            //phone.Call("555-556-444", "Lorem");

            //Phone
            //    .From("555-666-777")
            //    .To("555-999-333")
            //    .WithSubject("Lorem")
            //    .Call();


        }

        private static void GetProductsTest()
        {
            IOptions<FakeOptions> options = Options.Create(new FakeOptions { Quantity = 100 });

            IProductRepository productRepository = new FakeProductRepository(new ProductFaker(), options);

            var products = productRepository.Get("red");

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} {product.Color}");
            }

        }
    }


}
