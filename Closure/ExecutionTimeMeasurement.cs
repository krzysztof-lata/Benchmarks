using System.Diagnostics;

namespace Closure;

public sealed class ExecutionTimeMeasurement : IDisposable
{
    private readonly long _startTime;
    private readonly Action<TimeSpan> _action;

    public ExecutionTimeMeasurement(Action<TimeSpan> action)
    {
        _action = action;
        _startTime = Stopwatch.GetTimestamp();
    }

    public void Dispose()
    {
        var elapsedTime = Stopwatch.GetElapsedTime(_startTime);
        _action(elapsedTime);
    }
}