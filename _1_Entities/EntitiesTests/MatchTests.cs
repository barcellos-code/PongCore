using Match;
using Microsoft.Extensions.DependencyInjection;

namespace EntitiesTests
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void TestMatchInitialState()
        {
            // Arrange
            var matchService = TestContainer.ServiceProvider.GetService<IMatchService>();
            matchService?.Dispose();
            var winningScoreValue = 1;
            var expectedMatchOngoingState = false;

            // Act
            matchService?.CreateMatch(winningScoreValue);
            var match = matchService?.GetMatch();
            var actualMatchOngoingState = match?.IsOngoing;

            // Assert
            Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);
        }

        [TestMethod]
        public void TestMatchStart()
        {
            // Arrange
            var matchService = TestContainer.ServiceProvider.GetService<IMatchService>();
            matchService?.Dispose();
            var winningScoreValue = 1;
            var expectedMatchOngoingState = true;

            // Act
            matchService?.CreateMatch(winningScoreValue);
            var match = matchService?.GetMatch();
            match?.StartMatch();
            var actualMatchOngoingState = match?.IsOngoing;

            // Assert
            Assert.AreEqual(expectedMatchOngoingState, actualMatchOngoingState);
        }
    }
}
