using CompleteApp.Business.Interfaces.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace CompleteApp.Business.Notifications
{
    public class Notificator : INotificator
    {
        private readonly IList<Notification> _notifications;

        public Notificator()
        {
            _notifications = new List<Notification>();
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public IList<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
