using System;

class knapsack3c
{
    const int MaxN = 30;
    const int MaxCapacity = 1000;
    const int TotalCapacity = 15; /* Обща вместимост на раницата */
    const int N = 6; /* Брой предмети */

    static readonly int[] weights = new int[] { 0, 1, 2, 3, 5, 6, 7 }; /* Тегло на предметите */
    static readonly int[] values = new int[] { 0, 1, 10, 19, 22, 25, 30 }; /* Стойност на предметите */

    /* Пресмята стойностите на целевата функция */
    static int Calculate()
    {
        int[] f = new int[MaxCapacity]; /* Целева функция */
        int[] oldF = new int[MaxCapacity];

        for (int i = 1; i <= N; i++)
        {
            for (int j = 0; j <= TotalCapacity; j++)
                if (j >= weights[i] && oldF[j] < oldF[j - weights[i]] + values[i])
                    f[j] = oldF[j - weights[i]] + values[i];
                else 
                    f[j] = oldF[j];

            for (int k = 0; k < TotalCapacity; k++)
                oldF[k] = f[k];
        }

        return f[TotalCapacity];
    }

    static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Максимална допустима обща маса: {0}", TotalCapacity);
        Console.WriteLine("Максимална постигната ценност: {0}", Calculate());
    }
}