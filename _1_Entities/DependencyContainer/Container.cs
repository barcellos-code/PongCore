using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyContainer
{
    public static class Container
    {
        private static IServiceProvider? ServiceProvider { get; set; }

        public static void SetServiceProvider(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        public static T? GetService<T>() where T : class
        {
            if (ServiceProvider is null)
                throw new NullReferenceException($"{nameof(Container)}'s {nameof(ServiceProvider)} is null");

            return ServiceProvider.GetService<T>();
        }
    }
}
