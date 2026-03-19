using Ball;
using BallInteractor;
using Match;
using MatchInteractor;
using Microsoft.Extensions.DependencyInjection;
using Players;
using PlayersInteractor;
using Stage;
using StageInteractor;

namespace UseCasesTests;

[TestClass]
public class MatchIntegrationTests
{
    [TestMethod]
    public void TestMatchEnd()
    {
        // Arrange
        var matchInteractor = TestContainer.ServiceProvider.GetService<IMatchInteractor>();
        var playersInteractor = TestContainer.ServiceProvider.GetService<IPlayersInteractor>();
        var ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        var stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        var matchService = TestContainer.ServiceProvider.GetService<IMatchService>();
        var playersService = TestContainer.ServiceProvider.GetService<IPlayersService>();
        var ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        var stageService = TestContainer.ServiceProvider.GetService<IStageService>();
        matchService?.Dispose();
        playersService?.Dispose();
        ballService?.Dispose();
        stageService?.Dispose();
        
        var stageWidth = 5;
        var stageHeight = 20;
        stageInteractor?.CreateStage(stageWidth, stageHeight);
        var numberOfPlayers = 2;
        var winningScoreValue = 1;
        playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
        var ballInitialDirX = 1;
        var ballInitialDirY = 1;
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballInitialDirX, ballInitialDirY);
        playersInteractor?.BindGoalEvents();
        matchInteractor?.CreateMatch(winningScoreValue, stageWidth, stageHeight);
        matchInteractor?.BindScoreEvents();

        var expectedMatchOngoingState = false;

        // Act
        var match = matchService?.GetMatch();
        match?.StartMatch();
        for (var i = 1; i <= 3; i++)
            ballInteractor?.MoveBall();
        var actualMatchOngoingState = match?.IsOngoing;

        // Assert
        Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);

        // Arrange
        matchService?.Dispose();
        ballService?.Dispose();
        playersService?.Dispose();

        numberOfPlayers = 5;
        winningScoreValue = 3;

        expectedMatchOngoingState = false;

        // Act
        playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
        ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballInitialDirX, ballInitialDirY);
        playersInteractor?.BindGoalEvents();
        matchInteractor?.CreateMatch(winningScoreValue, stageWidth, stageHeight);
        matchInteractor?.BindScoreEvents();
        match = matchService?.GetMatch();
        match?.StartMatch();

        // Act
        for (var i = 1; i <= 15; i++)
            ballInteractor?.MoveBall();
        actualMatchOngoingState = match?.IsOngoing;

        // Assert
        Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);
    }
}
