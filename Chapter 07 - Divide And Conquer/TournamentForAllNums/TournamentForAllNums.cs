namespace TournamentForAllNums
{
    using System;

    public class TournamentForAllNums
    {
        private const int MaxMatrixSize = 100;

        internal static void Main()
        {
            const int NumberOfTeams = 4;
            int[,] matrix = new int[MaxMatrixSize, MaxMatrixSize];
            FindSolution(matrix, NumberOfTeams);
            Print(matrix, NumberOfTeams);
        }

        private static void CopyMatrix(int[,] matrix, int stX, int stY, int count, int add)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    matrix[i + stX, j + stY] = matrix[i + 1, j + 1] + add;
                }
            }
        }

        /* Построява таблицата */
        private static void FindSolution(int[,] matrix, int n)
        {
            int i;
            /* Ако n е четно, задачата се свеждаме към n-1 */
            if (n % 2 == 0)
            {
                n--;
            }

            /* Попълва се таблицата за n - тук е гарантирано нечетно. */
            for (i = 0; i < n * (n + 1); i++)
            {
                matrix[i % (n + 1), i / (n + 1)] = (i % n) + 1;
            }

            /* Възстановява се стойността на n */
            if (n % 2 == 1)
            {
                n++;
            }

            for (i = 0; i < n; i++)
            {
                /* Запълват се последният стълб и ред при четно n */
                if (n % 2 == 0)
                {
                    matrix[i, n - 1] = matrix[n - 1, i] = matrix[i, i];
                }

                /* Запълва се с 0 главният диагонал */
                matrix[i, i] = 0;
            }
        }

        /* Извежда резултата */
        private static void Print(int[,] m, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0} ", m[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}