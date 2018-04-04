using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trickery.Configuration;
using Trickery.DAL.Model;
using Trickery.DAL.Store;
using Trickery.WebApi.Config.Auth.Auth0;
using Trickery.WebApi.Config.Auth.Google;
using Trickery.WebApi.Controllers.Base;

namespace Trickery.WebApi.Config
{
    public static class AuthServices
    {
        public static IServiceCollection RegisterAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            var authMethod = GetConfigString(configuration, ConfigurationProperties.Auth.Method);
            if (authMethod == AuthMethod.Auth0)
                RegisterAuth0(services, configuration);
            else if (authMethod == AuthMethod.Custom)
                RegisterCustomAuth(services, configuration);

            return services;
        }

        private static void RegisterCustomAuth(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserIdProvider, GoogleUserIdProvider>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.UseGoogle(
                        clientId: GetConfigString(configuration, ConfigurationProperties.Google.ClientId));
                });
        }

        private static void RegisterAuth0(IServiceCollection services, IConfiguration configuration)
        {
            var domain = GetConfigString(configuration, ConfigurationProperties.Auth0.Authority);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = GetConfigString(configuration, ConfigurationProperties.Auth0.Audience);
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        private static string GetConfigString(IConfiguration configuration, string configurationProperty)
        {
            return configuration[configurationProperty].ToString();
        }
    }

    public class AuthMethod
    {
        public const string Auth0 = "Auth0";
        public const string Custom = "Custom";
    }
}
