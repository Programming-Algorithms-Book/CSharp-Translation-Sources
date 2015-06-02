using System;

class knapsack2a
{
    const int NotCalculated = -1;
    const int MaxN = 30;
    const int MaxCapacity = 1000;
    const int TotalCapacity = 70; /* Обща вместимост на раницата */
    const int N = 8; /* Брой предмети */

    static bool[,] set = new bool[MaxCapacity, MaxN];
    static int[] Fn = new int[MaxCapacity];
    static readonly int[] weights = new int[] { 0, 30, 15, 50, 10, 20, 40, 5, 65 }; /* Тегла */
    static readonly int[] values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12 }; /* Стойности */

    /* Пресмята стойността на функцията за k */
    static void CalculateFunction(int k)
    {
        int i, bestI, fnBest, fnCur;
        /* Пресмятане на най-голямата стойност на F */
        for (bestI = fnBest = 0, i = 1; i <= N; i++)
        {
            if (k >= weights[i])
            {
                if (Fn[k - weights[i]] == NotCalculated)
                    CalculateFunction(k - weights[i]);
                if (!set[k - weights[i], i])
                    fnCur = values[i] + Fn[k - weights[i]];
                else
                    fnCur = 0;
                if (fnCur > fnBest)
                {
                    bestI = i;
                    fnBest = fnCur;
                }
            }
        }

        /* Регистриране на най-голямата стойност на функцията */
        Fn[k] = fnBest;
        if (bestI > 0)
        {
            for (int p = 0; p < N; p++)
            {
                set[k, p] = set[k - weights[bestI], p];
            }

            set[k, bestI] = true;
        }
    }

    static void Calculate()
    {
        int maxValue, /* Максимална постигната стойност */
            maxIndex; /* Индекс, за който е постигната */

        /* Пресмятане на стойностите на целевата функция */
        for (int i = 1; i <= TotalCapacity; i++) /* Търсим макс. стойност на Fn(i) */
        {
            maxValue = maxIndex = 0;
            for (int j = 1; j <= N; j++)
                if (weights[j] <= i && !set[i - weights[j], j])
                    if (values[j] + Fn[i - weights[j]] > maxValue)
                    {
                        maxValue = values[j] + Fn[i - weights[j]];
                        maxIndex = j;
                    }

            if (maxIndex > 0)
            {
                /* Има ли предмет с тегло по-малко от i? */
                Fn[i] = maxValue;

                /* Новото множество set[i] се получава от set[i-m[maxIndex]]
                * чрез добавяне на елемента maxIndex */
                for (int p = 0; p < N; p++)
                {
                    set[i, p] = set[i - weights[maxIndex], p];
                }

                set[i, maxIndex] = true;
            }
            if (Fn[i] < Fn[i - 1])
            {
                /* Побират се всички предмети и още */
                Fn[i] = Fn[i - 1];
                for (int p = 0; p < N; p++)
                {
                    set[i, p] = set[i - 1, p];
                }
            }
        }

        /* Извеждане на резултата */
        Console.Write("Вземете предметите с номера: ");
        for (int i = 1; i <= N; i++)
            if (set[TotalCapacity, i])
                Console.Write("{0} ", i);

        Console.WriteLine("\nМаксимална постигната стойност: {0}", Fn[TotalCapacity]);
    }

    static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Вместимост на раницата: {0}", TotalCapacity);
        Calculate();
    }
}
