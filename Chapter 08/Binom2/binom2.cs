namespace Binom2
{
    using System;

    public class Binom2
    {
        private const int Max = 200;

        /* Динамично оптимиране */
        private static readonly int[] Array = new int[Max];

        internal static void Main()
        {
            Console.WriteLine(CalculateBinomDynamic(7, 3));
        }

        private static int CalculateBinomDynamic(int n, int k)
        {
            int j;
            for (int i = 0; i <= n; i++)
            {
                Array[i] = 1;
                if (i > 1)
                {
                    if (k < i - 1)
                    {
                        j = k;
                    }
                    else
                    {
                        j = i - 1;
                    }

                    for (; j >= 1; j--)
                    {
                        Array[j] += Array[j - 1];
                    }
                }
            }

            return Array[k];
        }
    }
}