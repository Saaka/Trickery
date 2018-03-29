using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trickery.Configuration;
using Trickery.WebApi.Config.Auth;

namespace Trickery.WebApi.Config
{
    public static class AuthServices
    {
        public static IServiceCollection RegisterAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            var domain = GetAuthority(configuration);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = GetAudience(configuration);
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

            return services;
        }

        private static string GetAudience(IConfiguration configuration)
        {
            return configuration[ConfigurationProperties.Auth0.Audience].ToString();
        }

        private static string GetAuthority(IConfiguration configuration)
        {
            return configuration[ConfigurationProperties.Auth0.Authority].ToString();
        }
    }
}
