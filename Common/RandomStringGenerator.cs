namespace Common;

public class RandomStringGenerator
{
    private readonly Random _random;
    private const string Chars = "abcdefghijklmnopqrst";

    public RandomStringGenerator(int seed)
    {
        _random = new Random(seed);
    }

    public string Create(int length)
    {
        return new string(Enumerable.Range(1, length).Select(_ => Chars[_random.Next(Chars.Length)]).ToArray());
    }
}