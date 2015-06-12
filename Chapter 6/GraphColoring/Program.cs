namespace GraphColoring
{
    using System;

    public class Program
    {
        /* Максимален брой върхове в графа */
        private const int MaxN = 200;

        /* Брой върхове в графа */
        private const uint N = 5;

        /* Матрица на съседство на графа */
        private static readonly int[,] A =
        {
            { 0, 1, 0, 0, 1 },
            { 1, 0, 1, 1, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 1, 1, 0, 1 },
            { 1, 1, 0, 1, 0 }
        };

        private static uint maxCol, count = 0;
        private static uint[] col = new uint[MaxN];
        private int foundSol = 0;

        internal static void Main(string[] args)
        {
            uint i;
            for (maxCol = 1; maxCol <= N; maxCol++)
            {
                for (i = 0; i < N; i++)
                {
                    col[i] = 0;
                }

                NextCol(0);
                if (count > 0)
                {
                    break;
                }
            }

            Console.WriteLine("Общ брой намерени оцветявания с {0} цвята: {1} \n", maxCol, count);
        }

        private static void ShowSol()
        {
            uint i;
            count++;
            Console.WriteLine("Минимално оцветяване на графа: ");
            for (i = 0; i < N; i++)
            {
                Console.WriteLine("Връх {0} - с цвят {1} ", i + 1, col[i]);
            }
        }

        private static void NextCol(uint i)
        {
            uint k, j, success;

            if (i == N)
            {
                ShowSol();
                return;
            }

            for (k = 1; k <= maxCol; k++)
            {
                col[i] = k;
                success = 1;
                for (j = 0; j < N; j++)
                {
                    if (1 == A[i, j] && col[j] == col[i])
                    {
                        success = 0;
                        break;
                    }
                }

                if (success == 1)
                {
                    NextCol(i + 1);
                }

                col[i] = 0;
            }
        }
    }
}