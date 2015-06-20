namespace BooleanSatisfiability
{
    using System;

    public class Boolcut
    {
        /* Максимален брой булеви променливи */
        private const int MaxN = 100;

        /* Максимален брой дизюнкти */
        private const int MaxK = 100;

        private const uint N = 4;  /* Брой на булевите променливи */
        private const uint K = 5;  /* Брой на дизюнктите */

        private static readonly int[][] Expr = new int[][]
        {
            new int[] { 1, 4, 0 },
            new int[] { -1, 2, 0 },
            new int[] { 1, -3, 0 },
            new int[] { -2, 3, -4, 0 },
            new int[] { -1, -2, -3, 0 }
        };

        private static readonly int[] Values = new int[MaxN];

        internal static void Main(string[] args)
        {
            Assign(0);
        }

        private static void PrintAssign()
        {
            Console.Write("Изразът е удовлетворим за: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write("X{0}={1} ", i + 1, Values[i]);
            }

            Console.Write("\n");
        }

        /* поне един литерал трябва да има стойност “истина” във всеки дизюнкт */
        private static int True(uint t)
        {
            for (int i = 0; i < K; i++)
            {
                uint j = 0;
                bool isOk = false;
                while (Expr[i][j] != 0)
                {
                    int p = Expr[i][j];
                    if ((p > t) || (-p > t))
                    {
                        isOk = true;
                        break;
                    }

                    if ((p > 0) && (1 == Values[p - 1]))
                    {
                        isOk = true;
                        break;
                    }

                    if ((p < 0) && (0 == Values[-p - 1]))
                    {
                        isOk = true;
                        break;
                    }

                    j++;
                }

                if (isOk == false)
                {
                    return 0;
                }
            }

            return 1;
        }

        /* присвоява стойности на променливите */
        private static void Assign(uint i)
        {
            if (True(i) == 0)
            {
                return;
            }

            if (i == N)
            {
                PrintAssign();
                return;
            }

            Values[i] = 1;
            Assign(i + 1);
            Values[i] = 0;
            Assign(i + 1);
        }
    }
}