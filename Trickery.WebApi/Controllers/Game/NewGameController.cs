using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trickery.Commands.Game;
using Trickery.Infrastructure;
using Trickery.ViewModel.Game;
using Trickery.WebApi.Config.Auth;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Controllers.Game
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewGameController : ControllerAuthBase
    {
        private readonly IGuidProvider guidProvider;
        private readonly IMapper mapper;

        public NewGameController(IUserContextDataProvider userContextDataProvider,
            IGuidProvider guidProvider,
            IMapper mapper) 
            : base(userContextDataProvider)
        {
            this.guidProvider = guidProvider;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("")]
        public async Task<CreateGameResult> CreateGame(CreateGameRequest request)
        {
            string guid = guidProvider.CreateGuid();
            var user = await GetUserDataAsync();

            var command = mapper.Map<CreateGameCommand>(request);
            command.GameGuid = guid;
            command.UserId = user.Id;

            return new CreateGameResult
            {
                GameGuid = guid
            };
        }
    }
}
