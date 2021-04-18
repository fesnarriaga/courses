using CompleteApp.Business.Interfaces.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CompleteApp.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificator _notificator;

        protected BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool ValidOperation()
        {
            return !_notificator.HasNotification();
        }
    }
}
