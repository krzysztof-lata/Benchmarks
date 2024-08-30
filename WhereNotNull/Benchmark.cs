using BenchmarkDotNet.Attributes;

namespace WhereNotNull;

[MemoryDiagnoser]
public class Benchmark
{
    private static string?[] data = ["abc", null, "def", null, "ghi", null, "jkl", null];

    [Benchmark]
    public string[] WhereSelectNullForgiving()
    {
        return data.Where(s => s is not null).Select(s => s!).ToArray();
    }
    
    [Benchmark]
    public string[] OfType()
    {
        return data.OfType<string>().ToArray();
    }
    
    [Benchmark]
    public string[] WhereCast()
    {
        return data.Where(s => s is not null).Cast<string>().ToArray();
    }
    
    [Benchmark]
    public string[] Foreach()
    {
        return WhereNotNull(data).ToArray();
    }
    
    private static IEnumerable<T> WhereNotNull<T>(IEnumerable<T?> source)
    {
        foreach (var item in source)
        {
            if (item is not null)
            {
                yield return item;
            }
        }
    }
}