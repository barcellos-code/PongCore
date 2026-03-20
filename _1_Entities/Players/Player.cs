using System;

namespace Players
{
    internal class Player : IPlayer
    {
        public int Index { get; private set; }
        public int Score { get; private set; }
        public event Action<IPlayer>? OnScoreUpdated;

        public Player(int index)
        {
            Index = index;
        }

        public void TryIncrementScore(int goalIndex)
        {
            if (goalIndex != Index)
                return;

            IncrementScore();
        }

        private void IncrementScore()
        {
            Score++;
            OnScoreUpdated?.Invoke(this);
        }
    }
}
