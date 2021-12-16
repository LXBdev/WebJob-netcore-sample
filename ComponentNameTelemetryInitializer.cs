using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

public class ComponentNameTelemetryInitializer : ITelemetryInitializer
{
    public void Initialize(Microsoft.ApplicationInsights.Channel.ITelemetry telemetry)
    {
        if (telemetry is ISupportProperties iHaveProperties)
        {
            iHaveProperties.Properties["ComponentName"] = "CustomPropertyForAllLogs";
        }
    }
}