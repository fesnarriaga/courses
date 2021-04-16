using CompleteApp.Business.Models;
using FluentValidation;
using FluentValidation.Results;

namespace CompleteApp.Business.Services
{
    public abstract class BaseService
    {
        protected void Notify(string message)
        {
            // raise event
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected bool Validate<TV, TE>(TV validator, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validationResult = validator.Validate(entity);

            if (validationResult.IsValid)
                return true;

            Notify(validationResult);

            return false;
        }
    }
}
