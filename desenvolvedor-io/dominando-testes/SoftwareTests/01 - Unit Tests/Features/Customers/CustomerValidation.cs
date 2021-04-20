using FluentValidation;
using System;

namespace Features.Customers
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 150).WithMessage("{PropertyName} must be between {MaxLength} and {MinLength} characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 150).WithMessage("{PropertyName} must be between {MaxLength} and {MinLength} characters");

            RuleFor(x => x.Birth)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("{PropertyName} must have 18 years old");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty);
        }

        public static bool HaveMinimumAge(DateTime birth)
        {
            return birth <= DateTime.Now.AddYears(-18);
        }
    }
}