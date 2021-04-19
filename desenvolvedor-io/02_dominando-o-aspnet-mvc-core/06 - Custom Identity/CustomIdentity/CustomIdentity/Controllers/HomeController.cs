using CustomIdentity.Extensions;
using CustomIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CustomIdentity.Controllers
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

        [ClaimsAuthorize("HomeModule", "Create")]
        public IActionResult CustomClaimsAuthorize()
        {
            return View();
        }

        public IActionResult Exception()
        {
            throw new NotImplementedException("You bad ass!!!");
        }

        [ClaimsAuthorize("HomeModule", "Forbidden")]
        public IActionResult Forbidden()
        {
            return View("CustomClaimsAuthorize");
        }

        [Route("error/{code:length(3, 3)}")]
        public IActionResult Error(int code)
        {
            ErrorViewModel errorViewModel;

            switch (code)
            {
                case 500:
                    errorViewModel = new ErrorViewModel
                    {
                        Code = code,
                        Title = "Unexpected Error",
                        Message = "Something went wrong. Try again later..."
                    };
                    break;

                case 404:
                    errorViewModel = new ErrorViewModel
                    {
                        Code = code,
                        Title = "Page Not Found",
                        Message = "We couldn't find the page you want to access..."
                    };
                    break;

                case 403:
                    errorViewModel = new ErrorViewModel
                    {
                        Code = code,
                        Title = "Access Denied",
                        Message = "You don't have permission to do that"
                    };
                    break;

                default:
                    return StatusCode(404);
            }

            return View("Error", errorViewModel);
        }
    }
}
