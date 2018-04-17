namespace Middleware.Log.Sender.Config
{
    static class ConfigurationManager
    {
        public static string QueueHost { get { return "localhost"; } }
        public static string QueueName { get { return "ViajaNet"; } }
        public static string RoutineQueue { get { return "QueueBus"; } }
    }
}