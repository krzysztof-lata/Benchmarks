using BenchmarkDotNet.Attributes;
using CacheKey.Types;

namespace CacheKey;

[MemoryDiagnoser]
public class Benchmark
{
    private static readonly Random _random = new Random(123);
    
    [Params(1, 10, 100)] public int Count;
    
    private static BoardType[] _boardTypes = Enum.GetValues<BoardType>();
    private static CancellationPolicyType[] _cancellationPolicyTypes = Enum.GetValues<CancellationPolicyType>();
    
    private static RoomUnavailabilityData[] _roomsSource = Enumerable.Range(1, 100).Select(_ => new RoomUnavailabilityData
    {
        RoomName = Guid.NewGuid().ToString(),
        BoardType = _boardTypes[_random.Next(_boardTypes.Length)],
        CancellationPolicyType = _cancellationPolicyTypes[_random.Next(_cancellationPolicyTypes.Length)]
    }).ToArray();

    private RoomUnavailabilityRequest _roomUnavailabilityRequest;
    private RoomUnavailabilityData[] _rooms;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        _roomUnavailabilityRequest = new RoomUnavailabilityRequest
        {
            HotelId = 1254789,
            Adults = 2,
            Children = 0,
            CheckIn = new DateOnly(2025, 02, 23),
            NumberOfNights = 2
        };
        
        _rooms = _roomsSource.Take(Count).ToArray();
    }

    [Benchmark]
    public string[] CacheKey()
    {
        return RoomUnavailableCacheKey.From(_roomUnavailabilityRequest, _rooms);
    }
    
    [Benchmark]
    public string[] CacheKey_Opt()
    {
        return RoomUnavailableCacheKey.From_Opt(_roomUnavailabilityRequest, _rooms);
    }
    
    [Benchmark]
    public string[] CacheKeyPrecomputed()
    {
        return new RoomUnavailableCacheKeyPrecomputed(_roomUnavailabilityRequest).From(_rooms);
    }
    
    [Benchmark]
    public string[] CacheKeyPrecomputed_Opt()
    {
        return new RoomUnavailableCacheKeyPrecomputed(_roomUnavailabilityRequest).From_Opt(_rooms);
    }
}