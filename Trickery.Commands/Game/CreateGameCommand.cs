using Trickery.Common.Enums;

namespace Trickery.Commands.Game
{
    public class CreateGameCommand
    {
        public string GameGuid { get; set; }
        public string Name { get; set; }
        public int PlayersCount { get; set; }
        public int UserId { get; set; }
        public GameMode GameMode { get; set; }
    }
}
