using System;

namespace Paddles
{
    internal class Paddle : IPaddle
    {
        public int Size { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        private readonly int _stageHeight;

        public Paddle(int size, int xPos, int yPos, int stageHeight)
        {
            Size = size;
            PositionX = xPos;
            PositionY = yPos;
            _stageHeight = stageHeight;
        }

        public void MoveUp()
            => PositionY = Math.Min(PositionY + 1, _stageHeight - Size - 1);

        public void MoveDown()
            => PositionY = Math.Max(PositionY - 1, 0);
    }
}
