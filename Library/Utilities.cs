namespace Library
{
    internal static class Utilities
    {
        public static Random Random = new();

        public static int GetRandomInt(int max) => Random.Next(max);

        public static decimal GetRandomDecimal() => (decimal)Random.NextDouble();
    }
}
