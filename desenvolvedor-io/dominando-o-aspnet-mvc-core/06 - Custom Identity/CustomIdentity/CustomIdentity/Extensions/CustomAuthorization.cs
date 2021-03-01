using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Routing;

namespace CustomIdentity.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidateUserClaims(HttpContext context, string claimType, string claimValue)
        {
            return context.User.Identity != null &&
                   context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(claim => claim.Type == claimType && claim.Value.Contains(claimValue));
        }
    }

    public class RequiredClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequiredClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity != null && !context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    area = "Identity",
                    page = "/Account/Login",
                    ReturnUrl = context.HttpContext.Request.Path.ToString()
                }));

                return;
            }

            if (!CustomAuthorization.ValidateUserClaims(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new ForbidResult();
            }
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimType, string claimValue) : base(typeof(RequiredClaimFilter))
        {
            Arguments = new object[]
            {
                new Claim(claimType,claimValue)
            };
        }
    }
}
