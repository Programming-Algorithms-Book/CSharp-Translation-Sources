namespace Fibmemo2
{
    using System;

    public class Fibmemo2
    {
        private const int Max = 250;
        private const int N = 10;

        private static readonly int[] Memo = new int[Max + 1];

        internal static void Main()
        {
            Console.WriteLine("{0}-тото число на Фибоначи е: {1}", N, FibMemo(N - 1));
        }

        /* Бърз рекурсивен логаритмичен вариант, запаметяващ вече изчисленото */
        private static int FibMemo(int n)
        {
            if (n < 2)
            {
                Memo[n] = 1;
            }
            else if (Memo[n] == 0)
            {
                if (n % 2 == 1)
                {
                    Memo[n] = FibMemo(n - 1) + FibMemo(n - 2);
                }
                else
                {
                    Memo[n] = GetSquare(FibMemo(n / 2)) + GetSquare(FibMemo((n / 2) - 1));
                }
            }

            return Memo[n];
        }

        private static int GetSquare(int num)
        {
            int square = (int)Math.Pow(num, 2);
            return square;
        }
    }
}