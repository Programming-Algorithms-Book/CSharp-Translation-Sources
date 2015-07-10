namespace Taxi
{
    using System;

    public class Program
    {
        private const int MaxN = 100; /* Максимален брой километри */
        private const int MaxK = 20; /* Максимален брой спирки */
        private const int N = 15;
        private const int K = 10;

        private static readonly Dist[] Dist = new Dist[MaxN];

        private static readonly int[] Values = { 0, 12, 21, 31, 40, 49, 58, 69, 79, 90, 101 };

        internal static void Main()
        {
            Solve(N);
            Print(N);
        }

        /* Решава задачата чрез динамично оптимиране */
        private static void Solve(int n)
        {
            Dist[0].Value = 0;
            for (int i = 1; i <= n; i++)
            {
                Dist[i].Value = int.MaxValue;
                for (int j = 1; j <= K && j <= i; j++)
                {
                    if (Dist[i - j].Value + Values[j] < Dist[i].Value)
                    {
                        Dist[i].Value = Dist[i - j].Value + Values[j];
                        Dist[i].Last = j;
                    }
                }
            }
        }

        /* Извежда резултата на екрана */
        private static void Print(int n)
        {
            Console.WriteLine("Обща стойност на пътуването: {0}", Dist[n].Value);
            Console.WriteLine("Дължина и стойности на отделните отсечки:");
            while (n > 0)
            {
                Console.WriteLine("{0} {1}", Dist[n].Last, Values[Dist[n].Last]);
                n -= Dist[n].Last;
            }
        }
    }
}