using System;

class Program
{
    static int[] s = {0, 23, 15, 89, 170, 25, 1, 86, 80, 2, 27};    /* Редица (нулевият елемент не се ползва) */
    static readonly int n = s.Length - 1;    /* Брой елементи в редицата */
    const int k = 4;     /* Брой групи */
    static long[] p = new long[n+1];       /* Префиксни суми */
    static long[,] f = new long[n+1, n+1]; /* Целева функция */
    static long[,] b = new long[n+1, n+1]; /* За възстановяване на решението */

    static void Main()
    {
        Console.Write("Максимална сума в някоя от групите: {0}", DoPartition(k));
        PrintPartition(n, k);
    }    
    
    /* Извършва оптимално разделяне на k групи */
    static long DoPartition(int k)
    {
        p[0] = 0;
        /* Пресмятане на префиксните суми */
        for (int i = 1; i <= n; i++)
            p[i] = p[i - 1] + s[i];
        /* Установяване на граничните условия */
        for (int i = 1; i <= n; i++)
            f[i, 1] = p[i];
        for (int j = 1; j <= k; j++)
            f[1, j] = s[1];
        /* Основен цикъл */
        for (int i = 2; i <= n; i++)
            for (int j = 2; j <= k; j++)
            {
                f[i, j] = long.MaxValue;
                for (int l = 1; l <= i - 1; l++)
                {
                    long m = Math.Max(f[l, j - 1], p[i] - p[l]);
                    if (m < f[i, j])
                    {
                        f[i, j] = m;
                        b[i, j] = l;
                    }
                }
            }
        return f[n, k];
    }
    
    static void Print(long from, long to)
    {
        Console.Write("\n");
        for (long i = from; i <= to; i++)
            Console.Write("{0} ", s[i]);
    }
    
    static void PrintPartition(long n, long k)
    {
        if (k == 1)
            Print(1, n);
        else {
            PrintPartition(b[n, k], k - 1);
            Print(b[n, k] + 1, n);
        }
    }
}
