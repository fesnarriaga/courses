using Microsoft.AspNetCore.Mvc;

namespace FormsExamples.Controllers
{
    public class FilmesController : Controller
    {
        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
    }
}
