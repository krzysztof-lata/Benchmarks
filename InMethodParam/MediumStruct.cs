public struct MediumStruct
{
    public int Id { get; set; }
    
    public string Name { get; init; }
    
    public bool IsActive { get; init; }
    
    public DateTime CreatedAt { get; init; }

    public decimal Value { get; init; }

    public static MediumStruct Create(int seed)
    {
        var random = new Random(seed);
        return new MediumStruct()
        {
            Id = random.Next(),
            Name = $"Name_{random.Next()}",
            IsActive = random.Next() % 2 == 0,
            CreatedAt = new DateTime(2024, 09, 03).AddSeconds(random.Next()),
            Value = Convert.ToDecimal(random.NextDouble()),
        };
    }
}