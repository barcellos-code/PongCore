using Container;
using Microsoft.Extensions.DependencyInjection;
using Paddles;

namespace Ball
{
    internal class Ball(int posX, int posY, int dirX, int dirY, int stageWidth) : IBall
    {
        public int PositionX { get; private set; } = posX;

        public int PositionY { get; private set; } = posY;

        public int DirectionX { get; private set; } = dirX;

        public int DirectionY { get; private set; } = dirY;
        public event Action<int>? OnHitGoal;

        private readonly int _initialPosX = posX;
        private readonly int _initialPosY = posY;
        private readonly int _stageWidth = stageWidth;

        public void Move()
        {
            BounceOffPaddles();

            PositionX += DirectionX;
            PositionY += DirectionY;

            ResetBackToStageCenter();
        }

        public void InvertDirectionY()
            => DirectionY *= -1;

        private void BounceOffPaddles()
        {
            var paddlesService = DependencyContainer.ServiceProvider?.GetService<IPaddlesService>();
            
            for (var i = 0; i < paddlesService?.NumberOfPaddles; i++)
            {
                var paddle = paddlesService?.GetPaddle(i);

                var isBallTouchingPaddleFromTheRight
                    = DirectionX < 0 && PositionX == paddle?.PositionX + 1;
                
                var isBallTouchingPaddleFromTheLeft
                    = DirectionX > 0 && PositionX == paddle?.PositionX - 1;
                
                var isBallVerticallyAlignedWithPaddle
                    = PositionY >= paddle?.PositionY
                        && PositionY <= paddle?.PositionY + paddle?.Size;
                
                if (isBallVerticallyAlignedWithPaddle
                    && (isBallTouchingPaddleFromTheRight
                        || isBallTouchingPaddleFromTheLeft))
                {
                    DirectionX *= -1;
                    return;
                }
            }
        }

        private void ResetBackToStageCenter()
        {
            var hitLeftGoal = PositionX < 0;
            var hitRightGoal = PositionX >= _stageWidth;

            if (hitLeftGoal || hitRightGoal)
            {
                ResetPosition();
                InvertDirectionX();
                InvokeGoalEvent(hitRightGoal);
                return;
            }

            void ResetPosition()
            {
                PositionX = _initialPosX;
                PositionY = _initialPosY;
            }

            void InvertDirectionX()
                => DirectionX *= -1;

            void InvokeGoalEvent(bool hitRightGoal)
            {
                var goalIndex = hitRightGoal ? 0 : 1;
                OnHitGoal?.Invoke(goalIndex);
            }
        }
    }
}
