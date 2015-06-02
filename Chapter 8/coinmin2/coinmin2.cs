using System;

class coinmin2
{
    const int MaxCoins = 100;
    const int MaxSum = 100;
    const int N = 7;    /* Общ брой налични монети */
    const int Sum = 6;  /* Сума, която искаме да получим */


    static int[,] values = new int[MaxSum, MaxSum];  /* Целева функция */
    static int[] coins = new int[] { 1, 2, 2, 3, 3, 4, 6 }; /* Налични типове монети */

    static void Sort()
    {
        for (int i = 0; i < N - 1; i++)
            for (int j = i + 1; j < N; j++)
                if (coins[i] > coins[j])
                    SwapValues(ref coins[i], ref coins[j]);
    }

    /* Намира броя на представянията на sum при използване на първите k монети */
    static int Count(int sum, int k)
    {
        int j;
        if (sum <= 0 || k < 0)
            return 0;
        if (values[sum, k] > 0)
            return values[sum, k];
        else
        {
            if (coins[k] == sum)
                values[sum, k] = 1;
            values[sum, k] += Count(sum - coins[k], k - 1);
            j = k;
            while (j >= 0 && coins[j] == coins[k])
                j--;
            values[sum, k] += Count(sum, j);
        }

        return values[sum, k];
    }

    static void SwapValues(ref int a, ref int b)
    {
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;
    }

    static void Main()
    {
        Sort();
        Console.WriteLine("Броят на представянията на {0} с наличните монети е {1}.",
                                                    Sum, Count(Sum, N - 1));
    }
}
