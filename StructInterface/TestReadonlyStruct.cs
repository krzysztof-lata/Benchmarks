namespace StructInterface;

public readonly struct TestReadonlyStruct : IHasId
{
    public TestReadonlyStruct(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }
    
    public int GetId() => Id;
}