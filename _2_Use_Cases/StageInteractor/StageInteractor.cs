using Stage;

namespace StageInteractor
{
    internal class StageInteractor : IStageInteractor
    {
        public StageInteractor(IStageService stageService, IStagePresenter stagePresenter)
        {
            _stageService = stageService;
            _stagePresenter = stagePresenter;
        }

        public StageInteractor(IStageService stageService)
        {
            _stageService = stageService;
        }

        private readonly IStageService _stageService;
        private readonly IStagePresenter? _stagePresenter;

        public void CreateStage(int width, int height)
        {
            _stageService.CreateStage(width, height);
            var stage = _stageService.GetStage();
            _stagePresenter?.DrawStage(stage.Width, stage.Height);
        }
    }
}
