using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace CompleteApp.Api.Extensions
{
    public class RequiredClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequiredClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.User.Identity == null)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorization.ValidateUserClaims(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
