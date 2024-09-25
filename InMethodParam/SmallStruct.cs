public struct SmallStruct
{
    public int Id { get; set; }

    public static SmallStruct Create(int seed)
    {
        var random = new Random(seed);
        return new SmallStruct()
        {
            Id = random.Next(),
        };
    } 
}