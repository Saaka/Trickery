using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trickery.Configuration;
using Trickery.DAL.Store;

namespace Trickery.DAL.Config
{
    public static class ServiceConfig
    {
        public static IServiceCollection RegisterContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((opt) =>
            opt.UseSqlServer(
                GetConnectionString(configuration),
                cb => cb.MigrationsHistoryTable("TrickeryMigrations")),
            ServiceLifetime.Scoped);
            //.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

            return services;
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            return configuration[ConfigurationProperties.DbSettings.ConnectionString].ToString();
        }
    }
}
