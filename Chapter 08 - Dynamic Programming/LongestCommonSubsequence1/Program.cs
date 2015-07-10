namespace LongestCommonSubsequence1
{
    using System;

    public class Program
    {
        private const string X = "acbcacbcaba"; /* Първа редица */
        private const string Y = "abacacacababa"; /* Втора редица */

        internal static void Main()
        {
            Console.WriteLine("Дължина на най-дългата обща подредица: {0}", LcsLength());
        }

        /* Намира дължината на най-дългата обща подредица */

        private static int LcsLength()
        {
            int m = X.Length; /* Дължина на първата редица */
            int n = Y.Length; /* Дължина на втората редица */
            int[,] f = new int[m + 1, n + 1]; /* Целева функция */
            /* Начална инициализация */
            for (int i = 1; i <= m; i++)
            {
                f[i, 0] = 0;
            }

            for (int j = 0; j <= n; j++)
            {
                f[0, j] = 0;
            }

            /* Основен цикъл */
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        f[i, j] = f[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        f[i, j] = Math.Max(f[i - 1, j], f[i, j - 1]);
                    }
                }
            }

            return f[m, n];
        }
    }
}