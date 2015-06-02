using System;

class Program
{
    static int[] x = { 100, 10, 15, 5, 25, 22, 12, 22 }; /* Редица */
                                                         /* Нулевият елемент на x[] не се използва! */
    static int n = x.Length - 1;     /* Брой елементи в редицата */
    static int[] LNS = new int[n+1]; /* LNS[i] - минимален елемент, който може да стои на позиция i */
    
    static void Main()
    {
        Console.WriteLine("Дължина на най-дългата ненамаляваща подредица: {0}", LNS_Length());
    }
    
    /* Намира дължината на най-дългата ненамаляваща подредица */
    static int LNS_Length()
    {
        int k=1;
        LNS[1] = x[1];
        for (int i = 2; i <= n; i++)
        {
            if (x[i] < LNS[1])                /* случай 1 */
                LNS[1] = x[i];
            else if (x[i] >= LNS[k])          /* случай 2 */
                LNS[++k] = x[i];
            else {                            /* случай 3 */
                int l = 1;
                int r = k;                    /* двоично търсене */
                while (l < r - 1)
                {
                    int med = (l + r) / 2;
                    if (LNS[med] <= x[i])
                    l = med;
                    else
                    r = med;
                }
                LNS[r] = x[i];
            }
        }
        return k;
    }
}
