namespace ConferenceRoom
{
    using System;

    internal class Program
    {
        private const int Maxn = 5000; /* Максимален брой заявки */
        private const int Maxd = 365; /* Максимален брой дни */

        private static readonly BlueRed[] B = new BlueRed[Maxd + 1];
        private static readonly BlueRed[] R = new BlueRed[Maxd + 1];

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

        private static readonly int N = BlueOrders.Length; /* Брой сини заявки */
        private static readonly int M = RedOrders.Length; /* Брой червени заявки */

        private static void Main()
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
            B[0].CntBlue = B[0].CntRed = R[0].CntBlue = R[0].CntRed = 0;
            blueIndex = redIndex = 1;
            /* Пресмятане на B[1..MAXD], R[1..MAXD] */
            for (d = 1; d <= Maxd; d++)
            {
                /* Пресмятане на B[d] */
                B[d] = B[d - 1];
                for (blueIndex = 0; blueIndex < N; blueIndex++)
                {
                    if (BlueOrders[blueIndex].End > d)
                    {
                        break;
                    }
                    else
                    {
                        bb = BlueOrders[blueIndex].Begin;
                        be = BlueOrders[blueIndex].End;
                        if (R[bb - 1].CntBlue + R[bb - 1].CntRed + (be - bb + 1) > B[d].CntBlue + B[d].CntRed)
                        {
                            B[d].CntBlue = R[bb - 1].CntBlue + (be - bb + 1);
                            B[d].CntRed = R[bb - 1].CntRed + 0;
                        }
                    }
                }

                /* Пресмятане на R[d]: аналогично на B[d] */
                R[d] = R[d - 1];
                for (redIndex = 0; redIndex < M; redIndex++)
                {
                    if (RedOrders[redIndex].End > d)
                    {
                        break;
                    }
                    else
                    {
                        bb = RedOrders[redIndex].Begin;
                        be = RedOrders[redIndex].End;
                        if (B[bb - 1].CntBlue + B[bb - 1].CntRed + (be - bb + 1) > R[d].CntBlue + R[d].CntRed)
                        {
                            R[d].CntBlue = B[bb - 1].CntBlue;
                            R[d].CntRed = B[bb - 1].CntRed + (be - bb + 1);
                        }
                    }
                }
            }
        }

        /* Извежда резултата на екрана */

        private static void PrintResult()
        {
            if (B[Maxd].CntBlue + B[Maxd].CntRed > R[Maxd].CntBlue + R[Maxd].CntRed)
            {
                Console.WriteLine("Заетост на залата (дни): {0}", B[Maxd].CntBlue + B[Maxd].CntRed);
                Console.WriteLine("Брой дни за червените: {0}", B[Maxd].CntRed);
                Console.WriteLine("Брой дни за сините: {0}", B[Maxd].CntBlue);
            }
            else
            {
                Console.WriteLine("Заетост на залата (дни): {0}", R[Maxd].CntBlue + R[Maxd].CntRed);
                Console.WriteLine("Брой дни за червените: {0}", R[Maxd].CntRed);
                Console.WriteLine("Брой дни за сините: {0}", R[Maxd].CntBlue);
            }
        }
    }
}