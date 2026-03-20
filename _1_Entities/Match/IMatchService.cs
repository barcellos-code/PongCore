using System;

namespace Match
{
    public interface IMatchService : IDisposable
    {
        void CreateMatch(int winningScoreValue);
        IMatch GetMatch();
    }
}
