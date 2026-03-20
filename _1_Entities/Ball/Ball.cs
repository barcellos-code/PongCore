using System;

namespace Ball
{
    internal class Ball : IBall
    {
        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public int DirectionX { get; private set; }

        public int DirectionY { get; private set; }
        public event Action<int>? OnHitGoal;

        public Ball(int posX, int posY, int dirX, int dirY)
        {
            PositionX = posX;
            PositionY = posY;
            DirectionX = dirX;
            DirectionY = dirY;
        }

        public void Move()
        {
            PositionX += DirectionX;
            PositionY += DirectionY;
        }

        public void InvertDirectionX()
            => DirectionX *= -1;
        
        public void InvertDirectionY()
            => DirectionY *= -1;
        
        public void SetPosition(int posX, int posY)
        {
            PositionX = posX;
            PositionY = posY;
        }

        public void InvokeOnHitGoal(int goalIndex)
            => OnHitGoal?.Invoke(goalIndex);
    }
}
