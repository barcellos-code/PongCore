namespace PlayersController
{
    public interface IPlayersController
    {
        void CreatePlayers(int numberOfPlayers, int screenWidth, int screenHeight);
        void BindGoalEvents();
    }
}
