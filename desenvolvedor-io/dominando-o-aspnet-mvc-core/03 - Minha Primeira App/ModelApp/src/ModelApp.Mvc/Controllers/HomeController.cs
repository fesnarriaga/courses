using Microsoft.AspNetCore.Mvc;

namespace ModelApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
