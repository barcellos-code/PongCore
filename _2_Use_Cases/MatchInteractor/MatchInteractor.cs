using Match;
using Players;

namespace MatchInteractor;

internal class MatchInteractor : IMatchInteractor
{
    public event Action? OnMatchEnded;

    private readonly IMatchService _matchService;
    private readonly IPlayersService _playersService;
    private readonly IMatchPresenter? _matchPresenter;

    private int _screenWidth;
    private int _screenHeight;

    public MatchInteractor(IMatchService matchService, IPlayersService playersService, IMatchPresenter matchPresenter)
    {
        _matchService = matchService;
        _playersService = playersService;
        _matchPresenter = matchPresenter;
    }

    public MatchInteractor(IMatchService matchService, IPlayersService playersService)
    {
        _matchService = matchService;
        _playersService = playersService;
    }

    public void CreateMatch(int winningScoreValue, int screenWidth, int screenHeight)
    {
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;

        _matchService.CreateMatch(winningScoreValue);
        BindMatchEndedEvent(_matchService.GetMatch());
    }

    private void BindMatchEndedEvent(IMatch match)
        => match.OnMatchEnded += OnMatchEnd;
    
    public void StartMatch()
        => _matchService.GetMatch().StartMatch();

    public void BindScoreEvents()
    {
        for (var i = 0; i < _playersService.NumberOfPlayers; i++)
        {
            var player = _playersService.GetPlayer(i);
            player.OnScoreUpdated += OnPlayerScoreUpdated;
        }
    }

    private void OnPlayerScoreUpdated(IPlayer player)
    {
        var match = _matchService.GetMatch();
        match.TryEndMatch(player.Index, player.Score);
    }

    private void OnMatchEnd(int winningPlayerIndex)
    {
        _matchPresenter?.DrawMatchEnded(winningPlayerIndex, _screenWidth, _screenHeight);
        OnMatchEnded?.Invoke();
    }
}
