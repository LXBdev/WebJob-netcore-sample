# Running WebJobs in .NET Core with dependency injection and IConfiguration

This sample contains a simple timer webjob which will run every couple of seconds and dump the contents of `IConfiguration` to the console.

`IConfiguration` has the following features:
- Is available via dependency injection
- Resolves the `appsettings{environment}.json` file which can be controlled by setting the environment variable `DOTNET_ENVIRONMENT`.

## Run this sample

- Clone this repository
- Execute `dotnet run`