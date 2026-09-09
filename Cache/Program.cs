// See https://aka.ms/new-console-template for more information


using Cache;

await new HybridCacheTest().Run();
//await new MemoryCacheTest().Run();
//await new ConcurrentDictionaryTest().Run();

Console.ReadKey();