using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace CompleteApp.Api.Extensions.Auth
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimType, string claimValue) : base(typeof(RequiredClaimFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}
