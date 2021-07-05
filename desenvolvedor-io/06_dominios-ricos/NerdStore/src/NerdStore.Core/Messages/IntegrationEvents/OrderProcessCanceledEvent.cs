using NerdStore.Core.DomainObjects.Dtos.Order;
using System;

namespace NerdStore.Core.Messages.IntegrationEvents
{
    public class OrderProcessCanceledEvent : IntegrationEvent
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public ProductList ProductList { get; private set; }

        public OrderProcessCanceledEvent(Guid customerId, Guid orderId, ProductList productList)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
            ProductList = productList;
        }
    }
}
