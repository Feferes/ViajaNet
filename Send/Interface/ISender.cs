namespace Middleware.Log.Sender.Interface
{
    public interface ISender
    {
        void Log(string JsonMessage);
    }
}