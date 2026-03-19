using Ball;
using BallInteractor;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using PaddlesInteractor;
using Stage;
using StageInteractor;

namespace UseCasesTests;

[TestClass]
public sealed class BallIntegrationTests
{
    private static IBallInteractor? _ballInteractor;
    private static IPaddlesInteractor? _paddlesInteractor;
    private static IStageInteractor? _stageInteractor;
    private static IBallService? _ballService;
    private static IPaddlesService? _paddlesService;
    private static IStageService? _stageService;

    [ClassInitialize]
    public static void ClassSetup(TestContext testContext)
    {
        _ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        _paddlesInteractor = TestContainer.ServiceProvider.GetService<IPaddlesInteractor>();
        _stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        _ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        _paddlesService = TestContainer.ServiceProvider.GetService<IPaddlesService>();
        _stageService = TestContainer.ServiceProvider.GetService<IStageService>();
    }

    [TestInitialize]
    public void TestSetup()
    {
        _ballService?.Dispose();
        _paddlesService?.Dispose();
        _stageService?.Dispose();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _ballService?.Dispose();
        _paddlesService?.Dispose();
        _stageService?.Dispose();
    }

    [TestMethod]
    public void TestBallBounceOffStageBounds()
    {
        // Arrange
        var stageWidth = 100;
        var stageHeight = 5;
        var directionX = 1;
        var directionY = 1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        _stageInteractor?.CreateStage(stageWidth, stageHeight);
        var ball = _ballService?.GetBall();
        var expectedBallPosY = 3;

        // Act
        for (var i = 1; i <= 3; i++)
            _ballInteractor?.MoveBall();
        var actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        expectedBallPosY = 1;

        // Act
        for (var i = 1; i <= 4; i++)
            _ballInteractor?.MoveBall();
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        expectedBallPosY = 2;

        // Act
        for (var i = 1; i <= 5; i++)
            _ballInteractor?.MoveBall();
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        directionY = -1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = _ballService?.GetBall();
        expectedBallPosY = 2;

        // Act
        for (var i = 1; i <= 4; i++)
            _ballInteractor?.MoveBall();
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        expectedBallPosY = 3;

        // Act
        for (var i = 1; i <= 3; i++)
            _ballInteractor?.MoveBall();
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);
    }

    [TestMethod]
    public void TestBallBounceOffPaddles()
    {
        // Arrange
        var stageWidth = 7;
        var stageHeight = 1000;
        _stageInteractor?.CreateStage(stageWidth, stageHeight);
        var paddleSize = 990;
        var numberOfPaddles = 2;
        _paddlesInteractor?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
        var directionX = 1;
        var directionY = 1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        var ball = _ballService?.GetBall();
        var expectedBallPosX = 3;

        // Act
        for (var i = 1; i <= 2; i++)
            _ballInteractor?.MoveBall();
        var actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        expectedBallPosX = 2;

        // Act
        _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        expectedBallPosX = 3;

        // Act
        _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        expectedBallPosX = 4;

        // Act
        _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        expectedBallPosX = 3;

        // Act
        _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        _ballService?.Dispose();
        _paddlesService?.Dispose();
        _stageService?.Dispose();
        stageWidth = 11;
        stageHeight = 50;
        _stageInteractor?.CreateStage(stageWidth, stageHeight);
        paddleSize = 3;
        numberOfPaddles = 2;
        _paddlesInteractor?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
        directionX = 1;
        directionY = 1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = _ballService?.GetBall();
        expectedBallPosX = 10;

        // Act
        for (var i = 1; i <= 5; i++)
            _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        _ballService?.Dispose();
        directionX = 1;
        directionY = -1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = _ballService?.GetBall();
        expectedBallPosX = 10;

        // Act
        for (var i = 1; i <= 5; i++)
            _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        _ballService?.Dispose();
        directionX = -1;
        directionY = 1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = _ballService?.GetBall();
        expectedBallPosX = 0;

        // Act
        for (var i = 1; i <= 5; i++)
            _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        _ballService?.Dispose();
        directionX = -1;
        directionY = -1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = _ballService?.GetBall();
        expectedBallPosX = 0;

        // Act
        for (var i = 1; i <= 5; i++)
            _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);
    }

    [TestMethod]
    public void TestBallResetOnGoal()
    {
        // Arrange
        var stageWidth = 11;
        var stageHeight = 100;
        _stageInteractor?.CreateStage(stageWidth, stageHeight);
        var directionX = 1;
        var directionY = 1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        var ball = _ballService?.GetBall();
        var expectedBallPosX = 5;
        var expectedBallPosY = 50;

        // Act
        for (var i = 1; i <= 6; i++)
            _ballInteractor?.MoveBall();
        var actualBallPosX = ball?.PositionX;
        var actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        _ballService?.Dispose();
        _stageService?.Dispose();
        stageWidth = 20;
        stageHeight = 5;
        _stageInteractor?.CreateStage(stageWidth, stageHeight);
        directionX = -1;
        directionY = -1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = _ballService?.GetBall();
        expectedBallPosX = 10;
        expectedBallPosY = 2;

        // Act
        for (var i = 1; i <= 11; i++)
            _ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);
        Assert.AreEqual(expectedBallPosY, actualBallPosY);
    }

    [TestMethod]
    public void TestBallDirectionReverseAfterReset()
    {
        // Arrange
        var stageWidth = 11;
        var stageHeight = 100;
        _stageInteractor?.CreateStage(stageWidth, stageHeight);
        var directionX = 1;
        var directionY = 1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        var ball = _ballService?.GetBall();
        var expectedBallDirectionX = -1;

        // Act
        for (var i = 1; i <= 6; i++)
            _ballInteractor?.MoveBall();
        var actualBallDirectionX = ball?.DirectionX;

        // Assert
        Assert.AreEqual(expectedBallDirectionX, actualBallDirectionX);

        // Arrange
        _ballService?.Dispose();
        _stageService?.Dispose();
        stageWidth = 20;
        stageHeight = 5;
        _stageInteractor?.CreateStage(stageWidth, stageHeight);
        directionX = -1;
        directionY = -1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = _ballService?.GetBall();
        expectedBallDirectionX = 1;

        // Act
        for (var i = 1; i <= 11; i++)
            _ballInteractor?.MoveBall();
        actualBallDirectionX = ball?.DirectionX;

        // Assert
        Assert.AreEqual(expectedBallDirectionX, actualBallDirectionX);
    }
}
