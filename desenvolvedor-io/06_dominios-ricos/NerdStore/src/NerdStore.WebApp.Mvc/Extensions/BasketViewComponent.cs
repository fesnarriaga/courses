using Microsoft.AspNetCore.Mvc;
using NerdStore.Sales.Application.Interfaces.Queries;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Extensions
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IOrderQueriesFacade _orderQueries;

        protected Guid CustomerId = Guid.Parse("4B6C735A-3FC3-4282-98A0-8676A694F6C3");

        public BasketViewComponent(IOrderQueriesFacade orderQueries)
        {
            _orderQueries = orderQueries;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await _orderQueries.GetCustomerCart(CustomerId);
            var items = cart?.Items.Count ?? 0;

            return View(items);
        }
    }
}
