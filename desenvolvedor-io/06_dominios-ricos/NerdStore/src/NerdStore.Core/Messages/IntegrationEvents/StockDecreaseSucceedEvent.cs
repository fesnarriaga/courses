using NerdStore.Core.DomainObjects.Dtos;
using System;

namespace NerdStore.Core.Messages.IntegrationEvents
{
    public class StockDecreaseSucceedEvent : IntegrationEvent
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Total { get; private set; }
        public ProductList ProductList { get; private set; }
        public string CardName { get; private set; }
        public string CardNumber { get; private set; }
        public string CardExpiresAt { get; private set; }
        public string CardCode { get; private set; }

        public StockDecreaseSucceedEvent(
            Guid customerId,
            Guid orderId,
            decimal total,
            ProductList productList,
            string cardName,
            string cardNumber,
            string cardExpiresAt,
            string cardCode)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
            Total = total;
            ProductList = productList;
            CardName = cardName;
            CardNumber = cardNumber;
            CardExpiresAt = cardExpiresAt;
            CardCode = cardCode;
        }
    }
}
