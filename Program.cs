﻿using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebJob_netcore_sample;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureWebJobs(b =>
{
    b.AddAzureStorageCoreServices();
    b.AddTimers();
});
builder.ConfigureServices(services =>
{
    services.AddApplicationInsightsTelemetryWorkerService();
    services.AddSingleton<ITelemetryInitializer, ComponentNameTelemetryInitializer>();
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

    if (context.HostingEnvironment.IsDevelopment())
    {
        configurationBuilder
            .AddUserSecrets<Program>(true);
    }
});

IHost host = builder.Build();
using (host)
{
    await host.RunAsync();
}