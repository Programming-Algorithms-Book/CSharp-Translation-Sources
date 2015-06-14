using System;

internal class knapsack3a
{
    private const int MaxN = 30;
    private const int MaxCapacity = 1000;
    private const int TotalCapacity = 15;
    private const int N = 6;

    private static int[,] f = new int[MaxN, MaxCapacity]; /* Таблица - целева функция */
    private static readonly int[] weights = new int[] { 0, 1, 2, 3, 5, 6, 7 }; /* Тегло на предметите */
    private static readonly int[] values = new int[] { 0, 1, 10, 19, 22, 25, 30 }; /* Цена на предметите */

    private static void Calculate() /* Пресмята стойностите на целевата функция */
    {
        for (int i = 1; i <= N; i++)
        {
            for (int j = 0; j <= TotalCapacity; j++)
            {
                if (j >= weights[i] && f[i - 1, j] < f[i - 1, j - weights[i]] + values[i])
                {
                    f[i, j] = f[i - 1, j - weights[i]] + values[i];
                }
                else
                {
                    f[i, j] = f[i - 1, j];
                }
            }
        }
    }

    /* Извежда съдържанието на таблицата F[i][j] */

    private static void PrintTable()
    {
        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine();
            for (int j = 0; j <= TotalCapacity; j++)
            {
                Console.Write("{0, 4}", f[i, j]);
            }
        }
        Console.WriteLine();
    }

    private static void PrintSet()
    {
        int i = N,
            j = TotalCapacity;
        while (j != 0)
        {
            if (f[i, j] == f[i - 1, j])
            {
                i--;
            }
            else
            {
                Console.Write("{0} ", i);
                j -= weights[i];
                i--;
            }
        }

        Console.WriteLine();
    }

    private static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Максимално допустимо общо тегло: {0}\n", TotalCapacity);
        Calculate();
        Console.Write("Таблица f[i, j]: ");
        PrintTable();
        Console.WriteLine("Максимална постигната стойност: {0}", f[N, TotalCapacity]);
        Console.Write("Вземете предметите с номера: ");
        PrintSet();
    }
}