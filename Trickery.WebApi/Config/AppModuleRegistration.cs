using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trickery.Config;
using Trickery.Configuration;
using Trickery.DAL.Config;

namespace Trickery.WebApi.Config
{
    public static class AppModuleRegistration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .RegisterConfiguration()
                .RegisterMainDependencies()
                .RegisterDAL(configuration);

            return services;
        }
    }
}
