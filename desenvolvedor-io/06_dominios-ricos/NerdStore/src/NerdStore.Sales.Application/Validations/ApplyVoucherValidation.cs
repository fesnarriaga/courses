using FluentValidation;
using NerdStore.Sales.Application.Commands;
using System;

namespace NerdStore.Sales.Application.Validations
{
    public class ApplyVoucherValidation : AbstractValidator<ApplyVoucherCommand>
    {
        public ApplyVoucherValidation()
        {
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage("CustomerId is required");

            RuleFor(x => x.VoucherCode)
                .NotEmpty().WithMessage("VoucherCode is required");
        }
    }
}
