using FluentValidation;
using NerdStore.Sales.Domain.Entities;
using System;

namespace NerdStore.Sales.Domain.Validations
{
    public class ApplyVoucherValidation : AbstractValidator<Voucher>
    {
        public ApplyVoucherValidation()
        {
            RuleFor(x => x.ExpiresAt)
                .Must(DateGreaterThanOrEqualToday).WithMessage("Voucher expired");

            RuleFor(x => x.Active)
                .Equal(true).WithMessage("Voucher not active");

            RuleFor(x => x.Applied)
                .Equal(false).WithMessage("Voucher already applied");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Voucher unavailable");
        }

        protected static bool DateGreaterThanOrEqualToday(DateTime dataValidade)
        {
            return dataValidade >= DateTime.Now;
        }
    }
}
