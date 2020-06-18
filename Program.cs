using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace WebJob_netcore_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var config = new ConfigurationBuilder()
                //.AddEnvironmentVariables()
                .AddJsonFile("appsettings.json")
                .Build();

            foreach (var item in config.AsEnumerable())
            {
                Console.WriteLine(item);
            }

            HostBuilder builder = new HostBuilder();
            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorage();
                b.AddTimers();
            });
            IHost host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}
