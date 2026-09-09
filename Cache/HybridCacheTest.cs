using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;

namespace Cache;

public class HybridCacheTest
{
    private readonly HybridCache _hybridCache;

    public HybridCacheTest()
    {
        var services = new ServiceCollection();
        services.AddHybridCache(options =>
        {
            options.DefaultEntryOptions = new HybridCacheEntryOptions()
            {
                Flags = HybridCacheEntryFlags.DisableDistributedCache,
            };
        });
        var serviceProvider = services.BuildServiceProvider();

        _hybridCache = serviceProvider.GetRequiredService<HybridCache>();
    }

    public async Task Run()
    {
        int counter = 0;
        var tasks = Enumerable.Range(0, 99)
            .Select(async i => await _hybridCache.GetOrCreateAsync("1", async _ =>
            {
                Interlocked.Increment(ref counter);
                await Task.Delay(Random.Shared.Next(100, 200));
                return 1;
            }));

        await Task.WhenAll(tasks);
        Console.WriteLine(counter);
    }
}