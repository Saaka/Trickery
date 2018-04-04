using Microsoft.IdentityModel.Tokens;

namespace Trickery.WebApi.Config.Auth.Google
{
    public class SecurityTokenInvalidDomainException : SecurityTokenValidationException
    {
        public SecurityTokenInvalidDomainException(string message) : base(message)
        {
        }

        public string InvalidDomain { get; set; }
    }
}
