using Ares.Domain.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Ares.SignalR.Receiver.ConsoleClient
{
    // dotnet add package Microsoft.AspNetCore.SignalR.Client
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Receiver Signal-R!");

            const string url = "http://localhost:5000/signalr/messages";

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            await connection.StartAsync();

            connection.On<Message>("YouHaveGotMessage", 
                message => Console.WriteLine($"Received {message.Title} {message.Content}"));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            Console.ResetColor();
        }
    }
}
