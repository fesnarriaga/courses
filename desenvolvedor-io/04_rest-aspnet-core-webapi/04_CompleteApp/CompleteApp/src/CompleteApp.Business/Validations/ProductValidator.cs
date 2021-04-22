using CompleteApp.Business.Models;
using FluentValidation;

namespace CompleteApp.Business.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 200).WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 1000).WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");
        }
    }
}
