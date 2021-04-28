using CompleteApp.Business.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CompleteApp.Api.Extensions.Auth
{
    public class AppUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Name => _httpContextAccessor.HttpContext?.User.Identity?.Name;

        public Guid GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User.GetUserId();

            return userId != null && IsAuthenticated() ? Guid.Parse(userId) : Guid.Empty;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _httpContextAccessor.HttpContext?.User.GetUserEmail() : string.Empty;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User.Identity != null &&
                   _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool HasHole(string role)
        {
            return _httpContextAccessor.HttpContext?.User.Identity != null &&
                   _httpContextAccessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetIdentityClaims()
        {
            return _httpContextAccessor.HttpContext?.User.Claims;
        }
    }
}
