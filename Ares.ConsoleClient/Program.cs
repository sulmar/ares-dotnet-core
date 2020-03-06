using System;

namespace Ares.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ExtentionMethodTests.Test();

            GenericTypesTests.Test();

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
    }


}
