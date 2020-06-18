using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace WebJob_netcore_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
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
