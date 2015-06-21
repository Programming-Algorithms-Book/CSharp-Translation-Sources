namespace BreakNum
{
    using System;

    public class BreakNum
    {
        private const int Max = 100;
        private const int N = 10;

        private static readonly int[,] F = new int[Max, Max]; /* Целева функция */

        /* Намира броя на представянията на n като сума от естествени числа */

        internal static void Main()
        {
            Console.WriteLine(
                              "Броят на представянията на {0} като сума от естествени числа е: {1}",
                              N,
                              GetNum(N));
        }

        private static int GetNum(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (1 == j)
                    {
                        F[i, j] = 1;
                    }
                    else if (1 == i)
                    {
                        F[i, j] = 1;
                    }
                    else if (i < j)
                    {
                        F[i, j] = F[i, i];
                    }
                    else if (i == j)
                    {
                        F[i, j] = 1 + F[i, i - 1];
                    }
                    else
                    {
                        F[i, j] = F[i, j - 1] + F[i - j, j];
                    }
                }
            }

            return F[n, n];
        }
    }
}