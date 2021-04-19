using CompleteApp.Business.Interfaces.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompleteApp.Mvc.Extensions.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificator _notificator;

        public SummaryViewComponent(INotificator notificator)
        {
            _notificator = notificator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notificator.GetNotifications());

            notifications.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x.Message));

            return View();
        }
    }
}
