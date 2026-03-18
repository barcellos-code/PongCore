namespace Players;

public interface IPlayer
{
    int Index { get; }
    int Score {get; }
    event Action<IPlayer> OnScoreUpdated;
    void TryIncrementScore(int goalIndex);
}
