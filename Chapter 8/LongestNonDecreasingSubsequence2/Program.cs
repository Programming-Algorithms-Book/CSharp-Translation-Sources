namespace LongestNonDecreasingSubsequence2
{
    using System;

    public class Program
    {
        private static readonly int[] X = { 100, 10, 15, 5, 25, 22, 12, 22 }; /* Редица */
        /* Нулевият елемент на x[] не се използва! */
        private static readonly int N = X.Length - 1; /* Брой елементи в редицата */

        private static readonly int[] Lns = new int[N + 1]; /* Дължина на максималната редица с начало x[i] */
        private static readonly int[] Next = new int[N + 1]; /* Индекс на следващ елемент */

        internal static void Main()
        {
            int start = -1;
            Console.WriteLine("Дължина на най-дългата ненамаляваща подредица: {0}", LNS_Length(ref start));
            Console.Write("Подредицата: ");
            LNS_Print(start);
        }

        /* Намира дължината на най-дългата ненамаляваща подредица */

        private static int LNS_Length(ref int start)
        {
            int len = 0; /* Максимална (за момента) дължина на ненамаляваща подредица */
            for (int i = N; i >= 1; i--)
            {
                int l = 0; /* В момента на разглеждане на xi, 
                       /* l е дължината на максималната подредица с начало xj: */
                /*        1) i < j <= n и */
                /*        2) xi <= xj         */
                for (int j = i + 1; j <= N; j++)
                {
                    if (X[j] >= X[i] && Lns[j] > l)
                    {
                        l = Lns[j];
                        Next[i] = j;
                    }
                }

                Lns[i] = l + 1;
                if (Lns[i] > len)
                {
                    len = Lns[i];
                    start = i;
                }
            }

            return len;
        }

        /* Извежда най-дългата ненамаляваща подредица */
        private static void LNS_Print(int start)
        {
            for (; Lns[start] >= 1; start = Next[start])
            {
                Console.Write(" {0}", X[start]);
            }
        }
    }
}