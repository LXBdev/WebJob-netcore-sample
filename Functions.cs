using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebJob_netcore_sample
{

    public class Functions
    {
        private readonly IConfiguration _Configuration;

        public Functions(IConfiguration configuration)
        {
            this._Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task MyTimerTriggerOperation([TimerTrigger("0/15 * * * * *", RunOnStartup = false)] TimerInfo timerInfo, CancellationToken cancellationToken)
        {
            // Do some work...
            await Task.Delay(100, cancellationToken);

            foreach (var item in _Configuration.AsEnumerable())
            {
                Console.WriteLine(item);
            }
        }
    }
}
