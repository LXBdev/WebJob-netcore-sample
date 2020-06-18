﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
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
            });

            IHost host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
