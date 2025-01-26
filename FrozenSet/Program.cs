// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using FrozenSet;

// var benchmark = new Benchmark();
// benchmark.Count = 10;
// benchmark.GlobalSetup();
// var hashSet = benchmark.CreateSet();
// var frozenSet = benchmark.CreateFrozenSet();
// Console.ReadKey();


BenchmarkRunner.Run<Benchmark>();