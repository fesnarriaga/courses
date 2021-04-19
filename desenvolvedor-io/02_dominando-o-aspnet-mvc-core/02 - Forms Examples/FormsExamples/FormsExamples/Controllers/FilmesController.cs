using FormsExamples.Models;
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

        [HttpPost]
        public IActionResult Adicionar(Filme filme)
        {
            return !ModelState.IsValid ? View(filme) : View();
        }
    }
}
