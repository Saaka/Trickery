using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trickery.Configuration;

namespace Trickery.WebApi.Config
{
    public static class AuthServices
    {
        public static IServiceCollection RegisterAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = GetAuthority(configuration);
                options.Audience = GetAudience(configuration);
            });

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
