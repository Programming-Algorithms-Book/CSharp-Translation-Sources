namespace RailwayTickets
{
    using System;

    public class Program
    {
        private const long NotCalculated = long.MaxValue;
        private const long L1 = 3;
        private const long L2 = 6;
        private const long L3 = 8;
        private const long C1 = 20;
        private const long C2 = 30;
        private const long C3 = 40;
        private const int End = 6;

        private static readonly long[] Dist = { 0, 3, 7, 8, 13, 15, 23 }; /* Разстояние от началната гара */
        private static readonly int N = Dist.Length - 1;
        private static readonly long[] MinPrice = new long[N]; /* Минимална цена на билета от началната до текущата гара */

        private static int start = 2;

        internal static void Main()
        {
            /* Иницализация */
            int i;
            for (i = 0; i < start; i++)
            {
                MinPrice[i] = 0;
            }

            for (; i < N; i++)
            {
                MinPrice[i] = NotCalculated;
            }

            /* Решаване на задачата */
            start--;
            Console.WriteLine("Минимална цена: {0}", Calc(End - 1));
        }

        private static long Calc(int cur)
        {
            long price;
            int i;
            if (MinPrice[cur] == NotCalculated)
            {
                /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 1 */
                for (i = cur - 1; i >= start && (Dist[cur] - Dist[i]) <= L1; i--)
                {
                }

                if (++i < cur)
                {
                    if ((price = Calc(i) + C1) < MinPrice[cur])
                    {
                        MinPrice[cur] = price;
                    }
                }

                /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 2 */
                for (; i >= start && (Dist[cur] - Dist[i]) <= L2; i--)
                {
                }

                if (++i < cur)
                {
                    if ((price = Calc(i) + C2) < MinPrice[cur])
                    {
                        MinPrice[cur] = price;
                    }
                }

                /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 3 */
                for (; i >= start && (Dist[cur] - Dist[i]) <= L3; i--)
                {
                }

                if (++i < cur)
                {
                    if ((price = Calc(i) + C3) < MinPrice[cur])
                    {
                        MinPrice[cur] = price;
                    }
                }
            }

            return MinPrice[cur];
        }
    }
}