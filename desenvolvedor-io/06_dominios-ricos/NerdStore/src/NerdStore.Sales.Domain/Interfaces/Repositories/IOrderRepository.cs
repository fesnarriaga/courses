using NerdStore.Core.Interfaces.Repositories;
using NerdStore.Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetById(Guid id);
        Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId);
        Task<Order> GetDraftOrderByCustomerId(Guid customerId);

        void Add(Order order);
        void Update(Order order);

        // OrderItem
        Task<OrderItem> GetOrderItemById(Guid orderItemId);
        Task<OrderItem> GetOrderItemByProductId(Guid orderId, Guid productId);

        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void RemoveOrderItem(OrderItem orderItem);

        // Voucher
        Task<Voucher> GetVoucherByCode(string code);
    }
}
