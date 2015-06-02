using System;

class Program
{
    static void Main()
    {
        int[] v = { 50, 40, 30, 20, 15 };
        int[] d = { 2,  1,  2,  2,  1 };
        /* оригинална номерация на задачите */
        int[] p = { 5,  1,  2,  4,  3 };
    
        Solve(d, v, p);
    }
    
    static bool Feasible(int[] index, int[] d, int k)
    {
        int s = 0;
        for (int i = 0; i < index.Length; i++)
        {
            s += index[i];
            if (i == d[k] - 1) s += 1;
            if (s > i + 1) return false;
        }
    
        return true;
    }
    
    static void Solve(int[] d, int[] v, int[] p)
    {
        int[] index = new int[d.Length];
        int[] taken = new int[d.Length];
        int tn = 0;
        for (int k = 0; k < index.Length; k++)
            if (Feasible(index, d, k))
            {
                taken[tn++] = k;
                index[d[k] - 1]++;
            }
    
        Console.Write("Оптимално разписание: ");
    
        int income = 0;
        for (int i = 0; i < tn; i++)
        {
            Console.Write("{0} ", p[taken[i]]);
            income += v[taken[i]];
        }
        
        Console.WriteLine();
        Console.WriteLine("Общ доход: {0}", income);
    }
}