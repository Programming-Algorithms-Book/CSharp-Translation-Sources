using System;

class knapsack2b
{
    const int NotCalculated = -1;
    const int MaxN = 30;
    const int MaxCapacity = 1000;
    const int TotalCapacity = 70; /* Обща вместимост на раницата */
    const int N = 8; /* Брой предмети */

    static int[,] set = new int[MaxCapacity, MaxN / 8];
    static int[] fn = new int[MaxCapacity];
    static readonly int[] weights = new int[] { 0, 30, 15, 50, 10, 20, 40, 5, 65 }; /* Тегла */
    static readonly int[] values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12 }; /* Стойности */

    static void Calculate()
    {
        int maxValue, /* Максимална постигната стойност */
            maxIndex; /* Индекс, за който е постигната */

        /* Пресмятаме стойностите на целевата функция */
        for (int i = 1; i <= TotalCapacity; i++)
        { /* Търсене макс. стойност на F(i) */
            maxValue = maxIndex = 0;
            for (int j = 1; j <= N; j++)
            {
                if (weights[j] <= i && ((set[i - weights[j], j >> 3] & (1 << (j & 7))) == 0))
                    if (values[j] + fn[i - weights[j]] > maxValue)
                    {
                        maxValue = values[j] + fn[i - weights[j]];
                        maxIndex = j;
                    }
            }
            if (maxIndex > 0)
            {
                /* Има ли предмет с тегло по-малко от i? */
                fn[i] = maxValue;
                /* Новото множество set[i] се получава от set[i-m[maxIndex]]
                * чрез прибавяне на елемента maxIndex */
                int count = (N >> 3) + 1;
                for (int p = 0; p < count; p++)
                {
                    set[i, p] = set[i - weights[maxIndex], p];
                }

                set[i, maxIndex >> 3] |= 1 << (maxIndex & 7);
            }
            if (fn[i] < fn[i - 1])
            { /* Побират се всички предмети и още */
                fn[i] = fn[i - 1];
                int count = (N >> 3) + 1;
                for (int p = 0; p < count; p++)
                {
                    set[i, p] = set[i - 1, p];
                }
            }
        }

        /* Извеждане на резултата */
        Console.Write("Вземете предметите с номера: ");
        for (int i = 1; i <= N; i++)
            if ((set[TotalCapacity, i >> 3] & (1 << (i & 7))) != 0)
                Console.Write("{0} ", i);

        Console.WriteLine("\nМаксимална постигната стойност: {0}", fn[TotalCapacity]);
    }

    static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Вместимост на раницата: {0}", TotalCapacity);
        Calculate();
    }
}
