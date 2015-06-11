namespace VariationsGenerator
{
    using System;

    public class VariationsGenerator
    {
        private const uint N = 4;
        private const uint K = 2;

        private static readonly uint[] Variation = new uint[K];

        internal static void Main()
        {
            GenerateVariations(0);
        }

        private static void Print(uint i)
        {
            Console.Write("( ");
            for (uint k = 0; k < i; k++)
            {
                Console.Write("{0} ", Variation[k] + 1);
            }

            Console.WriteLine(")");
        }

        // Вариации на n елемента от клас k
        private static void GenerateVariations(uint i)
        {
            /* Без if (i >= k) и return; тук (а само Print(i); ако искаме всички
         * генерирания с дължина 1, 2, …, k, а не само вариациите с дължина k */
            if (i >= K)
            {
                Print(i);
                return;
            }

            for (uint j = 0; j < N; j++)
            {
                // if (allowed(k)) {
                Variation[i] = j;
                GenerateVariations(i + 1);
            }
        }
    }
}
