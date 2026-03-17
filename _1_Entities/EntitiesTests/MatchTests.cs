using Ball;
using Match;
using Microsoft.Extensions.DependencyInjection;
using Players;

namespace EntitiesTests;

[TestClass]
public sealed class MatchTests
{
    private static IMatchService? _matchService;
    private static IPlayersService? _playersService;
    private static IBallService? _ballService;

    [ClassInitialize]
    public static void ClassSetup(TestContext testContext)
    {
        _matchService = TestContainer.ServiceProvider.GetService<IMatchService>();
        _playersService = TestContainer.ServiceProvider.GetService<IPlayersService>();
        _ballService = TestContainer.ServiceProvider.GetService<IBallService>();
    }

    [TestInitialize]
    public void TestSetup()
    {
        _matchService?.Dispose();
        _playersService?.Dispose();
        _ballService?.Dispose();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _matchService?.Dispose();
        _playersService?.Dispose();
        _ballService?.Dispose();
    }

    [TestMethod]
    public void TestMatchState()
    {
        // Arrange
        _matchService?.Dispose();
        _playersService?.Dispose();
        _ballService?.Dispose();
        
        var numberOfPlayers = 2;
        var stageWidth = 5;
        var stageHeight = 20;
        var ballInitialDirX = 1;
        var ballInitialDirY = 1;
        var winningScoreValue = 1;

        var expectedMatchOngoingState = false;

        // Act
        _playersService?.CreatePlayers(numberOfPlayers);
        _ballService?.CreateBall(stageWidth / 2, stageHeight / 2, ballInitialDirX, ballInitialDirY);
        _playersService?.BindGoalEvents();
        _matchService?.CreateMatch(winningScoreValue);
        _matchService?.BindScoreEvents();

        var match = _matchService?.GetMatch();
        var actualMatchOngoingState = match?.IsOngoing;

        // Assert
        Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);

        // Arrange
        expectedMatchOngoingState = true;

        // Act
        match?.StartMatch();
        actualMatchOngoingState = match?.IsOngoing;

        // Assert
        Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);

        // Arrange
        var ball = _ballService?.GetBall();
        expectedMatchOngoingState = false;

        // Act
        for (var i = 1; i <= 3; i++)
            ball?.Move();
        actualMatchOngoingState = match?.IsOngoing;

        // Assert
        Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);

        // Arrange
        _matchService?.Dispose();
        _ballService?.Dispose();
        _playersService?.Dispose();

        numberOfPlayers = 5;
        stageWidth = 5;
        stageHeight = 20;
        ballInitialDirX = 1;
        ballInitialDirY = 1;
        winningScoreValue = 3;

        expectedMatchOngoingState = false;

        // Act
        _playersService?.CreatePlayers(numberOfPlayers);
        _ballService?.CreateBall(stageWidth / 2, stageHeight / 2, ballInitialDirX, ballInitialDirY);
        _playersService?.BindGoalEvents();
        _matchService?.CreateMatch(winningScoreValue);
        _matchService?.BindScoreEvents();

        match = _matchService?.GetMatch();
        actualMatchOngoingState = match?.IsOngoing;

        // Assert
        Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);

        // Arrange
        expectedMatchOngoingState = true;

        // Act
        match?.StartMatch();
        actualMatchOngoingState = match?.IsOngoing;

        // Assert
        Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);

        // Arrange
        ball = _ballService?.GetBall();
        expectedMatchOngoingState = false;

        // Act
        for (var i = 1; i <= 15; i++)
            ball?.Move();
        actualMatchOngoingState = match?.IsOngoing;

        // Assert
        Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);
    }
}
