namespace CacheKey.Types;

public readonly struct RoomUnavailabilityRequest
{
    public required long HotelId { get; init; }

    public required int Adults { get; init; }

    public required int Children { get; init; }

    public required DateOnly CheckIn { get; init; }

    public required int NumberOfNights { get; init; }
}