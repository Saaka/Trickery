using Microsoft.Extensions.DependencyInjection;

namespace Trickery.Configuration
{
    public static class ConfigurationRegistrationModule
    {
        public static IServiceCollection RegisterConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionConfig, ApplicationConfiguration>();
            services.AddScoped<IMongoConnectionConfig, ApplicationConfiguration>();
            
            return services;
        }
    }
}
