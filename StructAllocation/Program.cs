Create();

void Create()
{
    string[] list = ["abc", null, "def"];
    var ofType = list.OfType<string>();
    //var testStruct = new TestStruct(10_000);
    Console.ReadKey();
}

public struct TestStruct
{
    public int[] Data;

    public TestStruct(int size)
    {
        Data = stackalloc int[size].ToArray();
        for (int i = 0; i < Data.Length; i++)
        {
            Data[i] = i;
        }
    }
}