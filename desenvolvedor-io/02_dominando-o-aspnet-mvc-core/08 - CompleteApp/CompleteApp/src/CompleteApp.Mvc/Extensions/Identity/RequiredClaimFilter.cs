using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Security.Claims;

namespace CompleteApp.Mvc.Extensions.Identity
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
                throw new ArgumentNullException(nameof(context.HttpContext.User.Identity));

            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    area = "Identity",
                    page = "/Account/Login",
                    returnUrl = context.HttpContext.Request.Path.ToString()
                }));

                return;
            }

            if (!CustomAuthorization.ValidateUserClaims(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
