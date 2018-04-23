using Trickery.Common.Enums;

namespace Trickery.ViewModel.Game
{
    public class CreateGameRequest
    {
        public string Name { get; set; }
        public int PlayersCount { get; set; }
        public GameMode GameMode { get; set; }
    }
}
