namespace BooleanSatisfiability
{
    using System;

    public class Program
    {
        private const int Maxn = 100; /* Максимален брой булеви променливи */
        private const int Maxk = 100; /* Максимален брой дизюнкти */

        private const uint N = 4;  /* Брой на булевите променливи */
        private const uint K = 5;  /* Брой на дизюнктите */

        private static int[][] expr = new int[][]
        {
            new int[] { 1, 4, 0 },
            new int[] { -1, 2, 0 },
            new int[] { 1, -3, 0 },
            new int[] { -2, 3, -4, 0 },
            new int[] { -1, -2, -3, 0 }
        };

        private static int[] values = new int[Maxn];

        ////internal static void Main(string[] args)
        ////{
        ////    Assign(0);
        ////}

        private static void PrintAssignment()
        {
            Console.Write("Изразът е удовлетворим за: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write("X{0}={1} ", i + 1, values[i]);
            }

            Console.WriteLine();
        }

        /* поне един литерал трябва да има стойност “истина” във всеки дизюнкт */
        private static int True()
        {
            for (int i = 0; i < K; i++)
            {
                uint j = 0;
                int ok = 0;
                while (expr[i][j] != 0)
                {
                    int p = expr[i][j];
                    if ((p > 0) && (1 == values[p - 1]))
                    {
                        ok = 1;
                        break;
                    }

                    if ((p < 0) && (0 == values[-p - 1]))
                    {
                        ok = 1;
                        break;
                    }

                    j++;
                }

                if (ok == 0)
                {
                    return 0;
                }
            }

            return 1;
        }

        /* присвоява стойности на променливите */
        private static void Assign(uint i)
        {
            if (i == N)
            {
                if (True() == 1)
                {
                    PrintAssignment();
                }

                return;
            }

            values[i] = 1;
            Assign(i + 1);
            values[i] = 0;
            Assign(i + 1);
        }
    }
}