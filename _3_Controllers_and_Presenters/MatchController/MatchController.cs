using MatchInteractor;

namespace MatchController
{
    internal class MatchController : IMatchController
    {
        private readonly IMatchInteractor _matchInteractor;

        public MatchController(IMatchInteractor matchInteractor)
        {
            _matchInteractor = matchInteractor;
        }

        public void CreateMatch(int winningScoreValue, int screenWidth, int screenHeight)
            => _matchInteractor.CreateMatch(winningScoreValue, screenWidth, screenHeight);
    
        public void StartMatch()
            => _matchInteractor.StartMatch();
    
        public void BindScoreEvents()
            => _matchInteractor.BindScoreEvents();
    }
}
