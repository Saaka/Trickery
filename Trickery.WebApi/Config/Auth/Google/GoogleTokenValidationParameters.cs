using Microsoft.IdentityModel.Tokens;

namespace Trickery.WebApi.Config.Auth.Google
{
    public class GoogleTokenValidationParameters : TokenValidationParameters
    {
        public GoogleTokenValidationParameters()
        {
        }

        protected GoogleTokenValidationParameters(GoogleTokenValidationParameters other) : base(other)
        {
            HostedDomain = other.HostedDomain;
        }

        public string HostedDomain { get; set; }

        public override TokenValidationParameters Clone()
        {
            return new GoogleTokenValidationParameters(this);
        }
    }
}
