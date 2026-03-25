using Ball;
using BallInteractor;
using Match;
using MatchInteractor;
using Microsoft.Extensions.DependencyInjection;
using Players;
using PlayersInteractor;
using Stage;
using StageInteractor;

namespace UseCasesTests
{
    [TestClass]
    public class MatchIntegrationTests
    {
        private static IBallInteractor? _ballInteractor;
        private static IMatchInteractor? _matchInteractor;
        private static IPlayersInteractor? _playersInteractor;
        private static IStageInteractor? _stageInteractor;
        private static IBallService? _ballService;
        private static IMatchService? _matchService;
        private static IPlayersService? _playersService;
        private static IStageService? _stageService;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
            _matchInteractor = TestContainer.ServiceProvider.GetService<IMatchInteractor>();
            _playersInteractor = TestContainer.ServiceProvider.GetService<IPlayersInteractor>();
            _stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
            _ballService = TestContainer.ServiceProvider.GetService<IBallService>();
            _matchService = TestContainer.ServiceProvider.GetService<IMatchService>();
            _playersService = TestContainer.ServiceProvider.GetService<IPlayersService>();
            _stageService = TestContainer.ServiceProvider.GetService<IStageService>();
        }

        [TestInitialize]
        public void TestSetup()
        {
            _ballService?.Dispose();
            _matchService?.Dispose();
            _playersService?.Dispose();
            _stageService?.Dispose();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _ballService?.Dispose();
            _matchService?.Dispose();
            _playersService?.Dispose();
            _stageService?.Dispose();
        }

        [TestMethod]
        public void TestMatchEnd()
        {
            // Arrange
            var stageWidth = 5;
            var stageHeight = 20;
            _stageInteractor?.CreateStage(stageWidth, stageHeight);
            var numberOfPlayers = 2;
            var winningScoreValue = 1;
            _playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
            var ballInitialDirX = 1;
            var ballInitialDirY = 1;
            _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballInitialDirX, ballInitialDirY);
            _playersInteractor?.BindGoalEvents();
            _matchInteractor?.CreateMatch(winningScoreValue, stageWidth, stageHeight);
            _matchInteractor?.BindScoreEvents();

            var expectedMatchOngoingState = false;

            // Act
            var match = _matchService?.GetMatch();
            match?.StartMatch();
            for (var i = 1; i <= 3; i++)
                _ballInteractor?.MoveBall();
            var actualMatchOngoingState = match?.IsOngoing;

            // Assert
            Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);

            // Arrange
            _matchService?.Dispose();
            _ballService?.Dispose();
            _playersService?.Dispose();

            numberOfPlayers = 5;
            winningScoreValue = 3;

            expectedMatchOngoingState = false;

            // Act
            _playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
            _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballInitialDirX, ballInitialDirY);
            _playersInteractor?.BindGoalEvents();
            _matchInteractor?.CreateMatch(winningScoreValue, stageWidth, stageHeight);
            _matchInteractor?.BindScoreEvents();
            match = _matchService?.GetMatch();
            match?.StartMatch();

            // Act
            for (var i = 1; i <= 15; i++)
                _ballInteractor?.MoveBall();
            actualMatchOngoingState = match?.IsOngoing;

            // Assert
            Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);
        }
    }
}
