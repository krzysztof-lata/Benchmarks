namespace CacheKey.Types;

public enum CancellationPolicyType : byte
{
    Refundable = 1,
    NonRefundable = 2,
    PartialRefundable = 3,
}