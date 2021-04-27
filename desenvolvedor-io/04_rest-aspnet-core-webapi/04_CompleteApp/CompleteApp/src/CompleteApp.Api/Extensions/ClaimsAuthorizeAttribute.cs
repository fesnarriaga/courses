using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompleteApp.Api.Extensions
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimType, string claimValue) : base(typeof(RequiredClaimFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}
