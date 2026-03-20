using Ball;
using Container;
using Players;

namespace PlayersInteractor
{
    internal class PlayersInteractor : IPlayersInteractor
    {
        private readonly IPlayersService _playersService;
        private readonly IBallService _ballService;

        private int _screenWidth;
        private int _screenHeight;

        public PlayersInteractor(IPlayersService playersService, IBallService ballService)
        {
            _playersService = playersService;
            _ballService = ballService;
        }

        public void CreatePlayers(int numberOfPlayers, int screenWidth, int screenHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            _playersService.CreatePlayers(numberOfPlayers);
            DrawPlayers();

            BindScoreEvents();
        }

        public void BindGoalEvents()
        {
            for (var i = 0; i < _playersService.NumberOfPlayers; i++)
            {
                var player = _playersService.GetPlayer(i);
                var ball = _ballService.GetBall();
                ball.OnHitGoal += player.TryIncrementScore;
            }
        }
    
        private void BindScoreEvents()
        {
            for (var i = 0; i < _playersService.NumberOfPlayers; i++)
            {
                var player = _playersService.GetPlayer(i);
                player.OnScoreUpdated += OnScoreUpdated;
            }
        }
    
        private void OnScoreUpdated(IPlayer player)
            => DrawPlayer(player, _screenWidth, _screenHeight);
    
        private void DrawPlayers()
        {
            for (var i = 0; i < _playersService.NumberOfPlayers; i++)
            {
                var player = _playersService.GetPlayer(i);
                DrawPlayer(player, _screenWidth, _screenHeight);
            }
        }
    
        private void DrawPlayer(IPlayer player, int screenWidth, int screenHeight)
        {
            var playerPresenter = DependencyContainer.GetService<IPlayerPresenter>();

            if (playerPresenter is null)
                return;

            playerPresenter.DrawPlayer(player.Index, player.Score, screenWidth, screenHeight);
        }
    }
}
