using System;

namespace NerdStore.Core.Messages.IntegrationEvents
{
    public class OrderPaymentRefusedEvent : IntegrationEvent
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid PaymentId { get; private set; }
        public Guid TransactionId { get; private set; }
        public decimal Total { get; private set; }

        public OrderPaymentRefusedEvent(
            Guid orderId,
            Guid customerId,
            Guid paymentId,
            Guid transactionId,
            decimal total)
        {
            AggregateId = orderId;
            OrderId = orderId;
            CustomerId = customerId;
            PaymentId = paymentId;
            TransactionId = transactionId;
            Total = total;
        }
    }
}
