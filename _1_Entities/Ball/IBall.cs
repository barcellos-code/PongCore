namespace Ball
{
    public interface IBall
    {
        int PositionX { get; }
        int PositionY { get; }
        int DirectionX { get; }
        int DirectionY { get; }
        event Action<int> OnHitGoal;
        void Move();
        void InvertDirectionX();
        void InvertDirectionY();
        void SetPosition(int posX, int posY);
        void InvokeOnHitGoal(int goalIndex);
    }
}
