using Microsoft.AspNetCore.Mvc.Filters;
using Middleware.Log.Sender.Interface;
using System.Linq;

namespace WebApplication1.Helper
{
    public class CustomActionFilter : IActionFilter
    {
        private ISender sender;

        public CustomActionFilter(ISender Sender)
        {
            sender = Sender;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logging($"{{Controller:'{context.Controller.ToString()}', Filters:['{string.Join("','", context.Filters.Select(s => s.ToString()).ToArray())}']}}");
        }

        private void Logging(string Message)
        {
            sender.Log(Message);
        }
    }
}
