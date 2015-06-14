using System;

internal class Program
{
    private const long NOT_CALCULATED = long.MaxValue;

    private static long[] dist = { 0, 3, 7, 8, 13, 15, 23 }; /* Разстояние от началната гара */

    private const long l1 = 3,
                       l2 = 6,
                       l3 = 8,
                       c1 = 20,
                       c2 = 30,
                       c3 = 40;

    private static readonly int n = dist.Length - 1;
    private static long[] minPrice = new long[n]; /* Минимална цена на билета от началната до текущата гара */

    private const int end = 6;
    private static int start = 2;

    private static void Main()
    {
        /* Иницализация */
        int i;
        for (i = 0; i < start; i++)
        {
            minPrice[i] = 0;
        }
        for (; i < n; i++)
        {
            minPrice[i] = NOT_CALCULATED;
        }
        /* Решаване на задачата */
        start--;
        Console.WriteLine("Минимална цена: {0}", Calc(end - 1));
    }

    private static long Calc(int cur)
    {
        long price;
        int i;
        if (minPrice[cur] == NOT_CALCULATED)
        {
            /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 1 */
            for (i = cur - 1; i >= start && (dist[cur] - dist[i]) <= l1; i--)
            {
                ;
            }
            if (++i < cur)
            {
                if ((price = Calc(i) + c1) < minPrice[cur])
                {
                    minPrice[cur] = price;
                }
            }
            /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 2 */
            for (; i >= start && (dist[cur] - dist[i]) <= l2; i--)
            {
                ;
            }
            if (++i < cur)
            {
                if ((price = Calc(i) + c2) < minPrice[cur])
                {
                    minPrice[cur] = price;
                }
            }
            /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 3 */
            for (; i >= start && (dist[cur] - dist[i]) <= l3; i--)
            {
                ;
            }
            if (++i < cur)
            {
                if ((price = Calc(i) + c3) < minPrice[cur])
                {
                    minPrice[cur] = price;
                }
            }
        }
        return minPrice[cur];
    }
}