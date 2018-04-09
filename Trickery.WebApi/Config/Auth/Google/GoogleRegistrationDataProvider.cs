using Microsoft.AspNetCore.Http;
using Trickery.ViewModel.Auth;

namespace Trickery.WebApi.Config.Auth.Google
{
    internal class GoogleRegistrationDataProvider : IUserRegistrationDataProvider
    {
        public UserRegistrationData GetUserData(HttpContext context)
        {
            return new UserRegistrationData
            {
                Email = context.User.FindFirst(x=> x.Type == GoogleClaimTypes.Email)?.Value,
                ExternalId = context.User.FindFirst(x=> x.Type == GoogleClaimTypes.Sub)?.Value,
                Name = context.User.FindFirst(x=> x.Type == GoogleClaimTypes.Name)?.Value,
                Picture = context.User.FindFirst(x=> x.Type == GoogleClaimTypes.Picture)?.Value,
            };
        }
    }
}
