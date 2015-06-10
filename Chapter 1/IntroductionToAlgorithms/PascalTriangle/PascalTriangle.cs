namespace PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        private const uint N = 7;
        private const uint K = 3;
        private static ulong[] lastLine = new ulong[N + 1];

        internal static void Main()
        {
            lastLine[0] = 1;
            for (uint i = 1; i <= N; i++)
            {
                lastLine[i] = 1;
                for (uint j = i - 1; j >= 1; j--)
                {
                    lastLine[j] += lastLine[j - 1];
                }
            }

            Console.WriteLine("C({0}, {1}) = {2}", N, K, lastLine[K]);
        }
    }
}
