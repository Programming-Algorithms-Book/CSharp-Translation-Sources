namespace PermutationsGenerator
{
    using System;
    using System.Collections.Generic;

    public class PermutationsGenerator
    {
        private const uint N = 3;

        private static readonly uint[] Permutation = new uint[N];
        private static readonly HashSet<uint> Used = new HashSet<uint>();

        internal static void Main()
        {
            GeneratePermutations(0);
        }

        private static void Print()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write("{0} ", Permutation[i] + 1);
            }

            Console.WriteLine();
        }

        private static void GeneratePermutations(uint i)
        {
            if (i >= N)
            {
                Print();
                return;
            }

            for (uint k = 0; k < N; k++)
            {
                if (!Used.Contains(k))
                {
                    Used.Add(k);
                    Permutation[i] = k;
                    GeneratePermutations(i + 1);
                    Used.Remove(k);
                }
            }
        }
    }
}
