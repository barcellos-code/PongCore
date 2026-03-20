using BallInteractor;

namespace BallPresenter
{
    internal class BallPresenter : IBallPresenter
    {
        private readonly IBallView _ballView;

        public BallPresenter(IBallView ballView)
        {
            _ballView = ballView;
        }

        public void DrawBall(int posX, int posY)
            => _ballView.DrawBall(posX, posY);
    }
}
