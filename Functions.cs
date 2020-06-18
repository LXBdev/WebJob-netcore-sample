using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebJob_netcore_sample
{

    public class Functions
    {
        public async Task MyTimerTriggerOperation([TimerTrigger("0 * */5 * * *", RunOnStartup = true)] TimerInfo timerInfo, CancellationToken cancellationToken)
        {
            // Do some work...
            await Task.Delay(100, cancellationToken);

            var config = new ConfigurationBuilder()
                //.AddEnvironmentVariables()
                .AddJsonFile("appsettings.json")
                .Build();

            foreach (var item in config.AsEnumerable())
            {
                Console.WriteLine(item);
            }
        }
    }
}
