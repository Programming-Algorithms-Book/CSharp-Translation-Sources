namespace SevenQueensProblem
{
    using System;

    public class Program
    {
        /* Максимален размер на дъската */
        private const int MaxN = 100;

        /* Размер на дъската */
        private const uint N = 13;

        private static uint[] col = new uint[MaxN],
            RD = new uint[(2 * MaxN) - 1],
            LD = new uint[2 * MaxN],
            queens = new uint[MaxN];

        internal static void Main(string[] args)
        {
            uint i;
            for (i = 0; i < N; i++)
            {
                col[i] = 1;
            }

            for (i = 0; i < ((2 * N) - 1); i++)
            {
                RD[i] = 1;
            }

            for (i = 0; i < 2 * N; i++)
            {
                LD[i] = 1;
            }

            Generate(0);
            Console.WriteLine("Задачата няма решение!");
        }

        /* Отпечатва намереното разположение на цариците */
        private static void PrintBoard()
        {
            uint i, j;
            for (i = 0; i < N; i++)
            {
                Console.WriteLine();
                for (j = 0; j < N; j++)
                {
                    if (queens[i] == j)
                    {
                        Console.Write("x ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
            }

            Console.WriteLine();
            Environment.Exit(0);
        }

        /* Намира следваща позиция за поставяне на царица */
        private static void Generate(uint i)
        {
            if (i == N)
            {
                PrintBoard();
            }

            uint k;
            for (k = 0; k <= N; k++)
            {
                if (col[k] != 0 && RD[i + k] != 0 && LD[N + i - k] != 0)
                {
                    col[k] = 0;
                    RD[i + k] = 0;
                    LD[N + i - k] = 0;
                    queens[i] = k;
                    Generate(i + 1);
                    col[k] = 1;
                    RD[i + k] = 1;
                    LD[N + i - k] = 1;
                }
            }
        }
    }
}