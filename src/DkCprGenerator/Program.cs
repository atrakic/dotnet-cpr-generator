
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DkCprGenerator
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            IHostBuilder builder = Host.CreateDefaultBuilder(args);

            var host = builder.ConfigureServices(ConfigureServices).Build();
            var serviceProvider = host.Services;

            using (var scope = serviceProvider.CreateScope())
            {
                var app = scope.ServiceProvider.GetRequiredService<Application>();
                return await Application.RunAsync(args);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Application>();
        }
    }
}
