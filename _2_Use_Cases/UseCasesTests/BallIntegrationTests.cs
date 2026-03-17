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

    [TestMethod]
    public void TestBallBounceOffStageBounds()
    {
        // Arrange
        var ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        var stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        var ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        var stageWidth = 100;
        var stageHeight = 5;
        var directionX = 1;
        var directionY = 1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        var ball = ballService?.GetBall();
        var expectedBallPosY = 3;

        // Act
        for (var i = 1; i <= 3; i++)
            ballInteractor?.MoveBall();
        var actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        expectedBallPosY = 1;

        // Act
        for (var i = 1; i <= 4; i++)
            ballInteractor?.MoveBall();
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        expectedBallPosY = 2;

        // Act
        for (var i = 1; i <= 5; i++)
            ballInteractor?.MoveBall();
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        directionY = -1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = ballService?.GetBall();
        expectedBallPosY = 2;

        // Act
        for (var i = 1; i <= 4; i++)
            ballInteractor?.MoveBall();
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        expectedBallPosY = 3;

        // Act
        for (var i = 1; i <= 3; i++)
            ballInteractor?.MoveBall();
        actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosY, actualBallPosY);
    }

    [TestMethod]
    public void TestBallBounceOffPaddles()
    {
        // Arrange
        var ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        var stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        var paddlesInteractor = TestContainer.ServiceProvider.GetService<IPaddlesInteractor>();
        var ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        var stageService = TestContainer.ServiceProvider.GetService<IStageService>();
        var paddlesService = TestContainer.ServiceProvider.GetService<IPaddlesService>();
        stageService?.Dispose();
        ballService?.Dispose();
        paddlesService?.Dispose();
        var stageWidth = 7;
        var stageHeight = 1000;
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        var paddleSize = 990;
        var numberOfPaddles = 2;
        paddlesInteractor?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
        var directionX = 1;
        var directionY = 1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        var ball = ballService?.GetBall();
        var expectedBallPosX = 3;

        // Act
        for (var i = 1; i <= 2; i++)
            ballInteractor?.MoveBall();
        var actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        expectedBallPosX = 2;

        // Act
        ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        expectedBallPosX = 3;

        // Act
        ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        expectedBallPosX = 4;

        // Act
        ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        expectedBallPosX = 3;

        // Act
        ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        ballService?.Dispose();
        paddlesService?.Dispose();
        stageService?.Dispose();
        stageWidth = 11;
        stageHeight = 50;
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        paddleSize = 3;
        numberOfPaddles = 2;
        paddlesInteractor?.CreatePaddles(numberOfPaddles, paddleSize, stageWidth, stageHeight);
        directionX = 1;
        directionY = 1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = ballService?.GetBall();
        expectedBallPosX = 10;

        // Act
        for (var i = 1; i <= 5; i++)
            ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        ballService?.Dispose();
        directionX = 1;
        directionY = -1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = ballService?.GetBall();
        expectedBallPosX = 10;

        // Act
        for (var i = 1; i <= 5; i++)
            ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        ballService?.Dispose();
        directionX = -1;
        directionY = 1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = ballService?.GetBall();
        expectedBallPosX = 0;

        // Act
        for (var i = 1; i <= 5; i++)
            ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);

        // Arrange
        ballService?.Dispose();
        directionX = -1;
        directionY = -1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = ballService?.GetBall();
        expectedBallPosX = 0;

        // Act
        for (var i = 1; i <= 5; i++)
            ballInteractor?.MoveBall();
        actualBallPosX = ball?.PositionX;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);
    }

    [TestMethod]
    public void TestBallResetOnGoal()
    {
        // Arrange
        var ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        var ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        var stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        var stageService = TestContainer.ServiceProvider.GetService<IStageService>();
        ballService?.Dispose();
        stageService?.Dispose();
        var stageWidth = 11;
        var stageHeight = 100;
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        var directionX = 1;
        var directionY = 1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        var ball = ballService?.GetBall();
        var expectedBallPosX = 5;
        var expectedBallPosY = 50;

        // Act
        for (var i = 1; i <= 6; i++)
            ballInteractor?.MoveBall();
        var actualBallPosX = ball?.PositionX;
        var actualBallPosY = ball?.PositionY;

        // Assert
        Assert.AreEqual(expectedBallPosX, actualBallPosX);
        Assert.AreEqual(expectedBallPosY, actualBallPosY);

        // Arrange
        ballService?.Dispose();
        stageService?.Dispose();
        stageWidth = 20;
        stageHeight = 5;
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        directionX = -1;
        directionY = -1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = ballService?.GetBall();
        expectedBallPosX = 10;
        expectedBallPosY = 2;

        // Act
        for (var i = 1; i <= 11; i++)
            ballInteractor?.MoveBall();
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
        var ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        var ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        var stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        var stageService = TestContainer.ServiceProvider.GetService<IStageService>();
        ballService?.Dispose();
        stageService?.Dispose();
        var stageWidth = 11;
        var stageHeight = 100;
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        var directionX = 1;
        var directionY = 1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        var ball = ballService?.GetBall();
        var expectedBallDirectionX = -1;

        // Act
        for (var i = 1; i <= 6; i++)
            ballInteractor?.MoveBall();
        var actualBallDirectionX = ball?.DirectionX;

        // Assert
        Assert.AreEqual(expectedBallDirectionX, actualBallDirectionX);

        // Arrange
        ballService?.Dispose();
        stageService?.Dispose();
        stageWidth = 20;
        stageHeight = 5;
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        directionX = -1;
        directionY = -1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, directionX, directionY);
        ball = ballService?.GetBall();
        expectedBallDirectionX = 1;

        // Act
        for (var i = 1; i <= 11; i++)
            ballInteractor?.MoveBall();
        actualBallDirectionX = ball?.DirectionX;

        // Assert
        Assert.AreEqual(expectedBallDirectionX, actualBallDirectionX);
    }
}
