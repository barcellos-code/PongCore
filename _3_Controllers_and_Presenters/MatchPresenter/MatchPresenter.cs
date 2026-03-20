using MatchInteractor;

namespace MatchPresenter
{
    public class MatchPresenter : IMatchPresenter
    {
        private readonly IMatchView _matchView;

        public MatchPresenter(IMatchView matchView)
        {
            _matchView = matchView;
        }

        public void DrawMatchEnded(int winningPlayerIndex, int screenWidth, int screenHeight)
        {
            var winningPlayerId = winningPlayerIndex + 1;
            _matchView.DrawMatchEnded(winningPlayerId, screenWidth, screenHeight);
        }
    }
}
