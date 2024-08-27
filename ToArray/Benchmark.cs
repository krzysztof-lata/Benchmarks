using BenchmarkDotNet.Attributes;

namespace ToArray;

[MemoryDiagnoser]
public class Benchmark
{
    private static readonly Random _random = new Random(123);
    
    [Params(1, 10, 100, 1000)] public int Count;
    
    private int[] _array;
    private List<int> _list;
    private IEnumerable<int> _enumerateArray;
    
    private IEnumerable<int> _arraySelect;
    private IEnumerable<int> _listSelect;
    private IEnumerable<int> _enumerateArraySelect;
    
    private IEnumerable<int> _arrayWhere;
    private IEnumerable<int> _listWhere;
    private IEnumerable<int> _enumerateArrayWhere;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _array = Enumerable.Range(1, Count).Select(_ => _random.Next()).ToArray();
        _list = new List<int>(_array);
        _enumerateArray = EnumerateArray(_array);
        
        _arraySelect = _array.Select(x => x + 1);
        _listSelect = _list.Select(x => x + 1);
        _enumerateArraySelect = EnumerateArray(_array).Select(x => x + 1);
        
        _arrayWhere = _array.Where(x => x > 0);
        _listWhere = _list.Where(x => x > 0);
        _enumerateArrayWhere = EnumerateArray(_array).Where(x => x > 0);
    }

    [Benchmark]
    public int[] ArrayToArray()
    {
        return _array.ToArray();
    }
    
    [Benchmark]
    public int[] ListToArray()
    {
        return _list.ToArray();
    }
    
    [Benchmark]
    public int[] EnumerateArrayToArray()
    {
        return _enumerateArray.ToArray();
    }
    
    [Benchmark]
    public int[] ArraySelectToArray()
    {
        return _arraySelect.ToArray();
    }
    
    [Benchmark]
    public int[] ListSelectToArray()
    {
        return _listSelect.ToArray();
    }
    
    [Benchmark]
    public int[] EnumerateArraySelectToArray()
    {
        return _enumerateArraySelect.ToArray();
    }
    
    [Benchmark]
    public int[] ArrayWhereToArray()
    {
        return _arrayWhere.ToArray();
    }
    
    [Benchmark]
    public int[] ListWhereToArray()
    {
        return _listWhere.ToArray();
    }
    
    [Benchmark]
    public int[] EnumerateArrayWhereToArray()
    {
        return _enumerateArrayWhere.ToArray();
    }

    private IEnumerable<int> EnumerateArray(int[] array)
    {
        foreach (var item in array)
        {
            yield return item;
        }
    }
}