using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace TestRabbit
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            const string queueName = "testqueue";

            var timeout = TimeSpan.FromMilliseconds(3000);

            try
            {
                var connectionFactory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest",
                    Port = 5672,
                    RequestedConnectionTimeout = timeout, //milliseconds
                };

                using (var rabbitConnection = connectionFactory.CreateConnection())
                {
                    using (var channel = rabbitConnection.CreateModel())
                    {
                        channel.QueueDeclare(
                            queue: queueName,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        while (true)
                        {
                            string body = $"Random message: {DateTime.Now.Ticks}";
                            channel.BasicPublish(
                                exchange: string.Empty,
                                routingKey: queueName,
                                basicProperties: null,
                                body: Encoding.UTF8.GetBytes(body));

                            Console.WriteLine("Message sent");
                            await Task.Delay(500);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("End");
            Console.Read();
        }
    }
}
