using CompleteApp.Business.Models;
using FluentValidation;

namespace CompleteApp.Business.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 200).WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 200).WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 200).WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 200).WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 200).WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 200).WithMessage("{PropertyName} must have {MaxLength} characters");
        }
    }
}
