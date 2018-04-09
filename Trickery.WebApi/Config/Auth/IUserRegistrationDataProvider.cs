using Microsoft.AspNetCore.Http;
using Trickery.ViewModel.Auth;

namespace Trickery.WebApi.Config.Auth
{
    public interface IUserRegistrationDataProvider
    {
        UserRegistrationData GetUserData(HttpContext context);
    }
}
