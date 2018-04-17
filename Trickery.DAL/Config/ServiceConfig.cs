using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Trickery.Configuration;
using Trickery.DAL.Repository.Auth.Google;
using Trickery.DAL.Repository.Document;
using Trickery.DAL.Store;
using Trickery.DAL.Store.Document;

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
            
            return services;
        }

        public static IServiceCollection RegisterDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<IGoogleUserRepository, GoogleUserRepository>();
            services
                .AddTransient<TestMessageContext>();
            services
                .AddTransient<ITestMessageRepository, TestMessageRepository>();
            
            var client = new MongoClient(GetMongoConnectionString(configuration));
            services
                .AddSingleton(client);

            return services;
        }

        private static string GetMongoConnectionString(IConfiguration configuration)
        {
            return configuration[ConfigurationProperties.Mongo.ConnectionString].ToString();
        }

        private static string GetConnectionString(IConfiguration configuration)
        {
            return configuration[ConfigurationProperties.DbSettings.ConnectionString].ToString();
        }
    }
}
