using FluentValidation;

namespace CompleteApp.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(3, 200)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(1, 50)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.Neighborhood)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(3, 100)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(8)
                .WithMessage("{PropertyName} must have {MaxLength} characters");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(3, 200)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(2, 50)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");
        }
    }
}
