using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
[RPlotExporter]
public class ValueObjectBenchmark
{
    [Benchmark]
    public void ProcessClass()
    {
        NonWhitespaceTrimmedStringClass valueObject = new("  test  ");

        ProcessInternal(valueObject);
        ProcessInternal(valueObject);
        ProcessInternal(valueObject);

        void ProcessInternal(NonWhitespaceTrimmedStringClass valueObject)
        {
            ArgumentNullException.ThrowIfNull(valueObject);
            var tmp = valueObject;
        }
    }

    [Benchmark]
    public void ProcessRecord()
    {
        NonWhitespaceTrimmedStringRecord valueObject = new("  test  ");

        ProcessInternal(valueObject);
        ProcessInternal(valueObject);
        ProcessInternal(valueObject);

        void ProcessInternal(NonWhitespaceTrimmedStringRecord valueObject)
        {
            ArgumentNullException.ThrowIfNull(valueObject);
            var tmp = valueObject;
        }
    }

    [Benchmark]
    public void ProcessStruct()
    {
        NonWhitespaceTrimmedStringStruct valueObject = new("  test  ");

        ProcessInternal(valueObject);
        ProcessInternal(valueObject);
        ProcessInternal(valueObject);

        void ProcessInternal(NonWhitespaceTrimmedStringStruct valueObject)
        {
            if (valueObject.Value is null)
            {
                throw new ArgumentException("Value object has to be initialized.");
            }
            var tmp = valueObject;
        }
    }

    [Benchmark]
    public void ProcessRecordStruct()
    {
        NonWhitespaceTrimmedStringRecordStruct valueObject = new("  test  ");

        ProcessInternal(valueObject);
        ProcessInternal(valueObject);
        ProcessInternal(valueObject);

        void ProcessInternal(NonWhitespaceTrimmedStringRecordStruct valueObject)
        {
            if (valueObject.Value is null)
            {
                throw new ArgumentException("Value object has to be initialized.");
            }
            var tmp = valueObject;
        }
    }
}

class NonWhitespaceTrimmedStringClass
{
    public NonWhitespaceTrimmedStringClass(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        Value = value.Trim();
    }

    public string Value { get; }
}

record NonWhitespaceTrimmedStringRecord
{
    public NonWhitespaceTrimmedStringRecord(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        Value = value.Trim();
    }

    public string Value { get; }
}

readonly struct NonWhitespaceTrimmedStringStruct
{
    public NonWhitespaceTrimmedStringStruct(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        Value = value.Trim();
    }

    public string Value { get; }
}

readonly record struct NonWhitespaceTrimmedStringRecordStruct
{
    public NonWhitespaceTrimmedStringRecordStruct(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        Value = value.Trim();
    }

    public string Value { get; }
}