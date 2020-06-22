using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebJob_netcore_sample
{
    public class MyService
    {
        private readonly ILogger<MyService> _Logger;

        public MyService(ILogger<MyService> logger)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void Foo()
        {
            _Logger.LogInformation("MyService says foo");
        }
    }
}
