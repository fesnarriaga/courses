using FluentValidation;
using NerdStore.Sales.Application.Commands;
using System;

namespace NerdStore.Sales.Application.Validations
{
    public class UpdateOrderItemValidation : AbstractValidator<UpdateOrderItemCommand>
    {
        public UpdateOrderItemValidation()
        {
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage("CustomerId is required");

            RuleFor(x => x.ProductId)
                .NotEqual(Guid.Empty).WithMessage("ProductId is required");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(x => x.Quantity)
                .LessThan(15).WithMessage("Quantity must be less than 15");
        }
    }
}