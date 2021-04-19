using FluentValidation;

namespace CompleteApp.Business.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(3, 200)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(3, 1000)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");
        }
    }
}
