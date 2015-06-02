using System;

class Program
{
    const string x = "acbcacbcaba";       /* Първа редица */
    const string y = "abacacacababa";     /* Втора редица */
    
    static void Main()
    {
        Console.WriteLine("Дължина на най-дългата обща подредица: {0}", LCS_Length());
    }
    
    /* Намира дължината на най-дългата обща подредица */
    static int LCS_Length()
    {
        int m = x.Length;                 /* Дължина на първата редица */
        int n = y.Length;                 /* Дължина на втората редица */
        int[,] f = new int[m + 1, n + 1]; /* Целева функция */
        /* Начална инициализация */
        for (int i = 1; i <= m; i++)
            f[i, 0] = 0;
        for (int j = 0; j <= n; j++)
            f[0, j] = 0;
        /* Основен цикъл */
        for (int i = 1; i <= m; i++)
            for (int j = 1; j <= n; j++)
                if (x[i - 1] == y[j - 1])
                    f[i, j] = f[i - 1, j - 1] + 1;
                else
                    f[i, j] = Math.Max(f[i - 1, j], f[i, j - 1]);
        return f[m, n];
    }
}