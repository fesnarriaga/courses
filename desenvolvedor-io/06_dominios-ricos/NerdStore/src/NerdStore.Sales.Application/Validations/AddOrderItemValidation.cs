using FluentValidation;
using NerdStore.Sales.Application.Commands;
using System;

namespace NerdStore.Sales.Application.Validations
{
    public class AddOrderItemValidation : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemValidation()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("ProductName is required");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(x => x.Quantity)
                .LessThanOrEqualTo(15).WithMessage("Quantity must be less than or equal 15");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be grater than 0");

            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage("CustomerId is required");

            RuleFor(x => x.ProductId)
                .NotEqual(Guid.Empty).WithMessage("ProductId is required");
        }
    }
}
