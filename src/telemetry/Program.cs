var telemetry = new ExampleTelemetry();

Console.WriteLine("PROPERTIES");
foreach (var property in telemetry.GetProperties())
{
    Console.WriteLine($"{property.Key}: {property.Value}");
}

Console.WriteLine();

Console.WriteLine("METRICS");
foreach (var metric in telemetry.GetMetrics())
{
    Console.WriteLine($"{metric.Key}: {metric.Value}");
}


class ExampleTelemetry : Telemetry.Logic.Telemetry
{
    public bool ExampleBool { get; set; }

    public bool? ExampleNullableBoolNull { get; set; }

    public bool? ExampleNullableBoolNonNull { get; set; } = true;

    public IReadOnlyCollection<bool> ExampleBoolCollection { get; set; } = [true, false, true];

    public IReadOnlyCollection<bool?> ExampleNullableBoolCollection { get; set; } = [true, null, null, null, false];

    public double ExampleDouble { get; set; } = 2.33;

    public double? ExampleNullableDoubleNonNull { get; set; } = 2.33;

    public double? ExampleNullableDoubleNull { get; set; } = null;

    public IReadOnlyCollection<double> ExampleDoubleCollection { get; set; } = [1.33, 2.11, 5.12];

    public string ExampleString { get; set; } = "some text";

    public IReadOnlyCollection<string> ExampleStringCollection { get; set; } = ["text1", "text2", "text3"];

    public int ExampleInteger { get; set; } = 100;

    public int? ExampleNullableIntegerNonNull { get; set; } = 100;

    public int? ExampleNullableIntegerNull { get; set; } = null;

    public decimal ExampleDecimal { get; set; } = 101.444221m;

    public decimal? ExampleNullableDecimalNonNull { get; set; } = 101.444221m;

    public decimal? ExampleNullableDecimalNull { get; set; } = null;

    public SomeObject ExampleObject { get; set; } = new();

    public IReadOnlyCollection<SomeObject> ExampleObjects { get; set; } = [new SomeObject(), new SomeObject(), new SomeObject()];

    public class SomeObject
    {
        public string SomeString { get; set; } = "example text";

        public double SomeDouble { get; set; } = 4213;

        public IReadOnlyCollection<double> SomeDoubles { get; set; } = [1.232, 42.213, 5324.123];

        public IReadOnlyCollection<string> SomeStrings { get; set; } = ["some other string", "and another one"];
    }
}