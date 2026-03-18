using Ball;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Players;

namespace EntitiesTests
{
    [TestClass]
    public sealed class PlayersTests
    {
        private static IPlayersService? _playersService;
        private static IBallService? _ballService;
        private static IPaddlesService? _paddlesService;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _playersService = TestContainer.ServiceProvider.GetService<IPlayersService>();
            _ballService = TestContainer.ServiceProvider.GetService<IBallService>();
            _paddlesService = TestContainer.ServiceProvider.GetService<IPaddlesService>();
        }

        [TestInitialize]
        public void TestSetup()
        {
            _playersService?.Dispose();
            _ballService?.Dispose();
            _paddlesService?.Dispose();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _playersService?.Dispose();
            _ballService?.Dispose();
            _paddlesService?.Dispose();
        }

        [TestMethod]
        public void TestNumberOfPlayers()
        {
            // Arrange
            _playersService?.Dispose();
            var inputNumberOfPlayers = 0;
            var expectedNumberOfPlayers = 0;

            // Act
            _playersService?.CreatePlayers(inputNumberOfPlayers);
            var actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            inputNumberOfPlayers = 1;
            expectedNumberOfPlayers = 1;

            // Act
            _playersService?.CreatePlayers(inputNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            inputNumberOfPlayers = 2;
            expectedNumberOfPlayers = 2;

            // Act
            _playersService?.CreatePlayers(inputNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);

            // Arrange
            _playersService?.Dispose();
            inputNumberOfPlayers = 5;
            expectedNumberOfPlayers = 5;

            // Act
            _playersService?.CreatePlayers(inputNumberOfPlayers);
            actualNumberOfPlayers = _playersService?.NumberOfPlayers;

            // Assert
            Assert.AreEqual(expectedNumberOfPlayers, actualNumberOfPlayers);
        }

        [TestMethod]
        public void TestInitialPlayerScores()
        {
            // Arrange
            _playersService?.Dispose();
            var numberOfPlayers = 5;
            var expectedScoreValue = 0;

            // Act
            _playersService?.CreatePlayers(numberOfPlayers);

            // Assert
            for (var i = 0; i < _playersService?.NumberOfPlayers; i++)
            {
                var player = _playersService?.GetPlayer(i);
                var actualScoreValue = player?.Score;
                Assert.AreEqual(expectedScoreValue, actualScoreValue);
            }
        }
    }
}
