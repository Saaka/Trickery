using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trickery.Auth;
using Trickery.ViewModel.Auth;
using Trickery.WebApi.Config.Auth;

namespace Trickery.WebApi.Controllers.Base
{
    public abstract class ControllerAuthBase : ControllerBase
    {
        public ControllerAuthBase(IUserContextDataProvider userContextDataProvider)
        {
            UserContextDataProvider = userContextDataProvider;
        }

        protected string GetExternalUserId()
        {
            return UserContextDataProvider.GetExternalUserId(HttpContext);
        }

        protected async Task<UserData> GetUserData()
        {
            return await UserContextDataProvider.GetUserData(HttpContext);
        }
        
        protected IUserContextDataProvider UserContextDataProvider { get; }
    }
}
