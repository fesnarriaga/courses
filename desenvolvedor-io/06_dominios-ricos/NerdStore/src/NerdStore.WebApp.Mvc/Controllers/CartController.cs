using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Core.Mediator;
using NerdStore.Sales.Application.Commands;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class CartController : BaseController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductAppService _productAppService;

        public CartController(IMediatorHandler mediatorHandler, IProductAppService productAppService)
        {
            _mediatorHandler = mediatorHandler;
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("my-cart")]
        public async Task<IActionResult> AddOrderItem(Guid productId, int quantity)
        {
            var product = await _productAppService.GetById(productId);
            if (product is null)
                return BadRequest();

            if (product.StockAmount < quantity)
            {
                TempData["Error"] = "Stock unavailable";
                return RedirectToAction("ProductDetail", "Store", new { productId });
            }

            var command = new AddOrderItemCommand(product.Name, quantity, product.Price, CustomerId, productId);
            await _mediatorHandler.SendCommand(command);

            TempData["Error"] = "Product unavailable";
            return RedirectToAction("ProductDetail", "Store", new { productId });
        }
    }
}
