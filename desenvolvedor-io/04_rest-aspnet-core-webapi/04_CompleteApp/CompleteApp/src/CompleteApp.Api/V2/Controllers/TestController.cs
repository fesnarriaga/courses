using CompleteApp.Api.Controllers;
using CompleteApp.Business.Interfaces.Auth;
using CompleteApp.Business.Interfaces.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompleteApp.Api.V2.Controllers
{
    [AllowAnonymous]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TestController : BaseController
    {
        private readonly ILogger _logger;

        public TestController(
            ILogger<TestController> logger,
            INotificator notificator,
            IUser user) : base(notificator, user)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Index(string version)
        {
            return $"Hi, I am v{version}";
        }

        [HttpGet("logs")]
        public string Logs()
        {
            _logger.LogTrace("Trace log");
            _logger.LogDebug("Debug log");
            _logger.LogInformation("Information log");
            _logger.LogWarning("Warning log");
            _logger.LogError("Erro log");
            _logger.LogCritical("Critical log");

            return "Logs in console...";
        }
    }
}
