using System;

namespace NerdStore.Core.DomainObjects.Dtos.Payment
{
    public class OrderPayment
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Total { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiresAt { get; set; }
        public string CardCode { get; set; }
    }
}
