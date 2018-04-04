﻿using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Trickery.WebApi.Config.Auth.Google
{
    public class GoogleJwtSecurityTokenHandler : JwtSecurityTokenHandler
    {
        public GoogleJwtSecurityTokenHandler()
        {
            InboundClaimTypeMap.Clear();
        }

        /// <inheritdoc />
        /// <exception cref="SecurityTokenInvalidDomainException">token 'hd' claim did not match HostedDomain.</exception>
        public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            // The base class should already take care of validating signature, issuer,
            // audience and expiry. We just need to handle the hosted domain validation below.
            var principal = base.ValidateToken(token, validationParameters, out validatedToken);

            if (validationParameters is GoogleTokenValidationParameters googleParameters)
            {
                // No domain specified. Skip validation.
                if (string.IsNullOrEmpty(googleParameters.HostedDomain))
                {
                    return principal;
                }

                var hostedDomain = principal.FindFirst(GoogleClaimTypes.Domain)?.Value;

                if (string.IsNullOrEmpty(hostedDomain))
                {
                    throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidDomainException(LogMessages.IDX10250) { InvalidDomain = null });
                }

                if (!hostedDomain.Equals(googleParameters.HostedDomain, StringComparison.OrdinalIgnoreCase))
                {
                    throw LogHelper.LogExceptionMessage(new SecurityTokenInvalidDomainException(LogMessages.IDX10251) { InvalidDomain = hostedDomain });
                }

                LogInformation(hostedDomain);
            }

            return principal;
        }

        // Just copied over the code from LogHelper.LogInformation
        // instead of pulling in Microsoft.IdentityModel.Logging > 5.2.1
        private static void LogInformation(string hostedDomain)
        {
            if (IdentityModelEventSource.Logger.IsEnabled())
            {
                IdentityModelEventSource.Logger.WriteInformation(LogMessages.IDX10252, hostedDomain);
            }
        }
    }
}
