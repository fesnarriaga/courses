using NerdStore.Core.DomainObjects.Entities;
using NerdStore.Payments.Business.Enums;
using System;

namespace NerdStore.Payments.Business.Entities
{
    public class Transaction : Entity
    {
        public Guid OrderId { get; set; }
        public decimal Total { get; set; }
        public TransactionStatus Status { get; set; }

        // FK
        public Guid PaymentId { get; set; }

        // EF Relations
        public Payment Payment { get; set; }
    }
}
