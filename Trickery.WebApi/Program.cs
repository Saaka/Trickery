using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Trickery.DAL.Initializer;

namespace Trickery.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .Build();
            DbInitializer.Initialize(host);

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
