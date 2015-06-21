namespace SportSeries2
{
    using System;

    public class Program
    {
        private const double P = 0.5; /* Вероятност A да спечели отделен мач */
        private const int N = 5;

        private static readonly double?[,] Ps = new double?[N + 1, N + 1];

        internal static void Main()
        {
            PDynamic(N, N);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0:F6} ", Ps[i, j] ?? 0.0);
                }

                Console.WriteLine();
            }
        }

        private static double PDynamic(int i, int j)
        {
            for (int k = 1; k <= i; k++)
            {
                Ps[0, k] = 1;
            }

            for (int k = 1; k <= j; k++)
            {
                Ps[k, 0] = 0;
            }

            return PDyn(i, j);
        }

        private static double PDyn(int i, int j) /* Динамично оптимиране */
        {
            if (!Ps[i, j].HasValue)
            {
                Ps[i, j] = (P * PDyn(i - 1, j)) + ((1 - P) * PDyn(i, j - 1));
            }

            return Ps[i, j].Value;
        }
    }
}