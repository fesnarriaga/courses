using System;

namespace NerdStore.Core.Messages.IntegrationEvents
{
    public class OrderPaymentApprovedEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid TransactionId { get; set; }
        public decimal Total { get; set; }

        public OrderPaymentApprovedEvent(
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
