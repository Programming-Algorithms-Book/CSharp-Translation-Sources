namespace MatrixMultiplication1
{
    using System;

    public class Program
    {
        private static readonly long[] R = new long[] { 12, 13, 35, 3, 34, 2, 21, 10, 21, 6 }; /* Размерности на матриците */
        private static readonly int N = R.Length - 1; /* Брой матрици */
        private static readonly long[,] M = new long[N + 1, N + 1]; /* Таблица - целева функция */

        internal static void Main()
        {
            Console.WriteLine("Минималният брой умножения е: {0}", SolveRecursive(1, N));
            PrintMatrix();
        }

        /* Неефективна рекурсивна функция */

        private static long SolveRecursive(int i, int j)
        {
            if (i == j)
            {
                return 0;
            }

            M[i, j] = int.MaxValue;
            for (int k = i; k <= j - 1; k++)
            {
                long q = SolveRecursive(i, k) +
                         SolveRecursive(k + 1, j) +
                         (R[i - 1] *
                          R[k] *
                          R[j]);
                if (q < M[i, j])
                {
                    M[i, j] = q;
                }
            }

            return M[i, j];
        }

        private static void PrintMatrix() /* Извежда матрицата на минимумите на екрана */
        {
            Console.Write("Матрица на минимумите:");
            for (int i = 1; i <= N; i++)
            {
                Console.Write("\n");
                for (int j = 1; j <= N; j++)
                {
                    Console.Write("{0, 8}", M[i, j]);
                }
            }
        }
    }
}