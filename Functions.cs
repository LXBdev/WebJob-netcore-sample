using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebJob_netcore_sample;

public class Functions
{
    private readonly IConfiguration _configuration;
    private readonly MyService _myService;
    private readonly ILogger<Functions> _logger;

    public Functions(IConfiguration configuration, MyService myService, ILogger<Functions> logger)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _myService = myService ?? throw new ArgumentNullException(nameof(myService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task MyTimerTriggerOperation([TimerTrigger("0/15 * * * * *", RunOnStartup = true)] TimerInfo timerInfo, CancellationToken cancellationToken)
    {
        // Do some work...
        await Task.Delay(100, cancellationToken);

        foreach (var item in _configuration.AsEnumerable())
        {
            _logger.LogInformation(item.ToString());
        }

        _myService.Foo();
    }
}