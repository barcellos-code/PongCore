using System;

namespace Stage
{
    internal class StageService : IStageService
    {
        private Stage? _stage;

        public void CreateStage(int width, int height)
        {
            _stage = new Stage(width, height);
        }

        public IStage GetStage()
        {
            if (_stage == null)
                throw new InvalidOperationException("Stage has not been created.");

            return _stage;
        }

        public void Dispose()
            => _stage = null;
    }
}
