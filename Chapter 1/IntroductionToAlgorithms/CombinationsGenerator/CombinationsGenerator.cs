namespace CombinationsGenerator
{
    using System;

    public class CombinationsGenerator
    {
        private const uint N = 5;
        private const uint K = 3;

        private static readonly uint[] Combination = new uint[K];

        internal static void Main()
        {
            Console.WriteLine("C({0}, {1}): ", N, K);
            GenerateCombinations(1, 0);
        }

        private static void Print()
        {
            for (uint i = 0; i < K; i++)
            {
                Console.Write("{0} ", Combination[i]);
            }

            Console.WriteLine();
        }

        private static void GenerateCombinations(uint i, uint after)
        {
            if (i > K)
            {
                return;
            }

            for (uint j = after + 1; j <= N; j++)
            {
                Combination[i - 1] = j;
                if (i == K)
                {
                    Print();
                }

                GenerateCombinations(i + 1, j);
            }
        }
    }
}
