namespace Tournament3
{
    using System;

    public class Tournament3
    {
        private const int MaxMatrixSize = 100;

        internal static void Main()
        {
            int numberOfTeams = 4;
            int[,] matrix = new int[MaxMatrixSize, MaxMatrixSize];
            FindSolution(matrix, numberOfTeams);
            Print(matrix, numberOfTeams);
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
            /* Ако n е четно, задачата се свежда към n-1 */
            if (n % 2 == 0)
            {
                n--;
            }

            /* Попълване на таблицата за n - тук е гарантирано нечетно. */
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = i + j < n ? i + j + 1 : i + j + 1 - n;
                }
            }

            /* Възстановяване на стойността на n */
            if (n % 2 == 1)
            {
                n++;
            }

            for (int i = 0; i < n; i++)
            {
                /* Запълване на последния стълб и ред при четно n */
                if (n % 2 == 0)
                {
                    matrix[i, n - 1] = matrix[n - 1, i] = matrix[i, i];
                }

                matrix[i, i] = 0; /* Запълване с 0 на главния диагонал */
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