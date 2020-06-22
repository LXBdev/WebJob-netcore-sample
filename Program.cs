using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebJob_netcore_sample
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
                b.AddTimers();
            });
            builder.ConfigureServices(services =>
            {
                services.AddScoped<Functions>();
                services.AddScoped<MyService>();
            });
            builder.ConfigureLogging((context, b) =>
            {
                b.AddAzureWebAppDiagnostics();
                b.AddApplicationInsights();
                b.AddConsole();
            });
            builder.ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                configurationBuilder
                    .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: false)
                    .AddEnvironmentVariables();
            });

            IHost host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
