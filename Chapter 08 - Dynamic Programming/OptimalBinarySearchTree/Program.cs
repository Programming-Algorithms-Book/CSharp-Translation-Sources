namespace OptimalBinarySearchTree
{
    using System;

    public class Program
    {
        private static readonly long[] F = { 2, 7, 1, 3, 4, 6, 5 }; /* Честоти на срещане */
        private static readonly int N = F.Length; /* Брой честоти */
        private static readonly long[,] M = new long[N + 2, N + 1]; /* Таблица - целева функция */

        internal static void Main()
        {
            Solve();
            Console.WriteLine("Минималната дължина на претегления вътрешен път е: {0}", M[1, N]);
            PrintMatrix();
            Console.WriteLine();
            Console.WriteLine("Оптимално дърво за претърсване:");
            GetOrder(1, N, 0);
        }

        /* Построява оптимално двоично дърво за претърсване */
        private static void Solve()
        {
            /* Инициализация */
            for (int i = 1; i <= N; i++)
            {
                M[i, i] = F[i - 1];
                M[i, i - 1] = 0;
            }

            M[N + 1, N] = 0;

            /* Основен цикъл */
            for (int j = 1; j <= N - 1; j++)
            {
                for (int i = 1; i <= N - j; i++)
                {
                    M[i, i + j] = long.MaxValue;
                    for (int k = i; k <= i + j; k++)
                    {
                        /* Подобряваме текущото решение */
                        long t = M[i, k - 1] + M[k + 1, i + j];
                        if (t < M[i, i + j])
                        {
                            M[i, i + j] = t;
                            M[i + j + 1, i] = k;
                        }
                    }

                    for (int k = i - 1; k < i + j; k++)
                    {
                        M[i, i + j] += F[k];
                    }
                }
            }
        }

        /* Извежда матрицата на минимумите на екрана */
        private static void PrintMatrix()
        {
            Console.WriteLine("Матрица на минимумите:");
            for (int i = 1; i <= N + 1; i++)
            {
                Console.Write("\n");
                for (int j = 1; j <= N; j++)
                {
                    Console.Write("{0, 8}", M[i, j]);
                }
            }
        }

        /* Извежда оптималното дърво на екрана */
        private static void GetOrder(long ll, long rr, long h)
        {
            if (ll > rr)
            {
                return;
            }

            if (ll == rr)
            {
                for (int i = 0; i < h; i++)
                {
                    Console.Write("     ");
                }

                Console.WriteLine("d{0}", rr);
            }
            else
            {
                GetOrder(ll, M[rr + 1, ll] - 1, h + 1);
                for (int i = 0; i < h; i++)
                {
                    Console.Write("     ");
                }

                Console.WriteLine("d{0}", M[rr + 1, ll]);
                GetOrder(M[rr + 1, ll] + 1, rr, h + 1);
            }
        }
    }
}