using System;

class PascalTriangle
{
    const uint n = 7;
    const uint k = 3;
    static ulong[] lastLine = new ulong[n + 1];

    static void Main()
    {
        lastLine[0] = 1;
        for (uint i = 1; i <= n; i++)
        {
            lastLine[i] = 1;
            for (uint j = i - 1; j >= 1; j--)
                lastLine[j] += lastLine[j - 1];
        }

        Console.WriteLine("C({0}, {1}) = {2}", n, k, lastLine[k]);
    }
}
