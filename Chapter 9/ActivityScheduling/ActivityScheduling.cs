using System;

class Program
{
    static void Main()
    {
        int[] start = { 3, 5, 7, 9, 13, 15, 17 };
        int[] end = { 8, 10, 12, 14, 15, 19, 20 };
        Array.Sort(start, end);
        Solve(start, end);
    }
    
    static void Solve(int[] start, int[] end)
    {
        int i = 1, j = 1;
        Console.Write("Избрани лекции: {0} ", 1);
    
        while (j++ < start.Length)
            if (start[j - 1] > end[i - 1]) 
            {
                Console.Write("{0} ", j);
                i = j;
            }
        Console.WriteLine();
    }
}