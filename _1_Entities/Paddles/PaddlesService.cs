using System;
using System.Collections.Generic;

namespace Paddles
{
    internal class PaddlesService : IPaddlesService
    {
        public int NumberOfPaddles => _paddles.Count;

        private readonly List<Paddle> _paddles = new List<Paddle>();

        public void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth,
            int stageHeight)
        {
            if (numberOfPaddles < 2)
                throw new InvalidOperationException("There must be at least 2 paddles.");

            var firstXPos = 1;
            var lastXPos = stageWidth - 2;
            var deltaX = (lastXPos - firstXPos) / (numberOfPaddles - 1);
            var actualPaddleSize = Math.Min(stageHeight, paddleSize);
            var yPos = (stageHeight / 2) - (actualPaddleSize / 2);

            _paddles.Add(new Paddle(actualPaddleSize, firstXPos, yPos, stageHeight));

            for (var i = 1; i < numberOfPaddles - 1; i++)
            {
                var xPos = firstXPos + deltaX * i;
                _paddles.Add(new Paddle(actualPaddleSize, xPos, yPos, stageHeight));
            }

            _paddles.Add(new Paddle(actualPaddleSize, lastXPos, yPos, stageHeight));
        }

        public IPaddle GetPaddle(int index)
        {
            if (NumberOfPaddles == 0)
                throw new InvalidOperationException("Paddles have not been created.");

            if (index < 0 || index >= NumberOfPaddles)
                throw new IndexOutOfRangeException(nameof(index));

            return _paddles[index];
        }

        public void Dispose()
            => _paddles.Clear();
    }
}
