using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Trickery.WebApi.Controllers.Base
{
    public class GoogleUserIdProvider : IExternalUserIdProvider
    {
        public string GetUserId(HttpContext context)
        {
            if (context.User == null || context.User.Claims == null || !context.User.HasClaim(x => x.Type == JwtRegisteredClaimNames.Sub))
                throw new InvalidOperationException("Can't check current user claims");

            return context.User.FindFirst(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
        }
    }
}
