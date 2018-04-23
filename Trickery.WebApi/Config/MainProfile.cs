using AutoMapper;
using Trickery.Commands.Game;
using Trickery.ViewModel.Game;

namespace Trickery.WebApi.Config
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<CreateGameRequest, CreateGameCommand>();
        }
    }
}
