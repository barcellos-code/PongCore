namespace Players
{
    internal class PlayersService : IPlayersService, IDisposable
    {
        private const int MaxScoringPlayersAmount = 2;

        public int NumberOfPlayers => _players.Count;

        private readonly List<Player> _players = [];

        public void CreatePlayers(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player(i);
                _players.Add(player);
            }
        }

        public IPlayer GetPlayer(int index)
        {
            if (NumberOfPlayers == 0)
                throw new InvalidOperationException("Players have not been created.");
            
            if (index < 0 || index >= NumberOfPlayers)
                throw new IndexOutOfRangeException();
            
            return _players[index];
        }

        public void Dispose()
            => _players.Clear();
    }
}
