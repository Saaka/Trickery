using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Trickery.Auth;
using Trickery.ViewModel.Auth;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Config.Auth
{
    public class UserContextDataProvider : IUserContextDataProvider
    {
        protected IExternalUserIdProvider userIdProvider { get; }
        protected IUserDataProvider userDataProvider { get; }

        public UserContextDataProvider(IExternalUserIdProvider userIdProvider,
            IUserDataProvider userDataProvider)
        {
            this.userIdProvider = userIdProvider;
            this.userDataProvider = userDataProvider;
        }

        public string GetExternalUserId(HttpContext context)
        {
            return userIdProvider.GetUserId(context);
        }

        public async Task<UserData> GetUserData(HttpContext context)
        {
            var externalId = userIdProvider.GetUserId(context);

            return await userDataProvider.GetUserData(externalId);
        }
    }
}
