namespace MatchInteractor;

public interface IMatchInteractor
{
    event Action OnMatchEnded;
    void CreateMatch(int winningScoreValue, int screenWidth, int screenHeight);
    void StartMatch();
    void BindScoreEvents();
}
