using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Cache;

public class MemoryCacheTest
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheTest()
    {
        var services = new ServiceCollection();
        services.AddMemoryCache();
        var serviceProvider = services.BuildServiceProvider();

        _memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();
    }

    public async Task Run()
    {
        int counter = 0;
        var tasks = Enumerable.Range(0, 10)
            .Select(async i =>
            {
                var result = await _memoryCache.GetOrCreateAsync("key", async _ =>
                {
                    await Task.Delay(Random.Shared.Next(100, 200));
                    Interlocked.Increment(ref counter);
                    return new Semaphore(1, 1);
                });
                Console.WriteLine(result);
                return result;
            });

        var results = await Task.WhenAll(tasks);
        Console.WriteLine(counter);
        
        Parallel.ForEach(Enumerable.Range(1, 10), i =>
        {
            var item = _memoryCache.GetOrCreate("test-key", cacheEntry =>
            {
                cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(10);
                return Interlocked.Increment(ref counter);
            });

            Console.Write($"{item} ");
        });
    }
}