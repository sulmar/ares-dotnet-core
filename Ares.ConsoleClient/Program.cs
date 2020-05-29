using Ares.Domain.Models;
using Ares.Domain.Services;
using Ares.Infrastructure.Fakers;
using Ares.Infrastructure.FakeServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Ares.ConsoleClient
{
    class Program
    {
        static void Worker(CancellationToken cancellationToken = default)
        {
            while(!cancellationToken.IsCancellationRequested)
            {
                Console.Write(".");
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
        }

        static void Downloads(
            CancellationToken cancellationToken = default,
            IProgress<int> progress = null)
        {
            for (int i = 0; i < 100; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                // cancellationToken.ThrowIfCancellationRequested();

                // Console.Write(".");

                progress?.Report(i);

                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
        }

        public static Task DownloadsAsync(
                CancellationToken cancellationToken = default,
                IProgress<int> progress = null)
        {
            return Task.Run(() => Downloads(cancellationToken, progress));
        }

        private static void DownloadsTest()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            CancellationToken cancellationToken = cts.Token;

          //  IProgress<int> progress = new Progress<int>(step => Console.Write("."));

            IProgress<int> progress = new MyProgressBar();

            DownloadsAsync(cancellationToken, progress);



            Console.WriteLine("Press Enter key to cancel.");
            Console.ReadLine();

            cts.Cancel();
        }

        private static void DownloadsTimerTest()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            CancellationToken cancellationToken = cts.Token;

            cts.CancelAfter(TimeSpan.FromSeconds(5));

            DownloadsAsync(cancellationToken);
        }

        private static void DownloadsTimerTest2()
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            CancellationToken cancellationToken = cts.Token;

            DownloadsAsync(cancellationToken);

        }



        static void DoWork()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} working...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Done.");
        }


        

        static decimal Calculate(int length)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} calculating {length}...");
           
            Thread.Sleep(TimeSpan.FromMilliseconds(length));

            decimal cost = length * 0.99m;

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} calculated {cost}...");

            return cost;


        }

       

        static void DownloadTaskTest()
        {
            //Task<int> task = Task.Run(() => Download("http://www.sulmar.pl"));
            //task.ContinueWith(t => Console.WriteLine(t.Result));

            Task.Run(() => Download("http://www.sulmar.pl"))
                .ContinueWith(t => Task.Run(() => Calculate(t.Result)))
                    .ContinueWith(t => Console.WriteLine($"Cost: {t.Result.Result}"));

        }

        static int Download(string url)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading {url}...");

            var client = new WebClient();
            string content = client.DownloadString(url);
            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloaded {url}.");

            return content.Length;
        }

        static Task<int> DownloadAsync(string url)
        {
            return Task.Run(() => Download(url));
        }

        static Task<decimal> CalculateAsync(int length)
        {
            return Task.Run(() => Calculate(length));
        }

        static void DownloadContinueWithTest()
        {
            DownloadAsync("http://www.sulmar.pl")
                .ContinueWith(t => CalculateAsync(t.Result))
                    .ContinueWith(t => Console.WriteLine($"Cost: {t.Result.Result}"));
        }

        static void DownloadSyncTest()
        {
            int length = Download("http://www.sulmar.pl");
            decimal cost = Calculate(length);
            Console.WriteLine($"Cost: {cost}");
        }

        static async void DownloadAsyncAwaitTest()
        {
            int length = await DownloadAsync("http://www.sulmar.pl").ConfigureAwait(false);
            decimal cost = await CalculateAsync(length);
            Console.WriteLine($"Cost: {cost}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Hello World!");

            DynamicHtmlTest();

           //  DownloadsTest();

           // DownloadsTimerTest();

            //Task task1 = DownloadAsync("http://www.sulmar.pl");

            //Task task2 = DownloadAsync("http://www.microsoft.com");

            // Task.WaitAll(task1, task2);

            // Task.WhenAny(task1, task2);





            //Thread thread = new Thread(() => DoWork());
            //thread.Start();

            // Task task = new Task(() => DoWork());

            // Task task=  Task.Run(() => DoWork());



            // Task.Run(() => Download("http://www.sulmar.pl"));

            // DownloadSyncTest();
            //DownloadTaskTest();

            // DownloadAsyncAwaitTest();




            //ICollection<Task> tasks = new List<Task>();

            //tasks.Add(new Task(() => DoWork()));
            //tasks.Add(new Task(() => DoWork()));
            //tasks.Add(new Task(() => DoWork()));

            //foreach (var t in tasks)
            //{
            //    t.Start();
            //}

            //  task.Start();



            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Press any key to exit.");
            Console.ReadKey();

            // GetProductsTest();

            // ExtentionMethodTests.Test();

            // GenericTypesTests.Test();

            //Phone phone = new Phone();
            //phone.Call("555-556-444", "Lorem");

            //Phone
            //    .From("555-666-777")
            //    .To("555-999-333")
            //    .WithSubject("Lorem")
            //    .Call();


        }

        private static void DynamicHtmlTest()
        {

            IFormRepository formRepository = new FakeFormRepository();

            Form form = formRepository.Get("customers");

            IVisitor visitor = new HtmlVisitor();

            form.Accept(visitor);

            Console.WriteLine(visitor.Output);

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
