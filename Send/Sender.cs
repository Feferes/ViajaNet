using Middleware.Log.Sender.Interface;

namespace Middleware.Log.Sender
{
    public class Sender : ISender
    {
        public void Log(string JsonMessage)
        {
            var send = new Send.Send();

            send.SendMassage(JsonMessage);
        }
    }
}
