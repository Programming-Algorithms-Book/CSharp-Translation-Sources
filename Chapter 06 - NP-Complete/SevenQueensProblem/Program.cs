namespace SevenQueensProblem
{
    using System;

    public class Program
    {
        /* Максимален размер на дъската */
        private const int MaxN = 100;

        /* Размер на дъската */
        private const uint N = 13;

        private static readonly uint[] Col = new uint[MaxN];
        private static readonly uint[] Rd = new uint[(2 * MaxN) - 1];
        private static readonly uint[] Ld = new uint[2 * MaxN];
        private static readonly uint[] Queens = new uint[MaxN];

        internal static void Main(string[] args)
        {
            uint i;
            for (i = 0; i < N; i++)
            {
                Col[i] = 1;
            }

            for (i = 0; i < ((2 * N) - 1); i++)
            {
                Rd[i] = 1;
            }

            for (i = 0; i < 2 * N; i++)
            {
                Ld[i] = 1;
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
                    if (Queens[i] == j)
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
                if (Col[k] != 0 && Rd[i + k] != 0 && Ld[N + i - k] != 0)
                {
                    Col[k] = 0;
                    Rd[i + k] = 0;
                    Ld[N + i - k] = 0;
                    Queens[i] = k;
                    Generate(i + 1);
                    Col[k] = 1;
                    Rd[i + k] = 1;
                    Ld[N + i - k] = 1;
                }
            }
        }
    }
}