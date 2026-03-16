namespace Ball
{
    internal class BallService : IBallService
    {
        private Ball? _ball;

        public void CreateBall(int stageWidth, int stageHeight, int directionX, int directionY)
        {
            var posX = stageWidth / 2;
            var posY = stageHeight / 2;
            _ball = new(posX, posY, directionX, directionY, stageWidth);
        }

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
