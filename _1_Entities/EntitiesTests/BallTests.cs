using Ball;
using Microsoft.Extensions.DependencyInjection;
using Paddles;

namespace EntitiesTests
{
    [TestClass]
    public sealed class BallTests
    {
        private static IBallService? _ballService;
        private static IPaddlesService? _paddlesService;

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            _ballService = TestContainer.ServiceProvider.GetService<IBallService>();
            _paddlesService = TestContainer.ServiceProvider.GetService<IPaddlesService>();
        }

        [TestInitialize]
        public void TestSetup()
        {
            _ballService?.Dispose();
            _paddlesService?.Dispose();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _ballService?.Dispose();
            _paddlesService?.Dispose();
        }

        [TestMethod]
        public void TestBallPlacement()
        {
            // Arrange
            var stageWidth = 3;
            var stageHeight = 3;
            var initialDirectionX = 1;
            var initialDirectionY = 1;
            var expectedBallPosX = 1;
            var expectedBallPosY = 1;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, initialDirectionX,
                initialDirectionY);
            var ball = _ballService?.GetBall();
            var actualBallPosX = ball?.PositionX;
            var actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            stageWidth = 1;
            stageHeight = 1;
            expectedBallPosX = 0;
            expectedBallPosY = 0;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, initialDirectionX,
                initialDirectionY);
            ball = _ballService?.GetBall();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            stageWidth = 5;
            stageHeight = 5;
            expectedBallPosX = 2;
            expectedBallPosY = 2;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, initialDirectionX,
                initialDirectionY);
            ball = _ballService?.GetBall();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            stageWidth = 10;
            stageHeight = 10;
            expectedBallPosX = 5;
            expectedBallPosY = 5;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, initialDirectionX,
                initialDirectionY);
            ball = _ballService?.GetBall();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            stageWidth = 30;
            stageHeight = 15;
            expectedBallPosX = 15;
            expectedBallPosY = 7;
            _ballService?.Dispose();

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, initialDirectionX,
                initialDirectionY);
            ball = _ballService?.GetBall();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);
        }

        [TestMethod]
        public void TestBallInitialDirection()
        {
            // Arrange
            _ballService?.Dispose();
            var stageWidth = 100;
            var stageHeight = 80;
            var inputDirectionX = 1;
            var inputDirectionY = 1;
            var expectedDirectionX = 1;
            var expectedDirectionY = 1;

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, inputDirectionX, inputDirectionY);
            var ball = _ballService?.GetBall();
            var actualDirectionX = ball?.DirectionX;
            var actualDirectionY = ball?.DirectionY;

            // Assert
            Assert.AreEqual(expectedDirectionX, actualDirectionX);
            Assert.AreEqual(expectedDirectionY, actualDirectionY);

            // Arrange
            _ballService?.Dispose();
            inputDirectionX = 1;
            inputDirectionY = -1;
            expectedDirectionX = 1;
            expectedDirectionY = -1;

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, inputDirectionX, inputDirectionY);
            ball = _ballService?.GetBall();
            actualDirectionX = ball?.DirectionX;
            actualDirectionY = ball?.DirectionY;

            // Assert
            Assert.AreEqual(expectedDirectionX, actualDirectionX);
            Assert.AreEqual(expectedDirectionY, actualDirectionY);

            // Arrange
            _ballService?.Dispose();
            inputDirectionX = -1;
            inputDirectionY = 1;
            expectedDirectionX = -1;
            expectedDirectionY = 1;

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, inputDirectionX, inputDirectionY);
            ball = _ballService?.GetBall();
            actualDirectionX = ball?.DirectionX;
            actualDirectionY = ball?.DirectionY;

            // Assert
            Assert.AreEqual(expectedDirectionX, actualDirectionX);
            Assert.AreEqual(expectedDirectionY, actualDirectionY);

            // Arrange
            _ballService?.Dispose();
            inputDirectionX = -1;
            inputDirectionY = -1;
            expectedDirectionX = -1;
            expectedDirectionY = -1;

            // Act
            _ballService?.CreateBall(stageWidth, stageHeight, inputDirectionX, inputDirectionY);
            ball = _ballService?.GetBall();
            actualDirectionX = ball?.DirectionX;
            actualDirectionY = ball?.DirectionY;

            // Assert
            Assert.AreEqual(expectedDirectionX, actualDirectionX);
            Assert.AreEqual(expectedDirectionY, actualDirectionY);
        }

        [TestMethod]
        public void TestBallMovement()
        {
            // Arrange
            _ballService?.Dispose();
            var stageWidth = 100;
            var stageHeight = 80;
            var inputDirectionX = 1;
            var inputDirectionY = 1;
            _ballService?.CreateBall(stageWidth, stageHeight, inputDirectionX, inputDirectionY);
            var ball = _ballService?.GetBall();
            var expectedBallPosX = 51;
            var expectedBallPosY = 41;

            // Act
            ball?.Move();
            var actualBallPosX = ball?.PositionX;
            var actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            expectedBallPosX = 52;
            expectedBallPosY = 42;

            // Act
            ball?.Move();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            expectedBallPosX = 53;
            expectedBallPosY = 43;

            // Act
            ball?.Move();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            expectedBallPosX = 73;
            expectedBallPosY = 63;

            // Act
            for (var i = 1; i <= 20; i++)
                ball?.Move();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            _ballService?.Dispose();
            inputDirectionX = 1;
            inputDirectionY = -1;
            _ballService?.CreateBall(stageWidth, stageHeight, inputDirectionX, inputDirectionY);
            ball = _ballService?.GetBall();
            expectedBallPosX = 60;
            expectedBallPosY = 30;

            // Act
            for (var i = 1; i <= 10; i++)
                ball?.Move();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            _ballService?.Dispose();
            inputDirectionX = -1;
            inputDirectionY = -1;
            _ballService?.CreateBall(stageWidth, stageHeight, inputDirectionX, inputDirectionY);
            ball = _ballService?.GetBall();
            expectedBallPosX = 40;
            expectedBallPosY = 30;

            // Act
            for (var i = 1; i <= 10; i++)
                ball?.Move();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);
        }

        [TestMethod]
        public void TestBallReset()
        {
            // Arrange
            _ballService?.Dispose();
            var stageWidth = 11;
            var stageHeight = 100;
            var directionX = 1;
            var directionY = 1;
            _ballService?.CreateBall(stageWidth, stageHeight, directionX, directionY);
            var ball = _ballService?.GetBall();
            var expectedBallPosX = 5;
            var expectedBallPosY = 50;

            // Act
            for (var i = 1; i <= 6; i++)
                ball?.Move();
            var actualBallPosX = ball?.PositionX;
            var actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);

            // Arrange
            _ballService?.Dispose();
            stageWidth = 20;
            stageHeight = 5;
            directionX = -1;
            directionY = -1;
            _ballService?.CreateBall(stageWidth, stageHeight, directionX, directionY);
            ball = _ballService?.GetBall();
            expectedBallPosX = 10;
            expectedBallPosY = 2;

            // Act
            for (var i = 1; i <= 11; i++)
                ball?.Move();
            actualBallPosX = ball?.PositionX;
            actualBallPosY = ball?.PositionY;

            // Assert
            Assert.AreEqual(expectedBallPosX, actualBallPosX);
            Assert.AreEqual(expectedBallPosY, actualBallPosY);
        }

        [TestMethod]
        public void TestDirectionInvertAfterReset()
        {
            // Arrange
            _ballService?.Dispose();
            var stageWidth = 11;
            var stageHeight = 100;
            var directionX = 1;
            var directionY = 1;
            _ballService?.CreateBall(stageWidth, stageHeight, directionX, directionY);
            var ball = _ballService?.GetBall();
            var expectedBallDirectionX = -1;

            // Act
            for (var i = 1; i <= 6; i++)
                ball?.Move();
            var actualBallDirectionX = ball?.DirectionX;

            // Assert
            Assert.AreEqual(expectedBallDirectionX, actualBallDirectionX);

            // Arrange
            _ballService?.Dispose();
            stageWidth = 20;
            stageHeight = 5;
            directionX = -1;
            directionY = -1;
            _ballService?.CreateBall(stageWidth, stageHeight, directionX, directionY);
            ball = _ballService?.GetBall();
            expectedBallDirectionX = 1;

            // Act
            for (var i = 1; i <= 11; i++)
                ball?.Move();
            actualBallDirectionX = ball?.DirectionX;

            // Assert
            Assert.AreEqual(expectedBallDirectionX, actualBallDirectionX);
        }
    }
}
