using System;

class Program
{
    
    static int[] x = { 100, 10, 15, 5, 25, 22, 12, 22 }; /* Редица */
                                                         /* Нулевият елемент на x[] не се използва! */
    static int n = x.Length - 1;                         /* Брой елементи в редицата */
    static int[,] LNS = new int[n+1, n+1];               /* Целева функция */
    
    static void Main()
    {
        int len = LNS_Length();
        Console.Write("Дължина на най-дългата ненамаляваща подредица: {0}", len);
        Console.WriteLine();
        Console.Write("Подредицата (обърната): "); LNS_Print(len);
        Console.WriteLine();
        Console.Write("Подредицата: "); LNS_Print2(n, len);
    }

    /* Намира дължината на най-дългата ненамаляваща подредица */
    static int LNS_Length()
    {
        /* Начална инициализация */
        for (int i = 0; i <= n; i++)
        {
            LNS[i, 0] = -1;
            for (int j = 1; j <= n; j++)
                LNS[i, j] = int.MaxValue;
        }
    
        /* Основен цикъл */
        int r = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (LNS[i - 1, j - 1] <= x[i] && 
                        x[i] <= LNS[i - 1, j] && 
                        LNS[i - 1, j - 1] <= LNS[i - 1, j])
                {
                    LNS[i, j] = x[i];
                    if (r < j)
                        r = j;
                }
                else
                    LNS[i, j] = LNS[i - 1, j];
            }
        }
    
        return r;
    }
    
    /* Извежда най-дългата ненамаляваща подредица (в обратен ред) */
    static void LNS_Print(int j)
    {
        int i = n;
        do {
            if (LNS[i, j] == LNS[i - 1, j])
                i--;
            else 
            {
                Console.Write("{0} ", x[i]);
                j--;
            }
        } while (i > 0);
    }
    
    /* Извежда най-дългата ненамаляваща подредица */
    static void LNS_Print2(int i, int j)
    {
        if (i == 0) return;
        if (LNS[i, j] == LNS[i - 1, j])
            LNS_Print2(i - 1, j);
        else 
        {
            LNS_Print2(i, j - 1);
            Console.Write("{0} ", x[i]);
        }
    }
}
