using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductAppService _productAppService;

        public StoreController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("")]
        [Route("store")]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAll());
        }

        [HttpGet("product-details/{id:guid}")]
        public async Task<IActionResult> ProductDetail(Guid id)
        {
            return View(await _productAppService.GetById(id));
        }
    }
}
