﻿using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Models;
using CompleteApp.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace CompleteApp.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        protected BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notify(string message)
        {
            _notificator.Handle(new Notification(message));
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
