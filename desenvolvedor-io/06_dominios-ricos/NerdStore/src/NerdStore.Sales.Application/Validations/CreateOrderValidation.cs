using FluentValidation;
using NerdStore.Sales.Application.Commands;
using System;

namespace NerdStore.Sales.Application.Validations
{
    public class CreateOrderValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidation()
        {
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage("CustomerId is required");

            RuleFor(x => x.OrderId)
                .NotEqual(Guid.Empty).WithMessage("OrderId is required");

            RuleFor(x => x.CardName)
                .NotEmpty().WithMessage("CardName is required");

            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("CardNumber is invalid");
                //.CreditCard().WithMessage("CardNumber is invalid");

            RuleFor(x => x.CardExpiresAt)
                .NotEmpty().WithMessage("CardExpiresAt is required");

            RuleFor(x => x.CardCode)
                .Length(3, 4).WithMessage("CardName is invalid");
        }
    }
}
