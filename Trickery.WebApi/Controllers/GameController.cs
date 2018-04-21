using Microsoft.AspNetCore.Mvc;
using Trickery.Auth;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerAuthBase
    {
        public GameController(
            IExternalUserIdProvider userIdProvider,
            IUserDataProvider userDataProvider)
            : base(userIdProvider, userDataProvider)
        {
        }
    }
}
