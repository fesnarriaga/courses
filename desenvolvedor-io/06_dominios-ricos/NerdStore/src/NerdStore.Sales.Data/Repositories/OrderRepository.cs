using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Interfaces.UnitOfWork;
using NerdStore.Sales.Data.Context;
using NerdStore.Sales.Domain.Entities;
using NerdStore.Sales.Domain.Enums;
using NerdStore.Sales.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Sales.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SalesContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public OrderRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(Guid customerId)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Order> GetDraftOrderByCustomer(Guid customerId)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.CustomerId == customerId && x.Status == OrderStatus.Draft);

            if (order is null)
                return null;

            await _context.Entry(order).Collection(x => x.Items).LoadAsync();

            if (order.Voucher != null)
            {
                await _context.Entry(order).Reference(x => x.Voucher).LoadAsync();
            }

            return order;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public async Task<OrderItem> GetOrderItemById(Guid orderItemId)
        {
            return await _context.OrderItems.FindAsync(orderItemId);
        }

        public async Task<OrderItem> GetOrderItemByOrderAndProduct(Guid orderId, Guid productId)
        {
            return await _context.OrderItems
                .FirstOrDefaultAsync(x => x.OrderId == orderId && x.ProductId == productId);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
        }

        public async Task<Voucher> GetVoucherByCode(string code)
        {
            return await _context.Vouchers
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
