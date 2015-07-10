namespace SportSeries3
{
    using System;

    public class Program
    {
        private const double NotCalculated = -1;
        private const double P = 0.5; /* Вероятност A да спечели отделен мач */
        private const int N = 5;

        private static readonly double[,] Ps = new double[N + 1, N + 1];

        internal static void Main()
        {
            PDynamic2(N, N);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0:F6} ", Ps[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static double PDynamic2(int i, int j)
        {
            for (int k = 1; k <= i; k++)
            {
                for (int l = 1; l <= j; l++)
                {
                    Ps[k, l] = NotCalculated;
                }
            }

            for (int k = 1; k <= i; k++)
            {
                Ps[k, 0] = 0.0;
            }

            for (int k = 1; k <= j; k++)
            {
                Ps[0, k] = 1.0;
            }

            return PDyn(i, j);
        }

        /* Динамично оптимиране */
        private static double PDyn(int i, int j)
        {
            if (Ps[i, j] < 0)
            {
                Ps[i, j] = (P * PDyn(i - 1, j)) + ((1 - P) * PDyn(i, j - 1));
            }

            return Ps[i, j];
        }
    }
}