namespace MatchController;

public interface IMatchController
{
    void CreateMatch(int winningScoreValue, int screenWidth, int screenHeight);
    void StartMatch();
    void BindScoreEvents();
}
