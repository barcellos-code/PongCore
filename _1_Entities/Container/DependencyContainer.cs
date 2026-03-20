using System;
using Microsoft.Extensions.DependencyInjection;

namespace Container
{
    public static class DependencyContainer
    {
        private static IServiceProvider? ServiceProvider { get; set; }

        public static void SetServiceProvider(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        public static T? GetService<T>() where T : class
        {
            if (ServiceProvider is null)
                throw new NullReferenceException($"{nameof(DependencyContainer)}'s {nameof(ServiceProvider)} is null");

            return ServiceProvider.GetService<T>();
        }
    }
}
