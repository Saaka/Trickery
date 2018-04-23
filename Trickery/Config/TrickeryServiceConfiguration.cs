using Microsoft.Extensions.DependencyInjection;
using Trickery.Infrastructure;

namespace Trickery.Config
{
    public static class TrickeryServiceConfiguration
    {
        public static IServiceCollection RegisterMainDependencies(this IServiceCollection services)
        {
            services
                .AddSingleton<IGuidProvider, GuidProvider>();

            return services;
        }
    }
}
