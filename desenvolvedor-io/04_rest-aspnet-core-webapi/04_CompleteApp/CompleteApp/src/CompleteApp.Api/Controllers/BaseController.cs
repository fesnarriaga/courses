using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace CompleteApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly INotificator _notificator;

        protected BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool IsSuccess()
        {
            return !_notificator.HasNotifications();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsSuccess())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications().Select(x => x.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelStateDictionary)
        {
            if (!modelStateDictionary.IsValid)
                NotifyModelStateError(modelStateDictionary);

            return CustomResponse();
        }

        protected void NotifyError(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected void NotifyModelStateError(ModelStateDictionary modelStateDictionary)
        {
            var errors = modelStateDictionary.Values.SelectMany(x => x.Errors);

            foreach (var error in errors)
            {
                NotifyError(error.Exception == null ? error.ErrorMessage : error.Exception.Message);
            }
        }
    }
}
