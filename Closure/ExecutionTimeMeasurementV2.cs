using System.Diagnostics;

namespace Closure;

public sealed class ExecutionTimeMeasurementV2<TContext>(Action<TimeSpan, TContext> action, TContext context)
    : IDisposable
{
    private readonly long _startTime = Stopwatch.GetTimestamp();

    public void Dispose() => action(Stopwatch.GetElapsedTime(_startTime),  context);
}