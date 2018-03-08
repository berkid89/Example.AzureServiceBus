using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        const string ServiceBusConnectionString = "";
        const string TopicName = "mytesttopic";
        static ITopicClient topicClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            // Send Messages
            await SendMessagesAsync(new
            {
                id = 1,
                name = "Test thing 1",
                anotherThings = new List<string>() { "apple", "chair", "dog" }
            });

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            await topicClient.CloseAsync();
        }

        static async Task SendMessagesAsync(object msgBody)
        {
            try
            {
                var msgAsJson = JsonConvert.SerializeObject(msgBody);
                var message = new Message(Encoding.UTF8.GetBytes(msgAsJson));

                Console.WriteLine($"Sending message: {msgAsJson}");

                // Send the message to the queue
                await topicClient.SendAsync(message);

            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
