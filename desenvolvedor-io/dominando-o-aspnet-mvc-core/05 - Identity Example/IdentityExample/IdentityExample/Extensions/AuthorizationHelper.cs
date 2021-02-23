using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace IdentityExample.Extensions
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Requirement { get; }

        public CustomAuthorizationRequirement(string requirement)
        {
            Requirement = requirement;
        }
    }
}
