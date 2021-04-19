using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CompleteApp.Mvc.Extensions.Identity
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimType, string claimValue) : base(typeof(RequiredClaimFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}
