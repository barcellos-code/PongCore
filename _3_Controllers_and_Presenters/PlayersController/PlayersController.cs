using PlayersInteractor;

namespace PlayersController
{
    internal class PlayersController : IPlayersController
    {
        private readonly IPlayersInteractor _playersInteractor;

        public PlayersController(IPlayersInteractor playersInteractor)
        {
            _playersInteractor = playersInteractor;
        }

        public void CreatePlayers(int numberOfPlayers, int screenWidth, int screenHeight)
            => _playersInteractor.CreatePlayers(numberOfPlayers, screenWidth, screenHeight);
    
        public void BindGoalEvents()
            => _playersInteractor.BindGoalEvents();
    }
}
