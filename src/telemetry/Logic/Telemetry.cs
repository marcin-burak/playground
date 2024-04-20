using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Telemetry.Logic;

public abstract class Telemetry
{
    private static readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    public IDictionary<string, string> GetProperties()
    {
        var nonNumericalProperties = GetType()
            .GetProperties()
            .Where(property => IsNumericType(property.PropertyType) is false && IsNullableNumericType(property.PropertyType) is false)
            .ToArray();

        var propertiesDictionary = new Dictionary<string, string>(nonNumericalProperties.Length);

        foreach (var property in nonNumericalProperties)
        {
            var @object = property.GetValue(this);
            propertiesDictionary.Add(property.Name, JsonSerializer.Serialize(@object, _jsonOptions));
        }

        return propertiesDictionary;
    }

    public IDictionary<string, double> GetMetrics()
    {
        var numericalProperties = GetType()
            .GetProperties()
            .Where(property => IsNumericType(property.PropertyType) || IsNullableNumericType(property.PropertyType))
            .ToArray();

        var metricsDictionary = new Dictionary<string, double>(numericalProperties.Length);

        foreach (var property in numericalProperties)
        {
            var @object = property.GetValue(this);
            if (@object is not null)
            {
                var value = Convert.ToDouble(@object);
                metricsDictionary.Add(property.Name, value);
            }
        }

        return metricsDictionary;
    }

    private static bool IsNumericType(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return type switch
        {
            _ when type == typeof(sbyte) => true,
            _ when type == typeof(byte) => true,

            _ when type == typeof(ushort) => true,
            _ when type == typeof(short) => true,

            _ when type == typeof(uint) => true,
            _ when type == typeof(int) => true,

            _ when type == typeof(nint) => true,
            _ when type == typeof(nuint) => true,

            _ when type == typeof(long) => true,
            _ when type == typeof(ulong) => true,

            _ when type == typeof(float) => true,
            _ when type == typeof(double) => true,
            _ when type == typeof(decimal) => true,

            _ => false
        };
    }

    private static bool IsNullableNumericType(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return type switch
        {
            _ when type == typeof(sbyte?) => true,
            _ when type == typeof(byte?) => true,

            _ when type == typeof(ushort?) => true,
            _ when type == typeof(short?) => true,

            _ when type == typeof(uint?) => true,
            _ when type == typeof(int?) => true,

            _ when type == typeof(nint?) => true,
            _ when type == typeof(nuint?) => true,

            _ when type == typeof(long?) => true,
            _ when type == typeof(ulong?) => true,

            _ when type == typeof(float?) => true,
            _ when type == typeof(double?) => true,
            _ when type == typeof(decimal?) => true,

            _ => false
        };
    }
}
