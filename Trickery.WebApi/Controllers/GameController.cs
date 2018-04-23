using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trickery.Infrastructure;
using Trickery.ViewModel.Game;
using Trickery.WebApi.Config.Auth;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerAuthBase
    {
        private readonly IGuidProvider guidProvider;

        public GameController(IUserContextDataProvider userContextDataProvider,
            IGuidProvider guidProvider) 
            : base(userContextDataProvider)
        {
            this.guidProvider = guidProvider;
        }

        [HttpPost]
        [Authorize]
        [Route("create")]
        public async Task<CreateGameResult> CreateGame(CreateGameRequest request)
        {
            string gameId = guidProvider.CreateGuid();

            return new CreateGameResult
            {
                GameGuid = gameId
            };
        }
    }
}
