namespace NoTwoZeroes
{
    using System;

    public class Program
    {
        private const long NotSolved = -1;
        private const int N = 10;
        private const int K = 7;

        private static readonly long[] F = new long[N + 1]; /* Целева функция */
        private static readonly long[] Pow = new long[N + 1]; /* Степените на k */

        internal static void Main()
        {
            Init();
            F[0] = 1;
            F[1] = K;
            F[2] = (K * K) - 1;
            Console.WriteLine((K - 1) * Solve(N - 1));
        }

        private static void Init()
        {
            Pow[0] = 1;
            for (int i = 1; i <= N; i++)
            {
                Pow[i] = K * Pow[i - 1];
                F[i] = NotSolved;
            }
        }

        private static long Solve(int s)
        {
            if (F[s] == NotSolved)
            {
                F[s] = Pow[s - 2];
                for (int i = 1; i < s - 1; i++)
                {
                    F[s] += Solve(i - 1) * (K - 1) * Pow[s - i - 2];
                }

                F[s] = Pow[s] - F[s];
            }

            return F[s];
        }
    }
}