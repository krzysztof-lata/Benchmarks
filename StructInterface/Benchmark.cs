using System.Dynamic;
using BenchmarkDotNet.Attributes;

namespace StructInterface;

[MemoryDiagnoser]
public class Benchmark
{
    private TestStruct _testStruct;
    private TestReadonlyStruct _testReadonlyStruct;

    [GlobalSetup]
    public void Setup()
    {
        _testStruct = new TestStruct(123, "name");
        _testReadonlyStruct = new TestReadonlyStruct(123, "name");
    }
    
    [Benchmark]
    public int GetId()
    {
        return GetId(_testStruct);
    }
    
    [Benchmark]
    public int GetIdGeneric()
    {
        return GetIdGeneric(_testStruct);
    }
    
    [Benchmark]
    public int ReadonlyStruct_GetId()
    {
        return GetId(_testReadonlyStruct);
    }
    
    [Benchmark]
    public int ReadonlyStruct_GetIdGeneric()
    {
        return GetIdGeneric(_testReadonlyStruct);
    }

    private static int GetId(IHasId id) => id.GetId();

    private static int GetIdGeneric<T>(T id) where T : IHasId => id.GetId();
}