using System;

namespace Match
{
    internal class Match : IMatch
    {
        public bool IsOngoing { get; private set; }
        public event Action<int>? OnMatchEnded;

        private readonly int _winningScoreValue;

        public Match(int winningScoreValue)
        {
            _winningScoreValue = winningScoreValue;
        }

        public void StartMatch()
        {
            if (IsOngoing)
                throw new InvalidOperationException("This match is already ongoing");

            IsOngoing = true;
        }

        public void TryEndMatch(int playerIndex, int score)
        {
            if (score >= _winningScoreValue)
                EndMatch(playerIndex);
        }

        private void EndMatch(int playerIndex)
        {
            IsOngoing = false;
            OnMatchEnded?.Invoke(playerIndex);
        }
    }
}
