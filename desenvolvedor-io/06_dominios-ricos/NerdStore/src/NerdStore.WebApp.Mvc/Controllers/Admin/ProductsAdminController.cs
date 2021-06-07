using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Catalog.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Controllers.Admin
{
    public class ProductsAdminController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductsAdminController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet("products-admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAll());
        }

        [HttpGet("new-product")]
        public async Task<IActionResult> NewProduct()
        {
            return View(await FillCategories(new ProductViewModel()));
        }

        [HttpPost("new-product")]
        public async Task<IActionResult> NewProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return View(await FillCategories(productViewModel));

            await _productAppService.Add(productViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("edit-product")]
        public async Task<IActionResult> EditProduct(Guid id)
        {
            return View(await FillCategories(await _productAppService.GetById(id)));
        }

        [HttpPost("edit-product")]
        public async Task<IActionResult> EditProduct(Guid id, ProductViewModel productViewModel)
        {
            var product = await _productAppService.GetById(id);
            productViewModel.StockAmount = product.StockAmount;

            ModelState.Remove("StockAmount");
            if (!ModelState.IsValid)
                return View(await FillCategories(productViewModel));

            await _productAppService.Update(productViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("product-update-stock")]
        public async Task<IActionResult> ProductUpdateStock(Guid id)
        {
            return View("Stock", await _productAppService.GetById(id));
        }

        [HttpPost("product-update-stock")]
        public async Task<IActionResult> ProductUpdateStock(Guid id, int amount)
        {
            if (amount > 0)
            {
                await _productAppService.IncreaseStock(id, amount);
            }
            else
            {
                await _productAppService.DecreaseStock(id, amount);
            }

            return View("Index", await _productAppService.GetAll());
        }

        private async Task<ProductViewModel> FillCategories(ProductViewModel productViewModel)
        {
            productViewModel.Categories = await _productAppService.GetCategories();

            return productViewModel;
        }
    }
}
