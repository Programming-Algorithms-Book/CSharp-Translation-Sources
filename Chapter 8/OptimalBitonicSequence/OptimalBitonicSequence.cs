using System;

class Program
{
    struct ST 
    {
        public int Len { get; set; }    /* Дължина на максималната ненамаляваща подредица, завършваща в i */
        public int Back { get; set; } /* Индекс на предишния елемент в макс. редица */
        public long Sum { get; set; } /* Сума на елементите на максималната редица */
    }
    
    static int[] x = { 0, 10, 20, 15, 40, 5, 4, 300, 2, 1}; /* Височини на дърветата */
    static readonly int n = x.Length - 1;    /* Брой крайпътни дървета */
    static ST[] max1 = new ST[n+1];
    static ST[] max2 = new ST[n+1];
    
    static int[] x2 = new int[n+1];
    static int[] rez = new int[n];
    static int top;
    static long bestLen, bestSum;
    
    static void Main()
    {
        Solve();
        BuildSequence();
        Print();
    }
    
    /* Търси нарастваща редица */
    static void FindIncSequence(ST[] max, int[] x)
    {
        /* Основен цикъл */
        for (int i = 1; i <= n; i++)
        {
            max[i].Len = 0;
            max[i].Sum = 0;
            for (int j = 0; j < i; j++)
                if (x[j] <= x[i])
                    if ((max[j].Len + 1 > max[i].Len) || 
                            ((max[j].Len + 1 == max[i].Len) && 
                             (max[j].Sum + x[i] > max[i].Sum)))
                    {
                        max[i].Back = j;
                        max[i].Len = max[j].Len + 1;
                        max[i].Sum = max[j].Sum + x[i];
                    }
        }
    }
    
    /* Построява обърнато копие на редицата */
    static void Reverse(int[] x2, int[] x)
    {
        for (int i = 1; i <= n; i++)
            x2[i] = x[n-i+1];
    }
    
    /* Намира търсената редица */
    static void Solve()
    {
        /* стъпка (1) */
        FindIncSequence(max1, x);
        /* стъпка (2) */
        Reverse(x2, x);
        FindIncSequence(max2, x2);
        /* стъпка (3) */
        bestLen = 0;
        bestSum = 0;
        for (int i = 1; i <= n; i++)
        {
            if (((max1[i].Len + max2[n-i+1].Len > bestLen)) || 
                    ((max1[i].Len + max2[n-i+1].Len == bestLen) && 
                     (max1[i].Sum + max2[n-i+1].Sum > bestSum)))
            {
                bestLen = max1[i].Len + max2[n-i+1].Len;
                bestSum = max1[i].Sum + max2[n-i+1].Sum; /* Трябва да се намали с 1 */
                top = i;
            }
        }
    }
    
    /* Построява търсената редица */
    static void BuildSequence()
    {
        int t = top;
        int len = 0;
        /* Построяване на нарастващата част на редицата */
        for (int l = max1[t].Len; t != 0; t = max1[t].Back)
            rez[l-len++] = x[t];
        /* Построяване на намаляващата част на редицата */
        for (t = max2[n-top+1].Back; t != 0; t = max2[t].Back)
            rez[++len] = x2[t];
    }
    
    /* Извежда резултата на екрана */
    static void Print()
    {
        Console.WriteLine("Максимален брой дървета, които могат да се запазят: {0}", bestLen-1);
        for (int i = 1; i < bestLen; i++)
        Console.Write("{0} ", rez[i]);
        Console.WriteLine();
    }
}
