using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace IdentityExample.Extensions
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Value { get; }

        public CustomAuthorizationRequirement(string value)
        {
            Value = value;
        }
    }

    public class CustomAuthorizationRequirementHandler : AuthorizationHandler<CustomAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        {
            if (context.User.HasClaim(claim => claim.Type == "ModulePermission" && claim.Value.Contains(requirement.Value)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
