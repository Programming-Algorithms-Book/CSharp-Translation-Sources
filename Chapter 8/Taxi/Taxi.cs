using System;

internal class Program
{
    private const int MAXN = 100; /* Максимален брой километри */
    private const int MAXK = 20; /* Максимален брой спирки */

    private struct Dist
    {
        public int Last { get; set; } /* Последна измината отсечка */
        public int Value { get; set; } /* Цена на разстоянието */
    }

    private static Dist[] dist = new Dist[MAXN];

    private static int[] Values = { 0, 12, 21, 31, 40, 49, 58, 69, 79, 90, 101 };
    private const int n = 15;
    private const int k = 10;

    private static void Main()
    {
        Solve(n);
        Print(n);
    }

    private static void Solve(int n) /* Решава задачата чрез динамично оптимиране */
    {
        dist[0].Value = 0;
        for (int i = 1; i <= n; i++)
        {
            dist[i].Value = int.MaxValue;
            for (int j = 1; j <= k && j <= i; j++)
            {
                if (dist[i - j].Value + Values[j] < dist[i].Value)
                {
                    dist[i].Value = dist[i - j].Value + Values[j];
                    dist[i].Last = j;
                }
            }
        }
    }

    private static void Print(int n) /* Извежда резултата на екрана */
    {
        Console.WriteLine("Обща стойност на пътуването: {0}", dist[n].Value);
        Console.WriteLine("Дължина и стойности на отделните отсечки:");
        while (n > 0)
        {
            Console.WriteLine("{0} {1}", dist[n].Last, Values[dist[n].Last]);
            n -= dist[n].Last;
        }
    }
}