using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser]
public class SpanBenchmark
{
    private class User
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }

        public required int Age { get; init; }
    }

    [Params(1000, 100_000, 1_000_000)]
    public int Amount { get; set; }

    private static IEnumerable<User> GetUsers(int amount) => Enumerable.Range(1, amount).Select(index => new User
    {
        Id = Guid.Parse("5DD2C1EC-D168-4001-9320-9B03731632ED"),
        Name = "Name",
        Age = 25
    });

    [Benchmark]
    public void Collections()
    {
        var users = GetUsers(Amount);
        ProcessIds(users.Select(user => user.Id).ToArray());
        ProcessNames(users.Select(user => user.Name).ToArray());
        ProcessAges(users.Select(user => user.Age).ToArray());

        void ProcessIds(IReadOnlyCollection<Guid> values)
        {
            foreach (var value in values)
            {
                var _ = value;
            }
        }

        void ProcessNames(IReadOnlyCollection<string> values)
        {
            foreach (var value in values)
            {
                var _ = value;
            }
        }

        void ProcessAges(IReadOnlyCollection<int> values)
        {
            foreach (var value in values)
            {
                var _ = value;
            }
        }
    }

    [Benchmark]
    public void Spans()
    {
        var users = GetUsers(Amount);
        ProcessIds(users.Select(user => user.Id).ToArray());
        ProcessNames(users.Select(user => user.Name).ToArray());
        ProcessAges(users.Select(user => user.Age).ToArray());

        void ProcessIds(ReadOnlySpan<Guid> values)
        {
            foreach (var value in values)
            {
                var _ = value;
            }
        }

        void ProcessNames(ReadOnlySpan<string> values)
        {
            foreach (var value in values)
            {
                var _ = value;
            }
        }

        void ProcessAges(ReadOnlySpan<int> values)
        {
            foreach (var value in values)
            {
                var _ = value;
            }
        }
    }
}
