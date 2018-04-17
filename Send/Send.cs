using Middleware.Log.Sender.Config;
using RabbitMQ.Client;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Send
{
    static class Log
    {
        private static readonly log4net.ILog log;

        public static void Error(Exception Exception)
        {
            Error(Exception.ToString());
        }
        public static void Error(string Message)
        {
            if (log == null)
            {
                XmlDocument log4netConfig = new XmlDocument();
                log4netConfig.Load(File.OpenRead(Path.Combine(Environment.CurrentDirectory, "log4net.config")));
                var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                log4net.LogManager.GetLogger(typeof(Log));
            }

            log.Error(Message);
        }
    }
    class Send
    {
        public void SendMassage(string message)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = ConfigurationManager.QueueHost };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: ConfigurationManager.QueueName,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: ConfigurationManager.RoutineQueue,
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
