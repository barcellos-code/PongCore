using Ball;
using BallInteractor;
using Container;
using Microsoft.Extensions.DependencyInjection;
using Paddles;
using PaddlesInteractor;
using Players;
using PlayersInteractor;
using Stage;
using StageInteractor;

namespace UseCasesTests;

public static class TestContainer
{
    public static IServiceProvider ServiceProvider
    {
        get
        {
            if (_serviceProvider == null)
            {
                _serviceProvider = BuildServiceProvider();
                DependencyContainer.ServiceProvider = _serviceProvider;
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
        serviceCollection.AddSingleton<IStageService, StageService>();
        serviceCollection.AddSingleton<IPaddlesService, PaddlesService>();
        serviceCollection.AddSingleton<IPlayersService, PlayersService>();
        serviceCollection.AddSingleton<IBallInteractor, BallInteractor.BallInteractor>();
        serviceCollection.AddSingleton<IStageInteractor, StageInteractor.StageInteractor>();
        serviceCollection.AddSingleton<IPaddlesInteractor, PaddlesInteractor.PaddlesInteractor>();
        serviceCollection.AddSingleton<IPlayersInteractor, PlayersInteractor.PlayersInteractor>();

        return serviceCollection.BuildServiceProvider();
    }
}
