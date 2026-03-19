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
    private static IBallInteractor? _ballInteractor;
    private static IPlayersInteractor? _playersInteractor;
    private static IStageInteractor? _stageInteractor;
    private static IBallService? _ballService;
    private static IPlayersService? _playersService;
    private static IStageService? _stageService;

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        _ballInteractor = TestContainer.ServiceProvider.GetService<IBallInteractor>();
        _playersInteractor = TestContainer.ServiceProvider.GetService<IPlayersInteractor>();
        _stageInteractor = TestContainer.ServiceProvider.GetService<IStageInteractor>();
        _ballService = TestContainer.ServiceProvider.GetService<IBallService>();
        _playersService = TestContainer.ServiceProvider.GetService<IPlayersService>();
        _stageService = TestContainer.ServiceProvider.GetService<IStageService>();
    }

    [TestInitialize]
    public void TestSetup()
    {
        _ballService?.Dispose();
        _playersService?.Dispose();
        _stageService?.Dispose();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _ballService?.Dispose();
        _playersService?.Dispose();
        _stageService?.Dispose();
    }

    [TestMethod]
    public void TestPlayersScoreIncrement()
    {
        // Arrange
        var numberOfPlayers = 1;
        var stageWidth = 20;
        var stageHeight = 5;
        _stageInteractor?.CreateStage(stageWidth, stageHeight);
        _playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
        var ballDirX = 1;
        var ballDirY = 1;
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
        _playersInteractor?.BindGoalEvents();
        var expectedScoreValue = 1;

        // Act
        for (var i = 1; i <= 10; i++)
            _ballInteractor?.MoveBall();
        var actualScoreValue = _playersService?.GetPlayer(0).Score;

        // Assert
        Assert.AreEqual(expectedScoreValue, actualScoreValue);

        // Arrange
        expectedScoreValue = 1;
        
        // Act
        for (var i = 1; i <= 11; i++)
            _ballInteractor?.MoveBall();
        actualScoreValue = _playersService?.GetPlayer(0).Score;

        // Assert
        Assert.AreEqual(expectedScoreValue, actualScoreValue);

        // Arrange
        expectedScoreValue = 2;

        // Act
        for (var i = 1; i <= 10; i++)
            _ballInteractor?.MoveBall();
        actualScoreValue = _playersService?.GetPlayer(0).Score;

        // Assert
        Assert.AreEqual(expectedScoreValue, actualScoreValue);

        // Arrange
        _playersService?.Dispose();
        _ballService?.Dispose();
        numberOfPlayers = 2;
        _playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
        _playersInteractor?.BindGoalEvents();
        var expectedPlayerOneScoreValue = 1;
        var expectedPlayerTwoScoreValue = 0;

        // Act
        for (var i = 1; i <= 10; i++)
            _ballInteractor?.MoveBall();
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
            _ballInteractor?.MoveBall();
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
            _ballInteractor?.MoveBall();
        actualPlayerOneScoreValue = _playersService?.GetPlayer(0).Score;
        actualPlayerTwoScoreValue = _playersService?.GetPlayer(1).Score;

        // Assert
        Assert.AreEqual(expectedPlayerOneScoreValue, actualPlayerOneScoreValue);
        Assert.AreEqual(expectedPlayerTwoScoreValue, actualPlayerTwoScoreValue);

        // Arrange
        _playersService?.Dispose();
        _ballService?.Dispose();
        numberOfPlayers = 5;
        _playersInteractor?.CreatePlayers(numberOfPlayers, stageWidth, stageHeight);
        _ballInteractor?.CreateBall(stageWidth / 2, stageHeight / 2, ballDirX, ballDirY);
        _playersInteractor?.BindGoalEvents();
        expectedPlayerOneScoreValue = 1;
        expectedPlayerTwoScoreValue = 0;
        var expectedPlayerThreeScoreValue = 0;
        var expectedPlayerFourScoreValue = 0;
        var expectedPlayerFiveScoreValue = 0;

        // Act
        for (var i = 1; i <= 10; i++)
            _ballInteractor?.MoveBall();
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
            _ballInteractor?.MoveBall();
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
            _ballInteractor?.MoveBall();
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
