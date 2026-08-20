using System.Security.AccessControl;
using BenchmarkDotNet.Attributes;

namespace Closure;

[MemoryDiagnoser]
public class ExecutionTimeMeasurementBenchmark
{

    private Context _context;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _context = new Context();
    }
    
    [Benchmark]
    public void Measure()
    {
        using var x = new ExecutionTimeMeasurement(elapsedTime => _context.ExecutionTime = elapsedTime);
    }
    
    [Benchmark]
    public void MeasureV2()
    {
        using var x = new ExecutionTimeMeasurementV2<Context>(static (elapsedTime, context) => context.ExecutionTime = elapsedTime, _context);
    }
    
    private class Context
    {
        public TimeSpan ExecutionTime { get; set; }
    }
}