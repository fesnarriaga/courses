using KissLog;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomIdentity.Extensions
{
    public class AuditFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public AuditFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.Identity != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                var message = $"{context.HttpContext.User.Identity.Name} => {context.HttpContext.Request.GetDisplayUrl()}";

                _logger.Info(message);
            }
        }
    }
}
