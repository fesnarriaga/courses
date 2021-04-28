using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CompleteApp.Business.Interfaces.Auth
{
    public interface IUser
    {
        string Name { get; }

        Guid GetUserId();

        string GetUserEmail();

        bool IsAuthenticated();

        bool HasHole(string role);

        IEnumerable<Claim> GetIdentityClaims();
    }
}
