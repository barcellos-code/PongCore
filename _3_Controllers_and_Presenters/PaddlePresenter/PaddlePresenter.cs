using PaddlesInteractor;

namespace PaddlePresenter
{
    internal class PaddlePresenter : IPaddlePresenter
    {
        private readonly IPaddleView _paddleView;

        public PaddlePresenter(IPaddleView paddleView)
        {
            _paddleView = paddleView;
        }

        public void DrawPaddle(int size, int posX, int posY)
            => _paddleView.DrawPaddle(size, posX, posY);
    }
}
