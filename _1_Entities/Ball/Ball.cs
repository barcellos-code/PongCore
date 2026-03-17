namespace Ball
{
    internal class Ball(int posX, int posY, int dirX, int dirY) : IBall
    {
        public int PositionX { get; private set; } = posX;

        public int PositionY { get; private set; } = posY;

        public int DirectionX { get; private set; } = dirX;

        public int DirectionY { get; private set; } = dirY;
        public event Action<int>? OnHitGoal;

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
