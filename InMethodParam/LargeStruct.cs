public struct LargeStruct
{
    public int Id { get; set; }
    
    public string Name { get; init; }
    
    public bool IsActive { get; init; }
    
    public DateTime CreatedAt { get; init; }

    public decimal Value { get; init; }
    
    public int Id2 { get; init; }
    
    public string Name2 { get; init; }
    
    public bool IsActive2 { get; init; }
    
    public DateTime CreatedAt2 { get; init; }
    
    public decimal Value2 { get; init; }
    
    public int Id3 { get; init; }
    
    public string Name3 { get; init; }
    
    public bool IsActive3 { get; init; }
    
    public DateTime CreatedAt3 { get; init; }
    
    public decimal Value3 { get; init; }
    
    public int Id4 { get; init; }
    
    public string Name4 { get; init; }
    
    public bool IsActive4 { get; init; }
    
    public DateTime CreatedAt4 { get; init; }
    
    public decimal Value4 { get; init; }
    
    public static LargeStruct Create(int seed)
    {
        var random = new Random(seed);
        return new LargeStruct()
        {
            Id = random.Next(),
            Name = $"Name_{random.Next()}",
            IsActive = random.Next() % 2 == 0,
            CreatedAt = new DateTime(2024, 09, 03).AddSeconds(random.Next()),
            Value = Convert.ToDecimal(random.NextDouble()),
            
            Id2 = random.Next(),
            Name2 = $"Name_{random.Next()}",
            IsActive2 = random.Next() % 2 == 0,
            CreatedAt2 = new DateTime(2024, 09, 03).AddSeconds(random.Next()),
            Value2 = Convert.ToDecimal(random.NextDouble()),
            
            Id3 = random.Next(),
            Name3 = $"Name_{random.Next()}",
            IsActive3 = random.Next() % 2 == 0,
            CreatedAt3 = new DateTime(2024, 09, 03).AddSeconds(random.Next()),
            Value3 = Convert.ToDecimal(random.NextDouble()),
            
            Id4 = random.Next(),
            Name4 = $"Name_{random.Next()}",
            IsActive4 = random.Next() % 2 == 0,
            CreatedAt4 = new DateTime(2024, 09, 03).AddSeconds(random.Next()),
            Value4 = Convert.ToDecimal(random.NextDouble()),
        };
    }
}