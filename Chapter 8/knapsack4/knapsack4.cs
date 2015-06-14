using System;

internal class knapsack4
{
    private const int MaxN = 30; /* Максимален брой предмети */
    private const int MaxCapacity = 1000; /* Максимална вместимост на раницата */
    private const int TotalCapacity = 70; /* Обща вместимост на раницата */
    private const int N = 8; /* Брой предмети */

    private static int[] f = new int[MaxCapacity]; /* Целева функция */
    private static int[] best = new int[MaxCapacity]; /* Последен добавен предмет при достигане на максимума */

    private static readonly int[] weights = new int[] { 0, 30, 15, 50, 10, 20, 40, 5, 65 }; /* Тегло на предметите */
    private static readonly int[] values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12 }; /* Стойност на предметите */

    private static void Calculate()
    {
        /* Основен цикъл */
        for (int j = 1; j <= N; j++)
        {
            for (int i = 1; i <= TotalCapacity; i++)
            {
                if (i >= weights[j])
                {
                    if (f[i] < f[i - weights[j]] + values[j])
                    {
                        f[i] = f[i - weights[j]] + values[j];
                        best[i] = j;
                    }
                }
            }
        }
    }

    /* Извежда едно възможно множество от предмети, за което */
    /* се постига максимална стойност на целевата функция */

    private static void PrintSet()
    {
        int value = TotalCapacity;
        Console.Write("Вземете следните предмети: ");
        while (value != 0)
        {
            Console.Write("{0} ", best[value]);
            value -= weights[best[value]];
        }

        Console.WriteLine();
    }

    private static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Максимална допустима обща маса: {0}", TotalCapacity);
        Calculate();
        Console.WriteLine("Максимална постигната стойност: {0}", f[TotalCapacity]);
        PrintSet();
    }
}