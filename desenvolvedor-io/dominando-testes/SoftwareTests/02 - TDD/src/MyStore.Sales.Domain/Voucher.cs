using FluentValidation.Results;
using System;

namespace MyStore.Sales.Domain
{
    public class Voucher
    {
        public string Code { get; private set; }

        public VoucherDiscountType DiscountType { get; private set; }

        public decimal? CashDiscount { get; private set; }

        public int? PercentDiscount { get; private set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; private set; }

        public bool Active { get; private set; }

        public bool Used { get; private set; }

        public Voucher(
            string code,
            VoucherDiscountType discountType,
            decimal? cashDiscount,
            int? percentDiscount,
            int quantity,
            DateTime expirationDate,
            bool active,
            bool used)
        {
            Code = code;
            DiscountType = discountType;
            CashDiscount = cashDiscount;
            PercentDiscount = percentDiscount;
            Quantity = quantity;
            ExpirationDate = expirationDate;
            Active = active;
            Used = used;
        }

        public ValidationResult Applicable()
        {
            return new VoucherApplicableValidation().Validate(this);
        }
    }
}
