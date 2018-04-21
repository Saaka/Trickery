using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Trickery.ViewModel.Auth;

namespace Trickery.WebApi.Config.Auth
{
    public interface IUserContextDataProvider
    {
        string GetExternalUserId(HttpContext context);
        Task<UserData> GetUserData(HttpContext context);
    }
}
