using StageInteractor;

namespace StagePresenter
{
    internal class StagePresenter : IStagePresenter
    {
        private readonly IStageView _stageVIew;

        public StagePresenter(IStageView stageView)
        {
            _stageVIew = stageView;
        }

        public void DrawStage(int width, int height)
            => _stageVIew.DrawStage(width, height);
    }
}
