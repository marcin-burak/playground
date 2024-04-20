using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Todo.Common.ApplicationInsights.Telemetry;

public abstract class Telemetry
{
    private static JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    public IDictionary<string, string>? GetProperties()
    {
        var nonNumericalProperties = GetType()
            .GetProperties()
            .Where(property => property.PropertyType.IsAssignableFrom(typeof(double)));
    }

    public IDictionary<string, double>? GetMetrics()
    {

    }
}

public sealed class TelemetryParameter<T>
{
    public TelemetryParameter(string name, T value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(value);

        Name = name.Trim();
    }

    public string Name { get; }

    public T Value { get; }
}