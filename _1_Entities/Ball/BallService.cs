using System;

namespace Ball
{
    internal class BallService : IBallService
    {
        private Ball? _ball;

        public void CreateBall(int posX, int posY, int directionX, int directionY)
            => _ball = new Ball(posX, posY, directionX, directionY);

        public void Dispose()
            => _ball = null;

        public IBall GetBall()
        {
            if (_ball == null)
                throw new InvalidOperationException("Ball has not been created.");

            return _ball;
        }
    }
}
