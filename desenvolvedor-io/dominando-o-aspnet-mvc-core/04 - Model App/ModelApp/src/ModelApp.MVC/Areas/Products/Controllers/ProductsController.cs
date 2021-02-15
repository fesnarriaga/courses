using Microsoft.AspNetCore.Mvc;

namespace ModelApp.MVC.Areas.Products.Controllers
{
    [Area("Products")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
