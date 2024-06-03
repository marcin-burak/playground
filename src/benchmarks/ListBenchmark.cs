using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser(displayGenColumns: false)]
public class ListBenchmark
{
    private static ReadOnlySpan<int> GetNumbers() => Enumerable.Range(1, 1000).ToArray().AsSpan();

    [Benchmark]
    public void NoPresetCapacity()
    {
        List<int> list = new();
        foreach (var number in GetNumbers())
        {
            list.Add(number);
        }
    }

    [Benchmark]
    public void PresetCapacity()
    {
        List<int> list = new(1000);
        foreach (var number in GetNumbers())
        {
            list.Add(number);
        }
    }
}