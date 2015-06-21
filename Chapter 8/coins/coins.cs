namespace Coins
{
    using System;

    public class CoinsProblem
    {
        private const int MaxCoins = 100;
        private const int MaxSum = 1000;
        private const int Sum = 31; /* Сума, чието представяне минимизираме */
        private const int N = 14; /* Общ брой налични монети */

        private static readonly Element[] Sums = new Element[MaxSum];

        private static readonly int[] Coins = new int[] /* Стойности на монетите */
        {
            0, 5, 2, 2, 3, 2, 2, 2, 4, 3, 5, 8, 6, 7, 9
        };

        internal static void Main()
        {
            Console.WriteLine("Как да получим сума от {0} лева с минимален брой монети?", Sum);
            FindMinSolution(Sum);
            PrintSolution(Sum);
        }

        /* Дали можем да използваме j-тата монета в i-тата сума? */
        private static bool CanJ(int i, int j)
        {
            int k = i - Coins[j];
            if (k > 0 && Sums[k].Num < MaxCoins)
            {
                while (k > 0)
                {
                    if (Sums[k].Last == j)
                    {
                        break; /* монета j участва в сумата */
                    }

                    k -= Coins[Sums[k].Last];
                }
            }

            return k == 0;
        }

        /* Намира представяне на сумата Sum с минимален брой монети */
        private static void FindMinSolution(int sum)
        {
            Sums[0].Num = 0;
            for (int i = 1; i <= sum; i++)
            {
                Sums[i].Num = MaxCoins;
                for (int j = 1; j <= N; j++)
                {
                    if (CanJ(i, j))
                    {
                        if ((Sums[i - Coins[j]].Num + 1) < Sums[i].Num)
                        {
                            Sums[i].Num = 1 + Sums[i - Coins[j]].Num;
                            Sums[i].Last = j;
                        }
                    }
                }
            }
        }

        /* Извежда намереното представяне */
        private static void PrintSolution(int sum)
        {
            if (Sums[sum].Num == MaxCoins)
            {
                Console.WriteLine("Сумата не може да се получи с наличните монети.");
            }
            else
            {
                Console.WriteLine("Минимален брой необходими монети: {0}", Sums[sum].Num);
                Console.WriteLine("Ето и стойностите на самите монети: ");
                while (sum > 0)
                {
                    Console.Write("{0} ", Coins[Sums[sum].Last]);
                    sum -= Coins[Sums[sum].Last];
                }

                Console.WriteLine();
            }
        }
    }
}