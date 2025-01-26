using System.IO.Hashing;
using System.Text;

namespace CacheKey.Types;

public static class RoomUnavailableCacheKey
{
    private const string KeyPrefix = "RU";

    public static string[] From(RoomUnavailabilityRequest request, IEnumerable<RoomUnavailabilityData> rooms)
    {
        return rooms.Select(roomData =>
        {
            var hashFunction = new XxHash32();
            hashFunction.Append(Encoding.UTF8.GetBytes(roomData.RoomName));
            var roomNameHash = hashFunction.GetCurrentHashAsUInt32();
            return
                $"{KeyPrefix}:{request.HotelId}:{request.NumberOfNights}:{request.Adults}:{request.Children}:{request.CheckIn.ToString("yyMMdd")}:{(int)roomData.CancellationPolicyType}:{(int)roomData.BoardType}:{roomNameHash}";
        }).ToArray();
    }
    
    public static string[] From_Opt(RoomUnavailabilityRequest request, IEnumerable<RoomUnavailabilityData> rooms)
    {
        var hashFunction = new XxHash32();
        return rooms.Select(roomData =>
        {
            hashFunction.Append(Encoding.UTF8.GetBytes(roomData.RoomName));
            var roomNameHash = hashFunction.GetCurrentHashAsUInt32();
            hashFunction.Reset();
            return
                $"{KeyPrefix}:{request.HotelId}:{request.NumberOfNights}:{request.Adults}:{request.Children}:{request.CheckIn.ToString("yyMMdd")}:{(int)roomData.CancellationPolicyType}:{(int)roomData.BoardType}:{roomNameHash}";
        }).ToArray();
    }
}

public sealed class RoomUnavailableCacheKeyPrecomputed
{
    private readonly string _requestKeyPrefix;
    private const string KeyPrefix = "RU";

    public RoomUnavailableCacheKeyPrecomputed(RoomUnavailabilityRequest request)
    {
        _requestKeyPrefix = $"{KeyPrefix}:{request.HotelId}:{request.NumberOfNights}:{request.Adults}:{request.Children}:{request.CheckIn.ToString("yyMMdd")}";
    }

    public string[] From(IEnumerable<RoomUnavailabilityData> rooms)
    {
        return rooms.Select(roomData =>
        {
            var hashFunction = new XxHash32();
            hashFunction.Append(Encoding.UTF8.GetBytes(roomData.RoomName));
            var roomNameHash = hashFunction.GetCurrentHashAsUInt32();
            return
                $"{_requestKeyPrefix}:{(int)roomData.CancellationPolicyType}:{(int)roomData.BoardType}:{roomNameHash}";
        }).ToArray();
    }
    
    public string[] From_Opt(IEnumerable<RoomUnavailabilityData> rooms)
    {
        var hashFunction = new XxHash32();
        return rooms.Select(roomData =>
        {
            hashFunction.Append(Encoding.UTF8.GetBytes(roomData.RoomName));
            var roomNameHash = hashFunction.GetCurrentHashAsUInt32();
            hashFunction.Reset();
            return
                $"{_requestKeyPrefix}:{(int)roomData.CancellationPolicyType}:{(int)roomData.BoardType}:{roomNameHash}";
        }).ToArray();
    }
}