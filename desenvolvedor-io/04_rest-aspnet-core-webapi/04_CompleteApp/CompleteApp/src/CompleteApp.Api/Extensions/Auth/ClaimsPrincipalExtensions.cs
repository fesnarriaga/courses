using System;
using System.Security.Claims;

namespace CompleteApp.Api.Extensions.Auth
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentException(nameof(claimsPrincipal));

            var claim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

            return claim != null ? claim.Value : string.Empty;
        }

        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                throw new ArgumentException(nameof(claimsPrincipal));

            var claim = claimsPrincipal.FindFirst(ClaimTypes.Email);

            return claim != null ? claim.Value : string.Empty;
        }
    }
}
