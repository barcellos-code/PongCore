namespace PaddlesInteractor
{
    public interface IPaddlesInteractor
    {
        void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth, int stageHeight);
        void MovePaddle(int paddleIndex, PaddleMovementDirection direction);
    }
}
