using System.Collections.Generic;

namespace CompleteApp.Business.Interfaces.Notifications
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
