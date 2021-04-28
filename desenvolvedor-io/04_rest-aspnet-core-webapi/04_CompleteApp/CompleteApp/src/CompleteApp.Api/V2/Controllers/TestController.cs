using CompleteApp.Api.Controllers;
using CompleteApp.Business.Interfaces.Auth;
using CompleteApp.Business.Interfaces.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompleteApp.Api.V2.Controllers
{
    [AllowAnonymous]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TestController : BaseController
    {
        public TestController(
            INotificator notificator,
            IUser user) : base(notificator, user)
        {
        }

        [HttpGet]
        public string Index()
        {
            return "Hi, I am v2";
        }
    }
}
