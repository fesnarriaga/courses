using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace CompleteApp.Mvc.Extensions.Identity
{
    public class CustomAuthorization
    {
        public static bool ValidateUserClaims(HttpContext context, string claimType, string claimValue)
        {
            if (context.User.Identity == null)
                throw new ArgumentNullException(nameof(context.User.Identity));

            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(x => x.Type == claimType && x.Value.Contains(claimValue));
        }
    }
}
