using Microsoft.Extensions.Logging;
using System;

namespace WebJob_netcore_sample;

public class MyService
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public void Foo()
    {
        _logger.LogInformation("MyService says foo");
    }
}