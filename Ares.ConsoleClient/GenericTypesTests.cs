using Ares.Domain.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ares.ConsoleClient
{
    public class GenericTypesTests
    {
        public static void Test()
        {
            Sender sender = new Sender();
            sender.Send<DateTime>(DateTime.Now);
            sender.Send<Customer>(new Customer());
            sender.Send<decimal>(100.54m);
          //  sender.Send2<decimal>(330m);


            //ContentPrinter<DateTime> contentPrinter = new ContentPrinter<DateTime>();
            //contentPrinter.Print(DateTime.Now);

            //ContentPrinter<Product> contentPrinter1 = new ContentPrinter<Product>();

            ContentPrinter<Customer> customerPrinter = new ContentPrinter<Customer>();
            customerPrinter.Print(new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki"
            }
                
                );




            Printer printer = new Printer();
            printer.Print("Hello!");

            DateTime lastDateTime = (DateTime) printer.GetLastContent();


            StringPrinter stringPrinter = new StringPrinter();
            stringPrinter.Print("Hello .NET Core!");

            string last = stringPrinter.GetLastContent();

            DecimalPrinter decimalPrinter = new DecimalPrinter();
            decimalPrinter.Print(100m);
        }
    }

    public class StringPrinter
    {
        private string lastContent;

        public string GetLastContent()
        {
            return lastContent;
        }

        public void Print(string content)
        {
            Console.WriteLine($"Printing {content}");

            lastContent = content;
        }

    }

    public class DecimalPrinter
    {
        private decimal lastContent;

        public decimal GetLastContent()
        {
            return lastContent;
        }

        public void Print(decimal content)
        {
            Console.WriteLine($"Printing {content}");

            lastContent = content;
        }

    }

    public class DateTimePrinter
    {
        private DateTime lastContent;

        public DateTime GetLastContent()
        {
            return lastContent;
        }

        public void Print(DateTime content)
        {
            Console.WriteLine($"Printing {content}");

            lastContent = content;
        }

    }

    public class ContentPrinter<TContent>
        where TContent : ICloneable
    {
        private TContent lastContent;

        public TContent GetLastContent()
        {
            return lastContent;
        }
    
        public void Print(TContent content)
        {
            Console.WriteLine($"Printing {content.Clone()}");

            lastContent = content;
        }

    }

    public class Sender
    {
        //public void Send(string content)
        //{
        //    Console.WriteLine(content);
        //}

        //public void Send(Customer customer)
        //{
        //    Console.WriteLine(customer);
        //}

        //public void Send(DateTime datetime)
        //{
        //    Console.WriteLine(datetime);
        //}

        public void Send<TContent>(TContent content)
        {
            Console.WriteLine(content);
        }

        public void Send2<TContent>(TContent content)
            where TContent : BaseEntity, ICloneable
        {
            Console.WriteLine(content);
        }

        public TContent Create<TContent>()
            where TContent : new()
        {
            return new TContent();
        }
    }




    public class Printer
    {
        private object lastContent;

        public object GetLastContent()
        {
            return lastContent;
        }

        public void Print(object content)
        {
            Console.WriteLine($"Printing {content}");

            lastContent = content;
        }

    }
}
