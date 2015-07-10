namespace Partitioning
{
    using System;

    public class Program
    {
        private const int K = 4; /* Брой групи */

        private static readonly int[] S = { 0, 23, 15, 89, 170, 25, 1, 86, 80, 2, 27 }; /* Редица (нулевият елемент не се ползва) */
        private static readonly int N = S.Length - 1; /* Брой елементи в редицата */
        private static readonly long[] P = new long[N + 1]; /* Префиксни суми */
        private static readonly long[,] F = new long[N + 1, N + 1]; /* Целева функция */
        private static readonly long[,] B = new long[N + 1, N + 1]; /* За възстановяване на решението */

        internal static void Main()
        {
            Console.Write("Максимална сума в някоя от групите: {0}", DoPartition(K));
            PrintPartition(N, K);
        }

        /* Извършва оптимално разделяне на k групи */
        private static long DoPartition(int k)
        {
            P[0] = 0;
            /* Пресмятане на префиксните суми */
            for (int i = 1; i <= N; i++)
            {
                P[i] = P[i - 1] + S[i];
            }

            /* Установяване на граничните условия */
            for (int i = 1; i <= N; i++)
            {
                F[i, 1] = P[i];
            }

            for (int j = 1; j <= k; j++)
            {
                F[1, j] = S[1];
            }

            /* Основен цикъл */
            for (int i = 2; i <= N; i++)
            {
                for (int j = 2; j <= k; j++)
                {
                    F[i, j] = long.MaxValue;
                    for (int l = 1; l <= i - 1; l++)
                    {
                        long m = Math.Max(F[l, j - 1], P[i] - P[l]);
                        if (m < F[i, j])
                        {
                            F[i, j] = m;
                            B[i, j] = l;
                        }
                    }
                }
            }

            return F[N, k];
        }

        private static void Print(long from, long to)
        {
            Console.WriteLine();
            for (long i = from; i <= to; i++)
            {
                Console.Write("{0} ", S[i]);
            }
        }

        private static void PrintPartition(long n, long k)
        {
            if (k == 1)
            {
                Print(1, n);
            }
            else
            {
                PrintPartition(B[n, k], k - 1);
                Print(B[n, k] + 1, n);
            }
        }
    }
}