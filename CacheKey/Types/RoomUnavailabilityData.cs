namespace CacheKey.Types;

public readonly struct RoomUnavailabilityData
{
    public required string RoomName { get; init; }
    
    public required BoardType BoardType { get; init; }
    
    public required CancellationPolicyType CancellationPolicyType { get; init; }
}