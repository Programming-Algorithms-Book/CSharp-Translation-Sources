namespace LongestNonDecreasingSubsequence3
{
    using System;

    public class Program
    {
        private static readonly int[] X = { 100, 10, 15, 5, 25, 22, 12, 22 }; /* Редица */
        /* Нулевият елемент на x[] не се използва! */
        private static readonly int N = X.Length - 1; /* Брой елементи в редицата */
        private static readonly int[] Lns = new int[N + 1]; /* LNS[i] - минимален елемент, който може да стои на позиция i */

        internal static void Main()
        {
            Console.WriteLine("Дължина на най-дългата ненамаляваща подредица: {0}", LnsLength());
        }

        /* Намира дължината на най-дългата ненамаляваща подредица */
        private static int LnsLength()
        {
            int k = 1;
            Lns[1] = X[1];
            for (int i = 2; i <= N; i++)
            {
                /* случай 1 */
                if (X[i] < Lns[1])
                {
                    Lns[1] = X[i];
                }
                else if (X[i] >= Lns[k])
                {
                    /* случай 2 */
                    Lns[++k] = X[i];
                }
                else
                {
                    /* случай 3 */
                    int l = 1;
                    int r = k; /* двоично търсене */
                    while (l < r - 1)
                    {
                        int med = (l + r) / 2;
                        if (Lns[med] <= X[i])
                        {
                            l = med;
                        }
                        else
                        {
                            r = med;
                        }
                    }

                    Lns[r] = X[i];
                }
            }

            return k;
        }
    }
}