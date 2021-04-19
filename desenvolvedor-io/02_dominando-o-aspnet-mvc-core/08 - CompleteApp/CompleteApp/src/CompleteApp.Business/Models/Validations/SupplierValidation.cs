using CompleteApp.Business.Validators;
using FluentValidation;

namespace CompleteApp.Business.Models.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")

                .Length(3, 200)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

            When(x => x.SupplierType == SupplierType.Person, () =>
            {
                RuleFor(x => x.Document.Length)
                    .Equal(CpfValidator.Size)
                    .WithMessage("Document must have {ComparisonValue}");

                RuleFor(x => CpfValidator.Validate(x.Document))
                    .Equal(true)
                    .WithMessage("Invalid {PropertyName}");
            });

            When(x => x.SupplierType == SupplierType.Company, () =>
            {
                RuleFor(x => x.Document.Length)
                    .Equal(CnpjValidator.Size)
                    .WithMessage("Document must have {ComparisonValue}");

                RuleFor(x => CnpjValidator.Validate(x.Document))
                    .Equal(true)
                    .WithMessage("Invalid {PropertyName}");
            });
        }
    }
}
