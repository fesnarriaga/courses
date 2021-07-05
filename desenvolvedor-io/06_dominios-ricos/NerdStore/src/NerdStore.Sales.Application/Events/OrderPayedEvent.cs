using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Application.Events
{
    public class OrderPayedEvent : Event
    {
        public Guid OrderId { get; private set; }

        public OrderPayedEvent(Guid orderId)
        {
            AggregateId = orderId;
            OrderId = orderId;
        }
    }
}
