using System;

class knapsack1
{
    const int NotCalculated = -1;
    const int MaxN = 30;
    const int MaxCapacity = 1000;
    const int TotalCapacity = 70; /* Обща вместимост на раницата */
    const int N = 8; /* Брой предмети */

    static bool[,] set = new bool[MaxCapacity, MaxN];
    static int[] fn = new int[MaxCapacity]; /* Целева функция */
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
                if (fn[k - weights[i]] == NotCalculated)
                    CalculateFunction(k - weights[i]);
                if (!set[k - weights[i], i])
                    fnCur = values[i] + fn[k - weights[i]];
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
        fn[k] = fnBest;
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
        int i, sumM;

        /* Инициализиране */
        for (i = 0; i <= TotalCapacity; i++) /* Иниц. на целевата функция */
            fn[i] = NotCalculated;

        /* Дали не можем да вземем всички предмети? */
        for (sumM = weights[1], i = 2; i <= N; i++)
            sumM += weights[i];

        if (sumM <= TotalCapacity)
        {
            Console.WriteLine("Можете да вземете всички предмети!");
            return;
        }
        else
        {
            CalculateFunction(TotalCapacity); /* Пресмятане на стойността */

            /* Отпечатване на резултата */
            Console.Write("Вземете предметите с номера: ");
            for (i = 1; i <= N; i++)
                if (set[TotalCapacity, i])
                    Console.Write("{0} ", i);

            Console.WriteLine("\nМаксимална постигната стойност: {0}", fn[TotalCapacity]);
        }
    }

    static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Вместимост на раницата: {0}", TotalCapacity);
        Calculate();
    }

}
