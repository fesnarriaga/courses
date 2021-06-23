using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Messages.Notifications;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notifications.GetNotifications());

            notifications.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x.Value));

            return View();
        }
    }
}
