namespace ConferenceRoom
{
    using System;

    public class Program
    {
        private const int MaxQueries = 5000; /* Максимален брой заявки */
        private const int MaxDays = 365; /* Максимален брой дни */

        private static readonly BlueRed[] B = new BlueRed[MaxDays + 1];
        private static readonly BlueRed[] R = new BlueRed[MaxDays + 1];

        private static readonly BeginEnd[] BlueOrders = new[]
        {
            new BeginEnd { Begin = 1, End = 5 },
            new BeginEnd { Begin = 12, End = 20 }
        };

        private static readonly BeginEnd[] RedOrders = new[]
        {
            new BeginEnd { Begin = 2, End = 10 },
            new BeginEnd { Begin = 6, End = 11 },
            new BeginEnd { Begin = 15, End = 25 },
            new BeginEnd { Begin = 26, End = 30 }
        };

        private static readonly int BlueOrdersCount = BlueOrders.Length; /* Брой сини заявки */
        private static readonly int RedOrdersCount = RedOrders.Length; /* Брой червени заявки */

        internal static void Main()
        {
            Array.Sort(BlueOrders, (rb1, rb2) => rb1.End.CompareTo(rb2.End));
            Array.Sort(RedOrders, (rb1, rb2) => rb1.End.CompareTo(rb2.End));
            SolveDynamic();
            PrintResult();
        }

        /* Решава задачата с динамично оптимиране */

        private static void SolveDynamic()
        {
            int d, bb, be, blueIndex, redIndex;
            /* Инициализация */
            B[0].BlueCount = B[0].RedCount = R[0].BlueCount = R[0].RedCount = 0;
            blueIndex = redIndex = 1;
            /* Пресмятане на B[1..MAXD], R[1..MAXD] */
            for (d = 1; d <= MaxDays; d++)
            {
                /* Пресмятане на B[d] */
                B[d] = B[d - 1];
                for (blueIndex = 0; blueIndex < BlueOrdersCount; blueIndex++)
                {
                    if (BlueOrders[blueIndex].End > d)
                    {
                        break;
                    }
                    else
                    {
                        bb = BlueOrders[blueIndex].Begin;
                        be = BlueOrders[blueIndex].End;
                        if (R[bb - 1].BlueCount + R[bb - 1].RedCount + (be - bb + 1) > B[d].BlueCount + B[d].RedCount)
                        {
                            B[d].BlueCount = R[bb - 1].BlueCount + (be - bb + 1);
                            B[d].RedCount = R[bb - 1].RedCount + 0;
                        }
                    }
                }

                /* Пресмятане на R[d]: аналогично на B[d] */
                R[d] = R[d - 1];
                for (redIndex = 0; redIndex < RedOrdersCount; redIndex++)
                {
                    if (RedOrders[redIndex].End > d)
                    {
                        break;
                    }
                    else
                    {
                        bb = RedOrders[redIndex].Begin;
                        be = RedOrders[redIndex].End;
                        if (B[bb - 1].BlueCount + B[bb - 1].RedCount + (be - bb + 1) > R[d].BlueCount + R[d].RedCount)
                        {
                            R[d].BlueCount = B[bb - 1].BlueCount;
                            R[d].RedCount = B[bb - 1].RedCount + (be - bb + 1);
                        }
                    }
                }
            }
        }

        /* Извежда резултата на екрана */

        private static void PrintResult()
        {
            if (B[MaxDays].BlueCount + B[MaxDays].RedCount > R[MaxDays].BlueCount + R[MaxDays].RedCount)
            {
                Console.WriteLine("Заетост на залата (дни): {0}", B[MaxDays].BlueCount + B[MaxDays].RedCount);
                Console.WriteLine("Брой дни за червените: {0}", B[MaxDays].RedCount);
                Console.WriteLine("Брой дни за сините: {0}", B[MaxDays].BlueCount);
            }
            else
            {
                Console.WriteLine("Заетост на залата (дни): {0}", R[MaxDays].BlueCount + R[MaxDays].RedCount);
                Console.WriteLine("Брой дни за червените: {0}", R[MaxDays].RedCount);
                Console.WriteLine("Брой дни за сините: {0}", R[MaxDays].BlueCount);
            }
        }
    }
}