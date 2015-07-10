namespace LongestNonDecreasingSubsequence1
{
    using System;

    public class Program
    {
        private static readonly int[] X = { 100, 10, 15, 5, 25, 22, 12, 22 }; /* Редица */
        /* Нулевият елемент на x[] не се използва! */
        private static readonly int N = X.Length - 1; /* Брой елементи в редицата */
        private static readonly int[,] Lns = new int[N + 1, N + 1]; /* Целева функция */

        internal static void Main()
        {
            int length = LnsLength();
            Console.Write("Дължина на най-дългата ненамаляваща подредица: {0}", length);
            Console.WriteLine();
            Console.Write("Подредицата (обърната): ");
            LnsPrint(length);
            Console.WriteLine();
            Console.Write("Подредицата: ");
            LnsPrint2(N, length);
        }

        /* Намира дължината на най-дългата ненамаляваща подредица */
        private static int LnsLength()
        {
            /* Начална инициализация */
            for (int i = 0; i <= N; i++)
            {
                Lns[i, 0] = -1;
                for (int j = 1; j <= N; j++)
                {
                    Lns[i, j] = int.MaxValue;
                }
            }

            /* Основен цикъл */
            int r = 1;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (Lns[i - 1, j - 1] <= X[i] &&
                        X[i] <= Lns[i - 1, j] &&
                        Lns[i - 1, j - 1] <= Lns[i - 1, j])
                    {
                        Lns[i, j] = X[i];
                        if (r < j)
                        {
                            r = j;
                        }
                    }
                    else
                    {
                        Lns[i, j] = Lns[i - 1, j];
                    }
                }
            }

            return r;
        }

        /* Извежда най-дългата ненамаляваща подредица (в обратен ред) */
        private static void LnsPrint(int j)
        {
            int i = N;
            do
            {
                if (Lns[i, j] == Lns[i - 1, j])
                {
                    i--;
                }
                else
                {
                    Console.Write("{0} ", X[i]);
                    j--;
                }
            }
            while (i > 0);
        }

        /* Извежда най-дългата ненамаляваща подредица */
        private static void LnsPrint2(int i, int j)
        {
            if (i == 0)
            {
                return;
            }

            if (Lns[i, j] == Lns[i - 1, j])
            {
                LnsPrint2(i - 1, j);
            }
            else
            {
                LnsPrint2(i, j - 1);
                Console.Write("{0} ", X[i]);
            }
        }
    }
}