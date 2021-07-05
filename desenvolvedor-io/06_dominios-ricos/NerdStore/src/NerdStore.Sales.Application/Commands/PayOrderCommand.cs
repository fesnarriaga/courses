using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Application.Commands
{
    public class PayOrderCommand : Command
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }

        public PayOrderCommand(Guid customerId, Guid orderId)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
        }
    }
}
