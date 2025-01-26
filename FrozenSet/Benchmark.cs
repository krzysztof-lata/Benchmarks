using System.Collections.Frozen;
using BenchmarkDotNet.Attributes;
using Common;

namespace FrozenSet;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(1, 10, 100)] public int Count;
    
    private string[] source;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var stringGenerator = new RandomStringGenerator(154);
        source = Enumerable.Range(1, Count).Select(_ => stringGenerator.Create(50)).ToArray();
    }

    [Benchmark]
    public HashSet<string> CreateSet()
    {
        return source.ToHashSet();
    }
    
    [Benchmark]
    public FrozenSet<string> CreateFrozenSet()
    {
        return source.ToFrozenSet();
    }
}