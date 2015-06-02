using System;

class Program
{
    static int[] x = { 100, 10, 15, 5, 25, 22, 12, 22 }; /* Редица */
                                                         /* Нулевият елемент на x[] не се използва! */
    static int n = x.Length - 1;      /* Брой елементи в редицата */
    
    static int[] LNS = new int[n+1];  /* Дължина на максималната редица с начало x[i] */
    static int[] next = new int[n+1]; /* Индекс на следващ елемент */
    
    static void Main()
    {
        int start = -1;
        Console.WriteLine("Дължина на най-дългата ненамаляваща подредица: {0}", LNS_Length(ref start));
        Console.Write("Подредицата: "); LNS_Print(start);
    }
    
    /* Намира дължината на най-дългата ненамаляваща подредица */
    static int LNS_Length(ref int start)
    {
        int len = 0; /* Максимална (за момента) дължина на ненамаляваща подредица */
        for (int i = n; i >= 1; i--)
        {
            int l = 0; /* В момента на разглеждане на xi, 
                       /* l е дължината на максималната подредица с начало xj: */
                       /*        1) i < j <= n и */
                       /*        2) xi <= xj         */
            for (int j = i + 1; j <= n; j++)
                if (x[j] >= x[i] && LNS[j] > l)
                {
                    l = LNS[j];
                    next[i] = j;
                }
            LNS[i] = l + 1;
            if (LNS[i] > len)
            {
                len = LNS[i];
                start = i;
            }
        }
        return len;
    }
    
    /* Извежда най-дългата ненамаляваща подредица */
    static void LNS_Print(int start)
    {
        for (; LNS[start] >= 1; start = next[start])
            Console.Write(" {0}", x[start]);
    }
}