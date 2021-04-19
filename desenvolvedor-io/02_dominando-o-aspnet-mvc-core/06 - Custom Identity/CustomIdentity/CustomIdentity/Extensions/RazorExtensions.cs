using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CustomIdentity.Extensions
{
    public static class RazorExtensions
    {
        public static bool HasClaim(this RazorPage page, string claimType, string claimValue)
        {
            return CustomAuthorization.ValidateUserClaims(page.Context, claimType, claimValue);
        }

        public static string ShowIfHasClaim(this RazorPage page, string claimType, string claimValue)
        {
            return CustomAuthorization.ValidateUserClaims(page.Context, claimType, claimValue) ? "" : "disabled";
        }

        public static IHtmlContent ShowIfHasClaim(this IHtmlContent page, HttpContext context, string claimType, string claimValue)
        {
            return CustomAuthorization.ValidateUserClaims(context, claimType, claimValue) ? page : null;
        }
    }
}
