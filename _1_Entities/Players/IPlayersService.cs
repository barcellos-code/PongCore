namespace Players
{
    public interface IPlayersService : IDisposable
    {
        int NumberOfPlayers { get; }
        void CreatePlayers(int numberOfPlayers);
        IPlayer GetPlayer(int index);
    }
}
