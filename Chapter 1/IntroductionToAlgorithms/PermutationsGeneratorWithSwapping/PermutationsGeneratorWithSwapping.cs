namespace PermutationsGeneratorWithSwapping
{
    using System;

    public class PermutationsGeneratorWithSwapping
    {
        private const uint N = 3;

        private static readonly uint[] Permutation = new uint[N];

        internal static void Main()
        {
            for (uint i = 0; i < N; i++)
            {
                Permutation[i] = i;
            }

            GeneratePermutations(N);
        }

        private static void Print()
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write("{0} ", Permutation[i] + 1);
            }

            Console.WriteLine();
        }

        private static void GeneratePermutations(uint k)
        {
            if (k == 0)
            {
                Print();
                return;
            }

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
    }
}
