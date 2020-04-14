using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            HubConnection connection = new HubConnectionBuilder().WithUrl("https://localhost:54438/ConectHub").Build();
            connection.Closed += async (error) => {

                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();

            };

            connection.On<string>("Connected",
                (connectionid) => {
                    Console.WriteLine($"Your connection id is:{connectionid}");
                    Console.WriteLine("Enter your name");

                });
            connection.On<string, string>("ReceivedMesssage",
                (user, message) => {
                    Console.WriteLine($"{user}:{message}");

                });

            try
            {
                connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            name = Console.ReadLine();
            Console.WriteLine($"Write your message {name}");
            replay(connection, name);

        }

        private static void replay(HubConnection connection, string name)
        {

            while (true)
            {
                string message = Console.ReadLine();
                connection.InvokeAsync("SendMessage", name, message);
            }

        }
    }
}
