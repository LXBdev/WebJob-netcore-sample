using Microsoft.Azure.WebJobs;
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

                Console.WriteLine("heavy work");
            }
        }
}
