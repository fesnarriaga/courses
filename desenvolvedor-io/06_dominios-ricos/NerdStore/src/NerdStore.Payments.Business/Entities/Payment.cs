using NerdStore.Core.DomainObjects.Entities;
using NerdStore.Core.DomainObjects.Interfaces;
using System;

namespace NerdStore.Payments.Business.Entities
{
    public class Payment : Entity, IAggregateRoot
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }

        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiresAt { get; set; }
        public string CardCode { get; set; }

        // EF Relations
        public Transaction Transaction { get; set; }
    }
}
