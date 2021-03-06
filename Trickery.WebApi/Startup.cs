﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trickery.DAL.Config;
using Trickery.WebApi.Config;

namespace Trickery.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .RegisterLibs()
                .RegisterModules(Configuration)
                .RegisterContext(Configuration)
                .RegisterAuthServices(Configuration)
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseHsts();
            }
            
            app
                .UseAuthentication()
                .UseLibraries()
                .UseMiddleware<ExceptionHandlingMiddleware>()                
                .UseMvc();
        }
    }
}
