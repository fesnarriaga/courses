using CompleteApp.Business.Notifications;
using System.Collections.Generic;

namespace CompleteApp.Business.Interfaces.Notifications
{
    public interface INotificator
    {
        bool HasNotifications();
        IList<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
