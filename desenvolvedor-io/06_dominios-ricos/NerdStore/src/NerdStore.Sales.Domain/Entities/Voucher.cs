using FluentValidation.Results;
using NerdStore.Core.DomainObjects.Entities;
using NerdStore.Sales.Domain.Enums;
using NerdStore.Sales.Domain.Validations;
using System;
using System.Collections.Generic;

namespace NerdStore.Sales.Domain.Entities
{
    public class Voucher : Entity
    {
        public string Code { get; private set; }
        public VoucherType Type { get; private set; }
        public decimal? Percent { get; private set; }
        public decimal? Value { get; private set; }
        public int Quantity { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime? AppliedAt { get; private set; }
        public bool Applied { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // EF Relation
        public ICollection<Order> Orders { get; private set; }

        internal ValidationResult CanApply()
        {
            return new ApplyVoucherValidation().Validate(this);
        }
    }
}
