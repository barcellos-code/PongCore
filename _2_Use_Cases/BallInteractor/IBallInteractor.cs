namespace BallInteractor
{
    public interface IBallInteractor
    {
        void CreateBall(int posX, int posY, int directionX, int directionY);
        void MoveBall();
    }
}
