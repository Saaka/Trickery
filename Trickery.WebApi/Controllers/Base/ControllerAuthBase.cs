using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trickery.Auth;
using Trickery.ViewModel.Auth;

namespace Trickery.WebApi.Controllers.Base
{
    public abstract class ControllerAuthBase : ControllerBase
    {
        public ControllerAuthBase(IExternalUserIdProvider userIdProvider,
            IUserDataProvider userDataProvider)
        {
            UserIdProvider = userIdProvider;
            UserDataProvider = userDataProvider;
        }

        protected string GetExternalUserId()
        {
            return UserIdProvider.GetUserId(HttpContext);
        }

        protected async Task<UserData> GetUserData()
        {
            var externalId = UserIdProvider.GetUserId(HttpContext);

            return await UserDataProvider.GetUserData(externalId);
        }

        protected IExternalUserIdProvider UserIdProvider { get; }
        protected IUserDataProvider UserDataProvider { get; }
    }
}
