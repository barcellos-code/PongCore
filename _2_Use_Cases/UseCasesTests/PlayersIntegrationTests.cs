using Ball;
using BallInteractor;
using Microsoft.Extensions.DependencyInjection;
using Players;
using PlayersInteractor;
using Stage;
using StageInteractor;

namespace UseCasesTests;

[TestClass]
public class PlayersIntegrationTests
{
    [TestMethod]
    public void TestPlayersScoreIncrement()
    {
        // Arrange
        var playersInteractor = TestContainer.ServiceProvider.GetService<IPlayersInteractor>();
        var ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        var stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        var playersService = TestContainer.ServiceProvider.GetService<IPlayersService>();
        var ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        var stageService = TestContainer.ServiceProvider.GetService<IStageService>();
        playersService?.Dispose();
        ballService?.Dispose();
        stageService?.Dispose();
        var numberOfPlayers = 1;
        var stageWidth = 20;
        var stageHeight = 5;
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
        var ballDirX = 1;
        var ballDirY = 1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
        playersInteractor?.BindGoalEvents();
        var expectedScoreValue = 1;

        // Act
        for (var i = 1; i <= 10; i++)
            ballInteractor?.MoveBall();
        var actualScoreValue = playersService?.GetPlayer(0).Score;

        // Assert
        Assert.AreEqual(expectedScoreValue, actualScoreValue);

        // Arrange
        expectedScoreValue = 1;
        
        // Act
        for (var i = 1; i <= 11; i++)
            ballInteractor?.MoveBall();
        actualScoreValue = playersService?.GetPlayer(0).Score;

        // Assert
        Assert.AreEqual(expectedScoreValue, actualScoreValue);

        // Arrange
        expectedScoreValue = 2;

        // Act
        for (var i = 1; i <= 10; i++)
            ballInteractor?.MoveBall();
        actualScoreValue = playersService?.GetPlayer(0).Score;

        // Assert
        Assert.AreEqual(expectedScoreValue, actualScoreValue);

        // Arrange
        playersService?.Dispose();
        ballService?.Dispose();
        numberOfPlayers = 2;
        playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
        playersInteractor?.BindGoalEvents();
        var expectedPlayerOneScoreValue = 1;
        var expectedPlayerTwoScoreValue = 0;

        // Act
        for (var i = 1; i <= 10; i++)
            ballInteractor?.MoveBall();
        var actualPlayerOneScoreValue = playersService?.GetPlayer(0).Score;
        var actualPlayerTwoScoreValue = playersService?.GetPlayer(1).Score;

        // Assert
        Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
        Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);

        // Arrange
        expectedPlayerOneScoreValue = 1;
        expectedPlayerTwoScoreValue = 1;

        // Act
        for (var i = 1; i <= 11; i++)
            ballInteractor?.MoveBall();
        actualPlayerOneScoreValue = playersService?.GetPlayer(0).Score;
        actualPlayerTwoScoreValue = playersService?.GetPlayer(1).Score;

        // Assert
        Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
        Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);

        // Arrange
        expectedPlayerOneScoreValue = 2;
        expectedPlayerTwoScoreValue = 1;

        // Act
        for (var i = 1; i <= 10; i++)
            ballInteractor?.MoveBall();
        actualPlayerOneScoreValue = playersService?.GetPlayer(0).Score;
        actualPlayerTwoScoreValue = playersService?.GetPlayer(1).Score;

        // Assert
        Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
        Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);

        // Arrange
        playersService?.Dispose();
        ballService?.Dispose();
        numberOfPlayers = 5;
        playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
        playersInteractor?.BindGoalEvents();
        expectedPlayerOneScoreValue = 1;
        expectedPlayerTwoScoreValue = 0;
        var expectedPlayerThreeScoreValue = 0;
        var expectedPlayerFourScoreValue = 0;
        var expectedPlayerFiveScoreValue = 0;

        // Act
        for (var i = 1; i <= 10; i++)
            ballInteractor?.MoveBall();
        actualPlayerOneScoreValue = playersService?.GetPlayer(0).Score;
        actualPlayerTwoScoreValue = playersService?.GetPlayer(1).Score;
        var actualPlayerThreeScoreValue = playersService?.GetPlayer(2).Score;
        var actualPlayerFourScoreValue = playersService?.GetPlayer(3).Score;
        var actualPlayerFiveScoreValue = playersService?.GetPlayer(4).Score;

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
            ballInteractor?.MoveBall();
        actualPlayerOneScoreValue = playersService?.GetPlayer(0).Score;
        actualPlayerTwoScoreValue = playersService?.GetPlayer(1).Score;
        actualPlayerThreeScoreValue = playersService?.GetPlayer(2).Score;
        actualPlayerFourScoreValue = playersService?.GetPlayer(3).Score;
        actualPlayerFiveScoreValue = playersService?.GetPlayer(4).Score;

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
            ballInteractor?.MoveBall();
        actualPlayerOneScoreValue = playersService?.GetPlayer(0).Score;
        actualPlayerTwoScoreValue = playersService?.GetPlayer(1).Score;
        actualPlayerThreeScoreValue = playersService?.GetPlayer(2).Score;
        actualPlayerFourScoreValue = playersService?.GetPlayer(3).Score;
        actualPlayerFiveScoreValue = playersService?.GetPlayer(4).Score;

        // Assert
        Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
        Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);
        Assert.AreEqual(expectedPlayerThreeScoreValue, actualPlayerThreeScoreValue);
        Assert.AreEqual(expectedPlayerFourScoreValue, actualPlayerFourScoreValue);
        Assert.AreEqual(expectedPlayerFiveScoreValue, actualPlayerFiveScoreValue);
    }
}
