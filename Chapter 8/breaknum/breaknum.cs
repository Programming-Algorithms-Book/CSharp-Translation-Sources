using System;

internal class breaknum
{
    private const int Max = 100;
    private const int N = 10;

    private static int[,] f = new int[Max, Max]; /* Целева функция */

    /* Намира броя на представянията на n като сума от естествени числа */

    private static int GetNum(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (1 == j)
                {
                    f[i, j] = 1;
                }
                else if (1 == i)
                {
                    f[i, j] = 1;
                }
                else if (i < j)
                {
                    f[i, j] = f[i, i];
                }
                else if (i == j)
                {
                    f[i, j] = 1 + f[i, i - 1];
                }
                else
                {
                    f[i, j] = f[i, j - 1] + f[i - j, j];
                }
            }
        }
        return f[n, n];
    }

    private static void Main()
    {
        Console.WriteLine("Броят на представянията на {0} като сума от естествени числа е: {1}",
                          N, GetNum(N));
    }
}