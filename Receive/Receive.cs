using Middleware.Repository;
using Middleware.Repository.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Receive
{
    class Program
    {
        static ILogRepository repository;

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ViajaNet",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    await GravarMensagemAsync(message);
                };
                channel.BasicConsume(queue: "ViajaNet",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static async Task GravarMensagemAsync(string message)
        {
            if (repository == null)
            {
                repository = new LogRepository();
            }

            await repository.GravarAsync(message);
        }
    }
}
