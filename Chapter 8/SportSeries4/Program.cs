namespace SportSeries4
{
    using System;

    public class Program
    {
        private const double P = 0.5; /* Вероятност A да спечели отделен мач */
        private const int N = 5;

        internal static void Main()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0:F6} ", PDynamic3(i, j));
                }

                Console.WriteLine();
            }
        }

        private static double PDynamic3(int i, int j)
        {
            double[,] pd = new double[(2 * N) - 1, (2 * N) - 1];
            for (int s = 1; s <= i + j; s++)
            {
                pd[0, s] = 1.0;
                pd[s, 0] = 0.0;
                for (int k = 1; k <= s - 1; k++)
                {
                    pd[k, s - k] = (P * pd[k - 1, s - k]) + ((1 - P) * pd[k, s - k - 1]);
                }
            }

            return pd[i, j];
        }
    }
}