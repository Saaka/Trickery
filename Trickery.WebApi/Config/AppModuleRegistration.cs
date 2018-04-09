using Microsoft.Extensions.DependencyInjection;
using Trickery.Configuration;
using Trickery.DAL.Config;

namespace Trickery.WebApi.Config
{
    public static class AppModuleRegistration
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            services
                .RegisterConfiguration()
                .RegisterDAL();

            return services;
        }
    }
}
