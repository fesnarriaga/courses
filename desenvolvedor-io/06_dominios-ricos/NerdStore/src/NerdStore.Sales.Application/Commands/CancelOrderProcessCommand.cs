using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Application.Commands
{
    public class CancelOrderProcessCommand : Command
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }

        public CancelOrderProcessCommand(Guid customerId, Guid orderId)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
        }
    }
}
