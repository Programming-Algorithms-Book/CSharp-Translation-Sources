namespace OptimalBitonicSequence
{
    using System;

    public class Program
    {
        private static readonly int[] X = { 0, 10, 20, 15, 40, 5, 4, 300, 2, 1 }; /* Височини на дърветата */
        private static readonly int N = X.Length - 1; /* Брой крайпътни дървета */
        private static readonly St[] Max1 = new St[N + 1];
        private static readonly St[] Max2 = new St[N + 1];

        private static readonly int[] X2 = new int[N + 1];
        private static readonly int[] Rez = new int[N];
        private static int top;
        private static long bestLen, bestSum;

        internal static void Main()
        {
            Solve();
            BuildSequence();
            Print();
        }

        /* Търси нарастваща редица */

        private static void FindIncSequence(St[] max, int[] x)
        {
            /* Основен цикъл */
            for (int i = 1; i <= N; i++)
            {
                max[i].Len = 0;
                max[i].Sum = 0;
                for (int j = 0; j < i; j++)
                {
                    if (x[j] <= x[i])
                    {
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
            }
        }

        /* Построява обърнато копие на редицата */

        private static void Reverse(int[] x2, int[] x)
        {
            for (int i = 1; i <= N; i++)
            {
                x2[i] = x[N - i + 1];
            }
        }

        /* Намира търсената редица */

        private static void Solve()
        {
            /* стъпка (1) */
            FindIncSequence(Max1, X);
            /* стъпка (2) */
            Reverse(X2, X);
            FindIncSequence(Max2, X2);
            /* стъпка (3) */
            bestLen = 0;
            bestSum = 0;
            for (int i = 1; i <= N; i++)
            {
                if ((Max1[i].Len + Max2[N - i + 1].Len > bestLen) ||
                    ((Max1[i].Len + Max2[N - i + 1].Len == bestLen) &&
                     (Max1[i].Sum + Max2[N - i + 1].Sum > bestSum)))
                {
                    bestLen = Max1[i].Len + Max2[N - i + 1].Len;
                    bestSum = Max1[i].Sum + Max2[N - i + 1].Sum; /* Трябва да се намали с 1 */
                    top = i;
                }
            }
        }

        /* Построява търсената редица */

        private static void BuildSequence()
        {
            int t = top;
            int len = 0;
            /* Построяване на нарастващата част на редицата */
            for (int l = Max1[t].Len; t != 0; t = Max1[t].Back)
            {
                Rez[l - len++] = X[t];
            }

            /* Построяване на намаляващата част на редицата */
            for (t = Max2[N - top + 1].Back; t != 0; t = Max2[t].Back)
            {
                Rez[++len] = X2[t];
            }
        }

        /* Извежда резултата на екрана */

        private static void Print()
        {
            Console.WriteLine("Максимален брой дървета, които могат да се запазят: {0}", bestLen - 1);
            for (int i = 1; i < bestLen; i++)
            {
                Console.Write("{0} ", Rez[i]);
            }

            Console.WriteLine();
        }
    }
}