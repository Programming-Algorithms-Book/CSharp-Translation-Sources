namespace CoinMin2
{
    using System;

    public class CoinMin2
    {
        private const int MaxCoins = 100;
        private const int MaxSum = 100;
        private const int N = 7; /* Общ брой налични монети */
        private const int Sum = 6; /* Сума, която искаме да получим */

        private static readonly int[,] Values = new int[MaxSum, MaxSum]; /* Целева функция */
        private static readonly int[] Coins = new int[] { 1, 2, 2, 3, 3, 4, 6 }; /* Налични типове монети */

        internal static void Main()
        {
            Sort();
            Console.WriteLine(
                              "Броят на представянията на {0} с наличните монети е {1}.",
                              Sum,
                              Count(Sum, N - 1));
        }

        private static void Sort()
        {
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (Coins[i] > Coins[j])
                    {
                        SwapValues(ref Coins[i], ref Coins[j]);
                    }
                }
            }
        }

        /* Намира броя на представянията на sum при използване на първите k монети */
        private static int Count(int sum, int k)
        {
            int j;
            if (sum <= 0 || k < 0)
            {
                return 0;
            }

            if (Values[sum, k] > 0)
            {
                return Values[sum, k];
            }
            else
            {
                if (Coins[k] == sum)
                {
                    Values[sum, k] = 1;
                }

                Values[sum, k] += Count(sum - Coins[k], k - 1);
                j = k;
                while (j >= 0 && Coins[j] == Coins[k])
                {
                    j--;
                }

                Values[sum, k] += Count(sum, j);
            }

            return Values[sum, k];
        }

        private static void SwapValues(ref int a, ref int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }
    }
}