using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.ConsoleClient
{
    public class MyProgressBar : IProgress<int>
    {
        public void Report(int value)
        {
            Console.WriteLine(value);

           // progressBar.Value = value;
        }
    }
}
