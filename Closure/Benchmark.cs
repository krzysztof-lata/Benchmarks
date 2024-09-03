using BenchmarkDotNet.Attributes;

namespace Closure;

[MemoryDiagnoser]
public class Benchmark
{
    [Benchmark]
    public int ExecuteStatic_WithoutClosure()
    {
        return ExecuteStatic(() => 5);
    }
    
    [Benchmark]
    public int ExecuteStatic_WithClosure()
    {
        var x = 5;
        return ExecuteStatic(() => x);
    }
    
    [Benchmark]
    public int ExecuteStatic_WithState()
    {
        var state = 5;
        return ExecuteStatic(state, x => x);
    }
    
    [Benchmark]
    public int ExecuteInstance_WithoutClosure()
    {
        return ExecuteInstance(() => 5);
    }
    
    [Benchmark]
    public int ExecuteInstance_WithClosure()
    {
        var x = 5;
        return ExecuteInstance(() => x);
    }
    
    [Benchmark]
    public int ExecuteInstance_WithState()
    {
        var state = 5;
        return ExecuteInstance(state, x => x);
    }
    
    private T ExecuteInstance<T>(Func<T> func)
    {
        return func();
    }
    
    private T ExecuteInstance<TState, T>(TState state, Func<TState, T> func)
    {
        return func(state);
    }
    
    private static T ExecuteStatic<T>(Func<T> func)
    {
        return func();
    }
    
    private static T ExecuteStatic<TState, T>(TState state, Func<TState, T> func)
    {
        return func(state);
    }
}