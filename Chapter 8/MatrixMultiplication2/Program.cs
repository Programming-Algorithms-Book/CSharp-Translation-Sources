namespace MatrixMultiplication2
{
    using System;

    public class Program
    {
        private const long NotSolved = long.MaxValue;
        private static readonly long[] R = new long[] { 12, 13, 35, 3, 34, 2, 21, 10, 21, 6 }; /* Размерности на матриците */
        private static readonly int N = R.Length - 1; /* Брой матрици */
        private static readonly long[,] M = new long[N + 1, N + 1]; /* Таблица - целева функция */

        internal static void Main()
        {
            Console.WriteLine("Минималният брой умножения е: {0}", SolveMemoization());
            PrintMatrix();
        }

        private static long SolveMemo(int i, int j)
        {
            /* Стойността вече е била пресметната */
            if (M[i, j] != NotSolved)
            {
                return M[i, j];
            }

            /* В този интервал няма матрица */
            if (i == j)
            {
                M[i, j] = 0;
            }
            else
            {
                /* Пресмятаме рекурсивно */
                for (int k = i; k <= j - 1; k++)
                {
                    long q = SolveMemo(i, k) + SolveMemo(k + 1, j) + (R[i - 1] * R[k] * R[j]);
                    if (q < M[i, j])
                    {
                        M[i, j] = q;
                    }
                }
            }

            return M[i, j];
        }

        private static long SolveMemoization()
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = i; j <= N; j++)
                {
                    M[i, j] = NotSolved;
                }
            }

            return SolveMemo(1, N);
        }

        private static void PrintMatrix() /* Извежда матрицата на минимумите на екрана */
        {
            Console.WriteLine("Матрица на минимумите:");
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    Console.Write("{0, 8}", M[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}