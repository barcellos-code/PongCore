using BallInteractor;
using MatchInteractor;
using TickService;

namespace BallController;

internal class BallController(IBallInteractor ballInteractor, IMatchInteractor matchInteractor, ITickService tickService) : IBallController
{
    private readonly IBallInteractor _ballInteractor = ballInteractor;
    private readonly IMatchInteractor  _matchInteractor = matchInteractor;
    private readonly ITickService _tickService = tickService;

    public void CreateBall(int posX, int posY, int directionX, int directionY)
    {
        _ballInteractor.CreateBall(posX, posY, directionX, directionY);
    }

    public void StartBallTick()
    {
        _tickService.OnTick += MoveBall;
        BindMatchEndedEvent();
    }

    private void BindMatchEndedEvent()
        => _matchInteractor.OnMatchEnded += StopBallTick;

    private void StopBallTick()
    {
        _tickService.OnTick -= MoveBall;
        UnbindMatchEndedEvent();
    }

    private void UnbindMatchEndedEvent()
        => _matchInteractor.OnMatchEnded -= StopBallTick;

    private void MoveBall()
        => _ballInteractor.MoveBall();
}
