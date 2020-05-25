using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using SimuladorDLL;



namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {

            //var equipamento = new Leitura();

            //Thread oThread = new Thread();

            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            string name = string.Empty;
            HubConnection connection = new HubConnectionBuilder().WithUrl("https://localhost:44339/ChatHub").Build();
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
            }catch(Exception ex)
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

        private static string formating(string name, int Status, string cripto)
        {

            return name;


        }

        
    }
}
