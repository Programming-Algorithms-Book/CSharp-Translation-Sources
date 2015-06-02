using System;

class CombinationsGenerator
{
    const uint n = 5;
    const uint k = 3;

    static readonly uint[] Combination = new uint[k];

    static void Print()
    {
        for (uint i = 0; i < k; i++) Console.Write("{0} ", Combination[i]);
        Console.WriteLine();
    }

    static void GenerateCombinations(uint i, uint after)
    {
        if (i > k) return;
        for (uint j = after + 1; j <= n; j++)
        {
            Combination[i - 1] = j;
            if (i == k) Print();
            GenerateCombinations(i + 1, j);
        }
    }

    static void Main()
    {
        Console.WriteLine("C({0}, {1}): ", n, k);
        GenerateCombinations(1, 0);
    }
}
