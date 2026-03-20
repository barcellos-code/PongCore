namespace PlayersInteractor
{
    public interface IPlayersInteractor
    {
        void CreatePlayers(int numberOfPlayers, int screenWidth, int screenHeight);
        void BindGoalEvents();
    }
}
