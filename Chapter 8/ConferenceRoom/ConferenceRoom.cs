using System;

class Program
{
    struct BeginEnd 
    {
        public int Begin { get; set; }
        public int End { get; set; }
    }
    
    struct BlueRed
    {
        public int CntBlue { get; set; }
        public int CntRed { get; set; }
    } 
    
    const int MAXN = 5000;   /* Максимален брой заявки */
    const int MAXD = 365;    /* Максимален брой дни */
    
    static BlueRed[] B = new BlueRed[MAXD+1];
    static BlueRed[] R = new BlueRed[MAXD+1];
    
    static BeginEnd[] blueOrders = new [] { new BeginEnd { Begin = 1, End = 5 }, 
        new BeginEnd { Begin = 12, End = 20} };
    static BeginEnd[] redOrders = new [] { new BeginEnd { Begin = 2, End = 10}, 
        new BeginEnd { Begin = 6, End = 11}, 
        new BeginEnd { Begin = 15, End = 25}, 
        new BeginEnd { Begin = 26, End = 30} };
                                       
    static readonly int n = blueOrders.Length; /* Брой сини заявки */
    static readonly int m = redOrders.Length;  /* Брой червени заявки */
    
    static void Main()
    {
        Array.Sort(blueOrders, (rb1, rb2) => rb1.End.CompareTo(rb2.End));
        Array.Sort(redOrders, (rb1, rb2) => rb1.End.CompareTo(rb2.End));
        SolveDynamic();
        PrintResult();
    }
    /* Решава задачата с динамично оптимиране */
    static void SolveDynamic()
    {
        int d, bb, be, blueIndex, redIndex;
        /* Инициализация */
        B[0].CntBlue = B[0].CntRed = R[0].CntBlue = R[0].CntRed = 0; 
        blueIndex = redIndex = 1;
        /* Пресмятане на B[1..MAXD], R[1..MAXD] */
        for (d = 1; d <= MAXD; d++)
        {
            /* Пресмятане на B[d] */
            B[d] = B[d - 1];
            for (blueIndex = 0; blueIndex < n; blueIndex++)
            {
                if (blueOrders[blueIndex].End > d)
                    break;
                else 
                {
                    bb = blueOrders[blueIndex].Begin;
                    be = blueOrders[blueIndex].End;
                    if (R[bb-1].CntBlue + R[bb-1].CntRed + (be-bb+1) > B[d].CntBlue + B[d].CntRed)
                    {
                        B[d].CntBlue = R[bb - 1].CntBlue + (be - bb + 1);
                        B[d].CntRed = R[bb - 1].CntRed + 0;
                    }
                }
            }
            /* Пресмятане на R[d]: аналогично на B[d] */
            R[d] = R[d - 1];
            for (redIndex = 0; redIndex < m; redIndex++)
            {
                if (redOrders[redIndex].End > d)
                    break;
                else 
                {
                    bb = redOrders[redIndex].Begin;
                    be = redOrders[redIndex].End;
                    if (B[bb-1].CntBlue + B[bb-1].CntRed + (be-bb+1) > R[d].CntBlue + R[d].CntRed)
                    {
                        R[d].CntBlue = B[bb - 1].CntBlue;
                        R[d].CntRed = B[bb - 1].CntRed + (be - bb + 1);
                    }
                }
            }
        }
    }
    
    /* Извежда резултата на екрана */
    static void PrintResult()
    {
        if (B[MAXD].CntBlue + B[MAXD].CntRed > R[MAXD].CntBlue + R[MAXD].CntRed)
        {
            Console.WriteLine("Заетост на залата (дни): {0}", B[MAXD].CntBlue + B[MAXD].CntRed);
            Console.WriteLine("Брой дни за червените: {0}", B[MAXD].CntRed);
            Console.WriteLine("Брой дни за сините: {0}", B[MAXD].CntBlue);
        }
        else 
        {
            Console.WriteLine("Заетост на залата (дни): {0}", R[MAXD].CntBlue + R[MAXD].CntRed);
            Console.WriteLine("Брой дни за червените: {0}", R[MAXD].CntRed);
            Console.WriteLine("Брой дни за сините: {0}", R[MAXD].CntBlue);
        }
    }
}
