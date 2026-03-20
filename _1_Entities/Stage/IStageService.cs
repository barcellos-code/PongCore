using System;

namespace Stage
{
    public interface IStageService : IDisposable
    {
        void CreateStage(int width, int height);
        IStage GetStage();
    }
}
