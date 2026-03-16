using Ball;
using BallInteractor;
using Microsoft.Extensions.DependencyInjection;
using StageInteractor;

namespace UseCasesTests;

[TestClass]
public sealed class BallIntegrationTests
{

    [TestMethod]
    public void TestBounceOffStageBounds()
    {
        // Arrange
        var ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        var stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        var ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        var stageWidth = 100;
        var stageHeight = 5;
        var directionX = 1;
        var directionY = 1;
        ballInteractor?.CreateBall(stageWidth, stageHeight, directionX, directionY);
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
        ballInteractor?.CreateBall(stageWidth, stageHeight, directionX, directionY);
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
    public void TestBounceOffPaddles()
    {
        
    }

    [TestMethod]
    public void TestBallReset()
    {
        
    }

    [TestMethod]
    public void TestBallDirectionReverseAfterReset()
    {
        
    }
}
