// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Running;
using CacheKey;

// var benchmark = new Benchmark();
// benchmark.Count = 100;
// benchmark.GlobalSetup();
// var keys1 = benchmark.CacheKey();
// var keys2 = benchmark.CacheKey_Opt();
// var keys3 = benchmark.CacheKeyPrecomputed();
// var keys4 = benchmark.CacheKeyPrecomputed_Opt();
// Console.ReadKey();

BenchmarkRunner.Run<Benchmark>();