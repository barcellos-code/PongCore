namespace BallController;

public interface IBallController
{
    void CreateBall(int posX, int posY, int directionX, int directionY);
    void StartBallTick();
}
