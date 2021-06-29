using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Notifications;
using NerdStore.Sales.Application.Commands;
using NerdStore.Sales.Application.Interfaces.Queries;
using NerdStore.Sales.Application.Queries.ViewModels;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public class CartController : BaseController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductAppService _productAppService;
        private readonly IOrderQueriesFacade _orderQueriesFacade;

        public CartController(
            INotificationHandler<DomainNotification> notificationHandler,
            IMediatorHandler mediatorHandler,
            IProductAppService productAppService,
            IOrderQueriesFacade orderQueriesFacade) : base(notificationHandler, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _productAppService = productAppService;
            _orderQueriesFacade = orderQueriesFacade;
        }

        [HttpGet("my-cart")]
        public async Task<IActionResult> Index()
        {
            return View(await _orderQueriesFacade.GetCustomerCart(CustomerId));
        }

        [HttpPost]
        [Route("my-cart")]
        public async Task<IActionResult> AddItem(Guid productId, int quantity)
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

        [HttpPost]
        [Route("remove-item")]
        public async Task<IActionResult> RemoveItem(Guid productId)
        {
            var product = await _productAppService.GetById(productId);

            if (product == null)
                return BadRequest();

            var command = new RemoveOrderItemCommand(CustomerId, productId);
            await _mediatorHandler.SendCommand(command);

            if (!HasErrors())
                return RedirectToAction("Index");

            return View("Index", await _orderQueriesFacade.GetCustomerCart(CustomerId));
        }

        [HttpPost]
        [Route("update-item")]
        public async Task<IActionResult> UpdateItem(Guid productId, int quantity)
        {
            var product = await _productAppService.GetById(productId);

            if (product == null)
                return BadRequest();

            var command = new UpdateOrderItemCommand(CustomerId, productId, quantity);
            await _mediatorHandler.SendCommand(command);

            if (!HasErrors())
                return RedirectToAction("Index");

            return View("Index", await _orderQueriesFacade.GetCustomerCart(CustomerId));
        }

        [HttpPost]
        [Route("apply-voucher")]
        public async Task<IActionResult> ApplyVoucher(string code)
        {
            var command = new ApplyVoucherCommand(CustomerId, code);
            await _mediatorHandler.SendCommand(command);

            if (!HasErrors())
                return RedirectToAction("Index");

            return View("Index", await _orderQueriesFacade.GetCustomerCart(CustomerId));
        }

        [HttpGet]
        [Route("review-cart")]
        public async Task<IActionResult> ReviewCart()
        {
            return View(await _orderQueriesFacade.GetCustomerCart(CustomerId));
        }

        [HttpPost]
        [Route("create-order")]
        public async Task<IActionResult> CreateOrder(CartViewModel cartViewModel)
        {
            var cart = await _orderQueriesFacade.GetCustomerCart(CustomerId);

            var command = new CreateOrderCommand(
                CustomerId,
                cart.OrderId,
                cart.Total,
                cart.Payment.Name,
                cart.Payment.Number,
                cart.Payment.ExpiresAt,
                cart.Payment.Code);
            await _mediatorHandler.SendCommand(command);

            if (!HasErrors())
                return RedirectToAction("Index", "Order");

            return View("ReviewCart", await _orderQueriesFacade.GetCustomerCart(CustomerId));
        }
    }
}
