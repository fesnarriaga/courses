using CompleteApp.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompleteApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3):int}")]
        public IActionResult Error(int id)
        {
            var errorViewModel = new ErrorViewModel { ErrorCode = id };

            switch (id)
            {
                case 500:
                    errorViewModel.Title = "Internal server error";
                    errorViewModel.Message = "An error occurred. Try again later.";
                    break;
                case 404:
                    errorViewModel.Title = "Page not found";
                    errorViewModel.Message = "Resource not found. Contact us.";
                    break;
                case 403:
                    errorViewModel.Title = "Access denied";
                    errorViewModel.Message = "You are not allowed";
                    break;
                default:
                    return StatusCode(500);
            }

            return View("Error", errorViewModel);
        }
    }
}
