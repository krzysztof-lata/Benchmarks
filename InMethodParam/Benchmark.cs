using BenchmarkDotNet.Attributes;

namespace InMethodParam;

[MemoryDiagnoser]
public class Benchmark
{
    private SmallStruct _smallStruct;
    private MediumStruct _mediumStruct;
    private LargeStruct _largeStruct;

    [GlobalSetup]
    public void Setup()
    {
        _smallStruct = SmallStruct.Create(123);
        _mediumStruct = MediumStruct.Create(123);
        _largeStruct = LargeStruct.Create(123);
    }

    [Benchmark]
    public int SmallStruct_GetId()
    {
        return GetId(_smallStruct);
    }
    
    [Benchmark]
    public int MediumStruct_GetId()
    {
        return GetId(_mediumStruct);
    }
    
    [Benchmark]
    public int LargeStruct_GetId()
    {
        return GetId(_largeStruct);
    }
    
    [Benchmark]
    public int SmallStruct_GetId_In()
    {
        return GetId(in _smallStruct);
    }
    
    [Benchmark]
    public int MediumStruct_GetId_In()
    {
        return GetId(in _mediumStruct);
    }
    
    [Benchmark]
    public int LargeStruct_GetId_In()
    {
        return GetId(in _largeStruct);
    }
    
    private static int GetId(SmallStruct obj) => obj.Id;
    
    private static int GetId(MediumStruct obj) => obj.Id;
    
    private static int GetId(LargeStruct obj) => obj.Id;
    
    private static int GetId(in SmallStruct obj) => obj.Id;
    
    private static int GetId(in MediumStruct obj) => obj.Id;
    
    private static int GetId(in LargeStruct obj) => obj.Id;
}