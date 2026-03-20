using System;
using System.Collections.Generic;

namespace Players
{
    internal class PlayersService : IPlayersService, IDisposable
    {
        public int NumberOfPlayers => _players.Count;

        private readonly List<Player> _players = new List<Player>();

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
