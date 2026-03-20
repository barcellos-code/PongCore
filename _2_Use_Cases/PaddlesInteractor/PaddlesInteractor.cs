using Container;
using Paddles;
using System;

namespace PaddlesInteractor
{
    internal class PaddlesInteractor : IPaddlesInteractor
    {
        private readonly IPaddlesService _paddlesService;

        public PaddlesInteractor(IPaddlesService paddlesService)
        {
            _paddlesService = paddlesService;
        }

        public void CreatePaddles(int numberOfPaddles, int paddleSize, int stageWidth, int stageHeight)
        {
            _paddlesService.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
            DrawPaddles();
        }

        public void MovePaddle(int paddleIndex, PaddleMovementDirection direction)
        {
            if (paddleIndex < 0 || paddleIndex >= _paddlesService.NumberOfPaddles)
                throw new IndexOutOfRangeException(nameof(paddleIndex));

            var paddle = _paddlesService.GetPaddle(paddleIndex);

            switch (direction)
            {
                case PaddleMovementDirection.Up:
                    paddle.MoveUp();
                    break;
                case PaddleMovementDirection.Down:
                    paddle.MoveDown();
                    break;
            }

            DrawPaddle(paddle);
        }

        private void DrawPaddles()
        {
            for (var i = 0; i < _paddlesService.NumberOfPaddles; i++)
            {
                var paddle = _paddlesService.GetPaddle(i);
                DrawPaddle(paddle);
            }
        }

        private static void DrawPaddle(IPaddle paddle)
        {
            var paddlePresenter = DependencyContainer.GetService<IPaddlePresenter>();

            if (paddlePresenter is null)
                return;
        
            paddlePresenter.DrawPaddle(paddle.Size, paddle.PositionX, paddle.PositionY);
        }
    }
}
