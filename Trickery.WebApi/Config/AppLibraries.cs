using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Trickery.WebApi.Config
{
    public static class AppLibraries
    {
        public static IServiceCollection RegisterLibs(this IServiceCollection services)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Trickery", Version = "v1" });
                });

            return services;
        }

        public static IApplicationBuilder UseLibraries(this IApplicationBuilder app)
        {
            app
                .UseSwagger()
                .UseSwaggerUI( c=>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trickery");
                });

            return app;
        }
    }
}
