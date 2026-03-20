using StageInteractor;

namespace StageController
{
    internal class StageController : IStageController
    {
        private readonly IStageInteractor _stageInteractor;

        public StageController(IStageInteractor stageInteractor)
        {
            _stageInteractor = stageInteractor;
        }

        public void CreateStage(int width, int height)
            => _stageInteractor.CreateStage(width, height);
    }
}
