namespace StructInterface;

public struct TestStruct : IHasId
{
    public TestStruct(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    
    public int GetId() => Id;
}