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

        [TestMethod]
        public void TestPlayersScoreIncrement()
        {
            // Arrange
            _playersService?.Dispose();
            _ballService?.Dispose();
            var numberOfPlayers = 1;
            var stageWidth = 20;
            var stageHeight = 5;
            var ballDirX = 1;
            var ballDirY = 1;
            _playersService?.CreatePlayers(numberOfPlayers);
            _ballService?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
            _playersService?.BindGoalEvents();
            var ball = _ballService?.GetBall();
            var expectedScoreValue = 1;

            // Act
            for (var i = 1; i <= 10; i++)
                ball?.Move();
            var actualScoreValue = _playersService?.GetPlayer(0).Score;

            // Assert
            Assert.AreEqual(expectedScoreValue, actualScoreValue);

            // Arrange
            expectedScoreValue = 1;
            
            // Act
            for (var i = 1; i <= 11; i++)
                ball?.Move();
            actualScoreValue = _playersService?.GetPlayer(0).Score;

            // Assert
            Assert.AreEqual(expectedScoreValue, actualScoreValue);

            // Arrange
            expectedScoreValue = 2;

            // Act
            for (var i = 1; i <= 10; i++)
                ball?.Move();
            actualScoreValue = _playersService?.GetPlayer(0).Score;

            // Assert
            Assert.AreEqual(expectedScoreValue, actualScoreValue);

            // Arrange
            _playersService?.Dispose();
            _ballService?.Dispose();
            numberOfPlayers = 2;
            _playersService?.CreatePlayers(numberOfPlayers);
            _ballService?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
            _playersService?.BindGoalEvents();
            ball = _ballService?.GetBall();
            var expectedPlayerOneScoreValue = 1;
            var expectedPlayerTwoScoreValue = 0;

            // Act
            for (var i = 1; i <= 10; i++)
                ball?.Move();
            var actualPlayerOneScoreValue = _playersService?.GetPlayer(0).Score;
            var actualPlayerTwoScoreValue = _playersService?.GetPlayer(1).Score;

            // Assert
            Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
            Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);

            // Arrange
            expectedPlayerOneScoreValue = 1;
            expectedPlayerTwoScoreValue = 1;

            // Act
            for (var i = 1; i <= 11; i++)
                ball?.Move();
            actualPlayerOneScoreValue = _playersService?.GetPlayer(0).Score;
            actualPlayerTwoScoreValue = _playersService?.GetPlayer(1).Score;

            // Assert
            Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
            Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);

            // Arrange
            expectedPlayerOneScoreValue = 2;
            expectedPlayerTwoScoreValue = 1;

            // Act
            for (var i = 1; i <= 10; i++)
                ball?.Move();
            actualPlayerOneScoreValue = _playersService?.GetPlayer(0).Score;
            actualPlayerTwoScoreValue = _playersService?.GetPlayer(1).Score;

            // Assert
            Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
            Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);

            // Arrange
            _playersService?.Dispose();
            _ballService?.Dispose();
            numberOfPlayers = 5;
            _playersService?.CreatePlayers(numberOfPlayers);
            _ballService?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
            _playersService?.BindGoalEvents();
            ball = _ballService?.GetBall();
            expectedPlayerOneScoreValue = 1;
            expectedPlayerTwoScoreValue = 0;
            var expectedPlayerThreeScoreValue = 0;
            var expectedPlayerFourScoreValue = 0;
            var expectedPlayerFiveScoreValue = 0;

            // Act
            for (var i = 1; i <= 10; i++)
                ball?.Move();
            actualPlayerOneScoreValue = _playersService?.GetPlayer(0).Score;
            actualPlayerTwoScoreValue = _playersService?.GetPlayer(1).Score;
            var actualPlayerThreeScoreValue = _playersService?.GetPlayer(2).Score;
            var actualPlayerFourScoreValue = _playersService?.GetPlayer(3).Score;
            var actualPlayerFiveScoreValue = _playersService?.GetPlayer(4).Score;

            // Assert
            Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
            Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);
            Assert.AreEqual(expectedPlayerThreeScoreValue, actualPlayerThreeScoreValue);
            Assert.AreEqual(expectedPlayerFourScoreValue, actualPlayerFourScoreValue);
            Assert.AreEqual(expectedPlayerFiveScoreValue, actualPlayerFiveScoreValue);

            // Arrange
            expectedPlayerOneScoreValue = 1;
            expectedPlayerTwoScoreValue = 1;
            expectedPlayerThreeScoreValue = 0;
            expectedPlayerFourScoreValue = 0;
            expectedPlayerFiveScoreValue = 0;

            // Act
            for (var i = 1; i <= 11; i++)
                ball?.Move();
            actualPlayerOneScoreValue = _playersService?.GetPlayer(0).Score;
            actualPlayerTwoScoreValue = _playersService?.GetPlayer(1).Score;
            actualPlayerThreeScoreValue = _playersService?.GetPlayer(2).Score;
            actualPlayerFourScoreValue = _playersService?.GetPlayer(3).Score;
            actualPlayerFiveScoreValue = _playersService?.GetPlayer(4).Score;

            // Assert
            Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
            Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);
            Assert.AreEqual(expectedPlayerThreeScoreValue, actualPlayerThreeScoreValue);
            Assert.AreEqual(expectedPlayerFourScoreValue, actualPlayerFourScoreValue);
            Assert.AreEqual(expectedPlayerFiveScoreValue, actualPlayerFiveScoreValue);

            // Arrange
            expectedPlayerOneScoreValue = 2;
            expectedPlayerTwoScoreValue = 1;
            expectedPlayerThreeScoreValue = 0;
            expectedPlayerFourScoreValue = 0;
            expectedPlayerFiveScoreValue = 0;

            // Act
            for (var i = 1; i <= 10; i++)
                ball?.Move();
            actualPlayerOneScoreValue = _playersService?.GetPlayer(0).Score;
            actualPlayerTwoScoreValue = _playersService?.GetPlayer(1).Score;
            actualPlayerThreeScoreValue = _playersService?.GetPlayer(2).Score;
            actualPlayerFourScoreValue = _playersService?.GetPlayer(3).Score;
            actualPlayerFiveScoreValue = _playersService?.GetPlayer(4).Score;

            // Assert
            Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
            Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);
            Assert.AreEqual(expectedPlayerThreeScoreValue, actualPlayerThreeScoreValue);
            Assert.AreEqual(expectedPlayerFourScoreValue, actualPlayerFourScoreValue);
            Assert.AreEqual(expectedPlayerFiveScoreValue, actualPlayerFiveScoreValue);
        }
    }
}
