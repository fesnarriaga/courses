using CompleteApp.Api.Controllers;
using CompleteApp.Business.Interfaces.Auth;
using CompleteApp.Business.Interfaces.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompleteApp.Api.V1.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0", Deprecated = true)]
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
            return "Hi, I am V1";
        }
    }
}
