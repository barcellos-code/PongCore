namespace Match;

internal class MatchService : IMatchService
{
    private Match? _match;

    public void CreateMatch(int winningScoreValue)
        => _match = new(winningScoreValue);

    public IMatch GetMatch()
    {
        if (_match == null)
            throw new InvalidOperationException("No match has been created");
        
        return _match;
    }

    public void Dispose()
        => _match = null;
}
