using Microsoft.Extensions.DependencyInjection;
using Trickery.Configuration;

namespace Trickery.WebApi.Config
{
    public static class AppModuleRegistration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            services
                .RegisterConfiguration();

            return services;
        }
    }
}
