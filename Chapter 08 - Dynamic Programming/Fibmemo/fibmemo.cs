namespace Fibmemo
{
    using System;

    public class Fibmemo
    {
        private const int Max = 256;
        private const int N = 10;

        private static readonly int[] Memo = new int[Max + 1];

        internal static void Main()
        {
            Console.WriteLine("{0}-тото число на Фибоначи е: {1}", N, FibMemo(N));
        }

        private static int FibMemo(int n)
        {
            if (n < 2)
            {
                Memo[n] = n;
            }
            else if (0 == Memo[n])
            {
                Memo[n] = FibMemo(n - 1) + FibMemo(n - 2);
            }

            return Memo[n];
        }
    }
}