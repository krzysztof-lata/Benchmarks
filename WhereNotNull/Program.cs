using BenchmarkDotNet.Running;
using WhereNotNull;

//var benchmark = new Benchmark();
// var whereSelectNullForgiving = benchmark.WhereSelectNullForgiving();
// var ofType = benchmark.OfType();
// var whereCast = benchmark.WhereCast();
// var @foreach = benchmark.Foreach();
BenchmarkRunner.Run<Benchmark>();