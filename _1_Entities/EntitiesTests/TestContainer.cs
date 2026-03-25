using Ball;
using DependencyContainer;
using Match;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using Players;
using Stage;

namespace EntitiesTests
{
    public static class TestContainer
    {
        public static IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    _serviceProvider = BuildServiceProvider();
                    Container.SetServiceProvider(_serviceProvider);
                    return _serviceProvider;
                }

                return _serviceProvider;
            }
        }

        private static IServiceProvider? _serviceProvider;

        private static ServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
        
            serviceCollection.AddSingleton<IBallService, BallService>();
            serviceCollection.AddSingleton<IMatchService, MatchService>();
            serviceCollection.AddSingleton<IPaddlesService, PaddlesService>();
            serviceCollection.AddSingleton<IPlayersService, PlayersService>();
            serviceCollection.AddSingleton<IStageService, StageService>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
