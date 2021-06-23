using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Notifications;
using NerdStore.Sales.Application.Commands;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class CartController : BaseController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductAppService _productAppService;

        public CartController(
            INotificationHandler<DomainNotification> notificationHandler,
            IMediatorHandler mediatorHandler,
            IProductAppService productAppService) : base(notificationHandler, mediatorHandler)
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
                return RedirectToAction("ProductDetail", "Store", new { Id = productId });
            }

            var command = new AddOrderItemCommand(product.Name, quantity, product.Price, CustomerId, productId);
            await _mediatorHandler.SendCommand(command);

            if (!HasErrors())
            {
                return RedirectToAction("Index");
            }

            TempData["Errors"] = GetErrorMessages();
            return RedirectToAction("ProductDetail", "Store", new { Id = productId });
        }
    }
}
