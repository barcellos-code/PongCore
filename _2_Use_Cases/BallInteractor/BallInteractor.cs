using Ball;
using Stage;

namespace BallInteractor;

internal class BallInteractor : IBallInteractor
{
    public BallInteractor(IBallService ballService, IBallPresenter ballPresenter, IStageService stageService)
    {
        _ballService = ballService;
        _ballPresenter = ballPresenter;
        _stageService = stageService;
    }

    public BallInteractor(IBallService ballService, IStageService stageService)
    {
        _ballService = ballService;
        _stageService = stageService;
    }

    private readonly IBallService _ballService;
    private readonly IBallPresenter? _ballPresenter;
    private readonly IStageService _stageService;

    public void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY)
        => _ballService.CreateBall(stageWidth, stageHeight, directionX, directionY);

    public void MoveBall()
    {
        var ball = _ballService.GetBall();
        ball.Move();

        BounceBallOffStageBounds();

        _ballPresenter?.DrawBall(ball.PositionX, ball.PositionY);
    }

    private void BounceBallOffStageBounds()
    {
        var ball = _ballService.GetBall();
        var stage = _stageService.GetStage();

        if (ball.PositionY >= stage.Height - 1 || ball.PositionY <= 0)
            ball.InvertDirectionY();
    }
}
