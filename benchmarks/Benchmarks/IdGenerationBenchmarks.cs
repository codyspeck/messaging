using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class IdGenerationBenchmarks
{
    private static long _id;
    
    [Benchmark]
    public Guid GenerateGuid()
    {
        return Guid.NewGuid();
    }

    [Benchmark]
    public long GenerateLong()
    {
        return Interlocked.Increment(ref _id);
    }
}
