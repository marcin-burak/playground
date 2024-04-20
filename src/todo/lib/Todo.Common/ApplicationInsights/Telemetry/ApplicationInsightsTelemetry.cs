using Microsoft.ApplicationInsights;

namespace Todo.Common.ApplicationInsights.Telemetry;

public sealed class ApplicationInsightsTelemetry(TelemetryClient telemetry) : ITelemetry
{
    private readonly TelemetryClient _telemetry = telemetry;

    void LogTelemetry(Telemetry telemetry)
    {
        ArgumentNullException.ThrowIfNull(telemetry);

        _telemetry.TrackEvent(telemetry.Name, telemetry.Properties, telemetry.Metrics);
    }
}
