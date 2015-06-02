using System;

class Program
{
    
    static long[] f = { 2, 7, 1, 3, 4, 6, 5 }; /* Честоти на срещане */
    static readonly int n = f.Length;          /* Брой честоти */
    static long[,] m = new long[n+2, n+1];     /* Таблица - целева функция */
    
    static void Main()
    {
         Solve();
         Console.WriteLine("Минималната дължина на претегления вътрешен път е: {0}", m[1, n]);
         PrintMatrix();
         Console.WriteLine();
         Console.WriteLine("Оптимално дърво за претърсване:"); GetOrder(1, n, 0);
    }
    
    /* Построява оптимално двоично дърво за претърсване */
    static void Solve()
    {
        /* Инициализация */
        for (int i = 1; i <= n; i++)
        {
            m[i, i] = f[i-1];
            m[i, i-1] = 0;
        }
        m[n+1, n] = 0;
        
        /* Основен цикъл */
        for (int j = 1; j <= n - 1; j++)
        {
            for (int i = 1; i <= n - j; i++)
            {
                m[i, i + j] = long.MaxValue;
                for (int k = i; k <= i + j; k++)
                {
                    /* Подобряваме текущото решение */
                    long t = m[i, k - 1] + m[k + 1, i + j];
                    if (t < m[i, i + j])
                    {
                        m[i, i + j] = t;
                        m[i + j + 1, i] = k;
                    }
                }
                for (int k = i-1; k < i + j; k++)
                    m[i, i+j] += f[k];
            }
        }
    }
    
    /* Извежда матрицата на минимумите на екрана */
    static void PrintMatrix()
    {
        Console.WriteLine("Матрица на минимумите:");
        for (int i = 1; i <= n+1; i++)
        {
            Console.Write("\n");
            for (int j = 1; j <= n; j++)
                Console.Write("{0, 8}", m[i, j]);
        }
    }
    
    /* Извежда оптималното дърво на екрана */
    static void GetOrder(long ll, long rr, long h)
    {
        if (ll > rr)
            return;
        if (ll == rr)
        {
            for (int i = 0; i < h; i++)
            Console.Write("     ");
            Console.WriteLine("d{0}", rr);
        }
        else {
            GetOrder(ll, m[rr + 1, ll] - 1, h + 1);
            for (int i = 0; i < h; i++)
             Console.Write("     ");
            Console.WriteLine("d{0}", m[rr + 1, ll]);
            GetOrder(m[rr + 1, ll] + 1, rr, h + 1);
        }
    }
}
