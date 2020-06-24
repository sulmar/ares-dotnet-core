using Ares.Domain.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Ares.SignalR.Sender.ConsoleClient
{

    // dotnet add package Microsoft.AspNetCore.SignalR.Client
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Sender Signal-R!");

            const string url = "http://localhost:5000/signalr/messages";

            string token = "your-token";

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url, options => options.Headers.Add("Authorization", $"Bearer {token}"))
                .Build();

            await connection.StartAsync();

            int counter = 1;

            while(true)
            {
                Message message = new Message { Title = $"Hello World {counter++}", Content = "Lorem ipsum" };

                await connection.SendAsync("SendMessage", message);
                Console.WriteLine($"Sent {message.Title}");

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            Console.ResetColor();
        }
    }
}
