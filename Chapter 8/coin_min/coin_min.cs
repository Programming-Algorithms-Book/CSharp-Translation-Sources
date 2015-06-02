using System;

class coin_min
{
    const int MaxCoins = 100;
    const int MaxSum = 100;
    const int Sum = 6;      /* Сума, която искаме да получим */
    const int N = 5;        /* Общ брой налични монети */

    static int[,] values = new int[MaxSum, MaxSum];  /* Целева функция */
    static bool[] exist = new bool[MaxSum];     /* Съществува ли монета с такава стойност */
    static readonly int[] coins = new int[] { 1, 2, 3, 4, 6 };   /* Налични типове монети */

    /* Инициализираща функция */
    static void Init()
    {
        /* Друго представяне на стойностите на монетите за по-бърз достъп */
        for (int i = 0; i < N; i++)
            exist[coins[i]] = true;
    }

    /* Намира броя на представянията на sum */
    static int Count(int sum, int max)
    {
        if (sum <= 0)
            return 0;
        if (values[sum, max] > 0)
            return values[sum, max];
        else
        {
            if (sum < max)
                max = sum;
            if (sum == max && exist[sum])   /* Съществува монета с такава стойност */
                values[sum, max] = 1;
            for (int i = max; i > 0; i--)  /* Пресмятаме всички */
                if (exist[i])
                    values[sum, max] += Count(sum - i, i);
        }

        return values[sum, max];
    }

    static void Main()
    {
        Init();
        Console.WriteLine("Броят на представянията на {0} с наличните монети е {1}",
               Sum, Count(Sum, Sum));
    }
}
