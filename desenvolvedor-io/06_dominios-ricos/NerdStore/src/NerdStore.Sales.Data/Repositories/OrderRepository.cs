using NerdStore.Core.Interfaces.UnitOfWork;
using NerdStore.Sales.Domain.Entities;
using NerdStore.Sales.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Sales.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<Order> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetDraftOrderByCustomerId(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public void Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetOrderItemById(Guid orderItemId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetOrderItemByProductId(Guid orderId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<Voucher> GetVoucherByCode(string code)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
