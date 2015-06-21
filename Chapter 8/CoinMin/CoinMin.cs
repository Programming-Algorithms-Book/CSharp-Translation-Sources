namespace CoinMin
{
    using System;

    public class CoinMin
    {
        private const int MaxCoins = 100;
        private const int MaxSum = 100;
        private const int Sum = 6; /* Сума, която искаме да получим */
        private const int N = 5; /* Общ брой налични монети */

        private static readonly int[,] Values = new int[MaxSum, MaxSum]; /* Целева функция */
        private static readonly bool[] Exist = new bool[MaxSum]; /* Съществува ли монета с такава стойност */
        private static readonly int[] Coins = new int[] { 1, 2, 3, 4, 6 }; /* Налични типове монети */

        internal static void Main()
        {
            Init();
            Console.WriteLine(
                              "Броят на представянията на {0} с наличните монети е {1}",
                              Sum,
                              Count(Sum, Sum));
        }

        /* Инициализираща функция */
        private static void Init()
        {
            /* Друго представяне на стойностите на монетите за по-бърз достъп */
            for (int i = 0; i < N; i++)
            {
                Exist[Coins[i]] = true;
            }
        }

        /* Намира броя на представянията на sum */
        private static int Count(int sum, int max)
        {
            if (sum <= 0)
            {
                return 0;
            }

            if (Values[sum, max] > 0)
            {
                return Values[sum, max];
            }
            else
            {
                if (sum < max)
                {
                    max = sum;
                }

                /* Съществува монета с такава стойност */
                if (sum == max && Exist[sum])
                {
                    Values[sum, max] = 1;
                }

                /* Пресмятаме всички */
                for (int i = max; i > 0; i--)
                {
                    if (Exist[i])
                    {
                        Values[sum, max] += Count(sum - i, i);
                    }
                }
            }

            return Values[sum, max];
        }
    }
}