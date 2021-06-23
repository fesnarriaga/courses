using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdStore.WebApp.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notificationHandler;
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid CustomerId = Guid.Parse("4B6C735A-3FC3-4282-98A0-8676A694F6C3");

        protected BaseController(
            INotificationHandler<DomainNotification> notificationHandler,
            IMediatorHandler mediatorHandler)
        {
            _notificationHandler = (DomainNotificationHandler)notificationHandler;
            _mediatorHandler = mediatorHandler;
        }

        protected bool HasErrors()
        {
            return _notificationHandler.HasNotifications();
        }

        protected void AddError(string key, string value)
        {
            _mediatorHandler.PublishNotification(new DomainNotification(key, value));
        }

        protected IEnumerable<string> GetErrorMessages()
        {
            return _notificationHandler.GetNotifications().Select(x => x.Value).ToList();
        }
    }
}
