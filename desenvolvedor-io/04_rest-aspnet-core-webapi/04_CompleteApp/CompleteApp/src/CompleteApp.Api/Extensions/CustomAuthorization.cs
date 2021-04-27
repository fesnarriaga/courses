using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CompleteApp.Api.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidateUserClaims(HttpContext httpContext, string claimType, string claimValue)
        {
            if (httpContext.User.Identity == null)
                return false;

            return httpContext.User.Identity.IsAuthenticated &&
                   httpContext.User.Claims.Any(x => x.Type == claimType && x.Value.Contains(claimValue));
        }
    }
}
