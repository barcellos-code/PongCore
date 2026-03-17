using Ball;
using Paddles;
using Stage;

namespace BallInteractor;

internal class BallInteractor : IBallInteractor
{
    private readonly IBallService _ballService;
    private readonly IBallPresenter? _ballPresenter;
    private readonly IStageService _stageService;
    private readonly IPaddlesService _paddlesService;

    public BallInteractor(IBallService ballService, IBallPresenter ballPresenter, IStageService stageService, IPaddlesService paddlesService)
    {
        _ballService = ballService;
        _ballPresenter = ballPresenter;
        _stageService = stageService;
        _paddlesService = paddlesService;
    }

    public BallInteractor(IBallService ballService, IStageService stageService, IPaddlesService paddlesService)
    {
        _ballService = ballService;
        _stageService = stageService;
        _paddlesService = paddlesService;
    }

    public void CreateBall(int posX, int posY, int directionX, int directionY)
        => _ballService.CreateBall(posX, posY, directionX, directionY);

    public void MoveBall()
    {
        var ball = _ballService.GetBall();
        var stage = _stageService.GetStage();

        BounceBallOffPaddles(ball);
        ball.Move();
        BounceBallOffStageBounds(ball, stage);
        ResetBallBackToStageCenter(ball, stage);

        _ballPresenter?.DrawBall(ball.PositionX, ball.PositionY);
    }

    private void BounceBallOffPaddles(IBall ball)
    {
        for (var i = 0; i < _paddlesService.NumberOfPaddles; i++)
        {
            var paddle = _paddlesService.GetPaddle(i);

            var isBallTouchingPaddleFromTheRight
                = ball.DirectionX < 0 && ball.PositionX == paddle?.PositionX + 1;
            
            var isBallTouchingPaddleFromTheLeft
                = ball.DirectionX > 0 && ball.PositionX == paddle?.PositionX - 1;
            
            var isBallVerticallyAlignedWithPaddle
                = ball.PositionY >= paddle?.PositionY
                    && ball.PositionY <= paddle?.PositionY + paddle?.Size;
            
            if (isBallVerticallyAlignedWithPaddle
                && (isBallTouchingPaddleFromTheRight
                    || isBallTouchingPaddleFromTheLeft))
            {
                ball.InvertDirectionX();
                return;
            }
        }
    }

    private static void BounceBallOffStageBounds(IBall ball, IStage stage)
    {
        if (ball.PositionY >= stage.Height - 1 || ball.PositionY <= 0)
            ball.InvertDirectionY();
    }

    private static void ResetBallBackToStageCenter(IBall ball, IStage stage)
    {
        var hitLeftGoal = ball.PositionX < 0;
        var hitRightGoal = ball.PositionX >= stage.Width;

        if (hitLeftGoal || hitRightGoal)
        {
            ball.SetPosition(stage.Width / 2, stage.Height / 2);
            ball.InvertDirectionX();
            ball.InvokeOnHitGoal(hitRightGoal ? 0 : 1);
        }
    }
}
