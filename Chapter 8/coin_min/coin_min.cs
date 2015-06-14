using System;

internal class coin_min
{
    private const int MaxCoins = 100;
    private const int MaxSum = 100;
    private const int Sum = 6; /* Сума, която искаме да получим */
    private const int N = 5; /* Общ брой налични монети */

    private static int[,] values = new int[MaxSum, MaxSum]; /* Целева функция */
    private static bool[] exist = new bool[MaxSum]; /* Съществува ли монета с такава стойност */
    private static readonly int[] coins = new int[] { 1, 2, 3, 4, 6 }; /* Налични типове монети */

    /* Инициализираща функция */

    private static void Init()
    {
        /* Друго представяне на стойностите на монетите за по-бърз достъп */
        for (int i = 0; i < N; i++)
        {
            exist[coins[i]] = true;
        }
    }

    /* Намира броя на представянията на sum */

    private static int Count(int sum, int max)
    {
        if (sum <= 0)
        {
            return 0;
        }
        if (values[sum, max] > 0)
        {
            return values[sum, max];
        }
        else
        {
            if (sum < max)
            {
                max = sum;
            }
            if (sum == max && exist[sum]) /* Съществува монета с такава стойност */
            {
                values[sum, max] = 1;
            }
            for (int i = max; i > 0; i--) /* Пресмятаме всички */
            {
                if (exist[i])
                {
                    values[sum, max] += Count(sum - i, i);
                }
            }
        }

        return values[sum, max];
    }

    private static void Main()
    {
        Init();
        Console.WriteLine("Броят на представянията на {0} с наличните монети е {1}",
                          Sum, Count(Sum, Sum));
    }
}