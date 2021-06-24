using FluentValidation;
using NerdStore.Sales.Application.Commands;
using System;

namespace NerdStore.Sales.Application.Validations
{
    public class RemoveOrderItemValidation : AbstractValidator<RemoveOrderItemCommand>
    {
        public RemoveOrderItemValidation()
        {
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage("CustomerId is required");

            RuleFor(x => x.ProductId)
                .NotEqual(Guid.Empty).WithMessage("ProductId is required");
        }
    }
}
