using CompleteApp.Business.Models;
using CompleteApp.Business.Validators;
using FluentValidation;

namespace CompleteApp.Business.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(2, 100).WithMessage("{PropertyName} must have between {MinLength} and {MaxLength} characters");

            When(x => x.SupplierType == SupplierType.Person, () =>
            {
                RuleFor(x => x.Document.Length).Equal(CpfValidator.DocumentSize)
                    .WithMessage("Document must have {ComparisonValue} characters");
                RuleFor(x => CpfValidator.Validate(x.Document)).Equal(true)
                    .WithMessage("Invalid document");
            });

            When(x => x.SupplierType == SupplierType.Company, () =>
            {
                RuleFor(x => x.Document.Length).Equal(CnpjValidator.DocumentSize)
                    .WithMessage("Document must have {ComparisonValue} characters");
                RuleFor(x => CnpjValidator.Validate(x.Document)).Equal(true)
                    .WithMessage("Invalid document");
            });
        }
    }
}