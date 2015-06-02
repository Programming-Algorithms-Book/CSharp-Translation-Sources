using System;
using System.Collections.Generic;

class PermutationsGenerator
{
    const uint n = 3;

    static readonly uint[] Permutation = new uint[n];
    static readonly HashSet<uint> Used = new HashSet<uint>();

    static void Print()
    {
        for (int i = 0; i < n; i++) Console.Write("{0} ", Permutation[i] + 1);
        Console.WriteLine();
    }

    static void GeneratePermutations(uint i)
    {
        if (i >= n) { Print(); return; }
        for (uint k = 0; k < n; k++)
            if (!Used.Contains(k))
            {
                Used.Add(k);
                Permutation[i] = k;
                GeneratePermutations(i + 1);
                Used.Remove(k);
            }
    }

    static void Main()
    {
        GeneratePermutations(0);
    }
}
