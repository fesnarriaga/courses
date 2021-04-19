using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomIdentity.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogger<LogsController> _logger;

        public LogsController(ILogger<LogsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogError("This error happened!");

            return View();
        }
    }
}
