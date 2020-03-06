using System;
using System.Collections.Generic;
using System.Text;
using Ares.Extensions;
using System.Linq;

namespace Ares.ConsoleClient
{
    public class ExtentionMethodTests
    {
        public static void Test()
        {

            IEnumerable<int> numbers = new List<int> { 43, 767, 4, 767, 2323 };

            var luckyNumbers = numbers.Where(n => n > 50);


           // DateTime.Today.IsDaylightSavingTime
            decimal unitPrice = 100.56m;

           // unitPrice.ToWords()


            if (DateTime.Now.IsDaylightSavingTime())
            {

            }

            // ...

            // DateTime.Now.AddWorkingDays()


            if (DateTime.Now.IsWeekend())
            {
                Console.WriteLine("Hurra!");
            }

            // ...
        }
    }


    public class DateTimeHelper
    {
        public static bool IsWeekend(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday ||
                 dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }


    public static class DecimalExtensions
    {
        public static string ToWords(this decimal amount)
        {
            return "sto pięć";
        }
    }


}
