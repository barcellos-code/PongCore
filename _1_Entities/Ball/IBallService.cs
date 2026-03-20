using System;

namespace Ball
{
    public interface IBallService : IDisposable
    {
        void CreateBall(int posX, int posY, int directionX, int directionY);
        IBall GetBall();
    }
}
