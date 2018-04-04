using Microsoft.AspNetCore.Mvc;

namespace Trickery.WebApi.Controllers.Base
{
    public abstract class ControllerAuthBase : ControllerBase
    {
        public ControllerAuthBase(IUserIdProvider userIdProvider)
        {
            UserIdProvider = userIdProvider;
        }

        protected string GetUserId()
        {
            return UserIdProvider.GetUserId(HttpContext);
        }

        protected IUserIdProvider UserIdProvider { get; private set; }
    }
}
