using System;

namespace Match
{
    public interface IMatch
    {
        bool IsOngoing { get; }
        event Action<int> OnMatchEnded;
        void StartMatch();
        void TryEndMatch(int playerIndex, int score);
    }
}
