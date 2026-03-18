namespace Players
{
    internal class Player(int index) : IPlayer
    {
        public int Index { get; private set; } = index;
        public int Score { get; private set; }
        public event Action<IPlayer>? OnScoreUpdated;

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
