using System;
using System.Collections.Generic;

class PermutationsGeneratorWithSwapping
{
    const uint n = 3;

    static readonly uint[] Permutation = new uint[n];

    static void Print()
    {
        for (int i = 0; i < n; i++) Console.Write("{0} ", Permutation[i] + 1);
        Console.WriteLine();
    }

    static void GeneratePermutations(uint k)
    {
        if (k == 0) { Print(); return; }
        GeneratePermutations(k - 1);
        for (uint i = 0; i < k - 1; i++)
        {
            uint swap = Permutation[i];
            Permutation[i] = Permutation[k - 1];
            Permutation[k - 1] = swap;

            GeneratePermutations(k - 1);

            swap = Permutation[i];
            Permutation[i] = Permutation[k - 1];
            Permutation[k - 1] = swap;
        }
    }

    static void Main()
    {
        for (uint i = 0; i < n; i++) Permutation[i] = i;
        GeneratePermutations(n);
    }
}
