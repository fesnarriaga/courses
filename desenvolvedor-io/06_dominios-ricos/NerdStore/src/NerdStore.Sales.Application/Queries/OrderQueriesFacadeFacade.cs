using NerdStore.Sales.Application.Interfaces.Queries;
using NerdStore.Sales.Application.Queries.ViewModels;
using NerdStore.Sales.Domain.Enums;
using NerdStore.Sales.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Sales.Application.Queries
{
    public class OrderQueriesFacadeFacade : IOrderQueriesFacade
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQueriesFacadeFacade(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<CartViewModel> GetCustomerCart(Guid customerId)
        {
            var order = await _orderRepository.GetDraftOrderByCustomer(customerId);

            if (order == null)
                return null;

            var cart = new CartViewModel
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                SubTotal = order.Discount + order.Total,
                Total = order.Total,
                Discount = order.Discount
            };

            if (order.VoucherId.HasValue)
                cart.VoucherCode = order.Voucher.Code;

            foreach (var item in order.Items)
            {
                cart.Items.Add(new CartItemViewModel
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Total = item.Price * item.Quantity
                });
            }

            return cart;
        }

        public async Task<IEnumerable<OrderViewModel>> GetCustomerOrders(Guid customerId)
        {
            var orders = await _orderRepository.GetOrdersByCustomer(customerId);

            orders = orders
                .Where(x => x.Status is OrderStatus.Payed or OrderStatus.Canceled)
                .OrderByDescending(x => x.Code);

            var listOrderViewModel = orders.Select(x => new OrderViewModel
            {
                Code = x.Code,
                Total = x.Total,
                Status = (int)x.Status,
                CreatedAt = x.CreatedAt
            }).ToList();

            return listOrderViewModel;
        }
    }
}
