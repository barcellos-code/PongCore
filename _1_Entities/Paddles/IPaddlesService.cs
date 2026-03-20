using System;

namespace Paddles
{
    public interface IPaddlesService : IDisposable
    {
        int NumberOfPaddles { get; }
        void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth, int stageHeight);
        IPaddle GetPaddle(int index);
    }
}
