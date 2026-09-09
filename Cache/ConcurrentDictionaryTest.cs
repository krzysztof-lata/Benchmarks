using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Cache;

public class ConcurrentDictionaryTest
{
    private readonly ConcurrentDictionary<string, int> _cache = new();

    public async Task Run()
    {
        int counter = 0;
        Parallel.ForEach(Enumerable.Range(0, 99), _ =>
        {
            var result =_cache.GetOrAdd("key", _ =>
            {
                var x = Interlocked.Increment(ref counter);
                return x;
            }); 
            Console.WriteLine(result);
        });
        
        Console.WriteLine(counter);
    }
}