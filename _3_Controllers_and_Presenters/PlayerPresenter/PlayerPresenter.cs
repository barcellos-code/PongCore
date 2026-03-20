using PlayersInteractor;

namespace PlayerPresenter
{
    internal class PlayerPresenter : IPlayerPresenter
    {
        private readonly IPlayerView _playerView;

        public PlayerPresenter(IPlayerView playerView)
        {
            _playerView = playerView;
        }

        public void DrawPlayer(int playerIndex, int score, int screenWidth, int screenHeight)
        {
            var playerId = playerIndex + 1;
            _playerView.DrawPlayer(playerId, score, screenWidth, screenHeight);
        }
    }
}
