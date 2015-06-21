namespace Knapsack2a
{
    using System;

    internal class Knapsack2A
    {
        private const int NotCalculated = -1;
        private const int MaxN = 30;
        private const int MaxCapacity = 1000;
        private const int TotalCapacity = 70; /* Обща вместимост на раницата */
        private const int N = 8; /* Брой предмети */

        private static readonly bool[,] Set = new bool[MaxCapacity, MaxN];
        private static readonly int[] Fn = new int[MaxCapacity];
        private static readonly int[] Weights = new int[] { 0, 30, 15, 50, 10, 20, 40, 5, 65 }; /* Тегла */
        private static readonly int[] Values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12 }; /* Стойности */

        internal static void Main()
        {
            Console.WriteLine("Брой предмети: {0}", N);
            Console.WriteLine("Вместимост на раницата: {0}", TotalCapacity);
            Calculate();
        }

        /* Пресмята стойността на функцията за k */
        private static void CalculateFunction(int k)
        {
            int i;
            int bestI;
            int functionBest;

            /* Пресмятане на най-голямата стойност на F */
            for (bestI = functionBest = 0, i = 1; i <= N; i++)
            {
                if (k >= Weights[i])
                {
                    if (Fn[k - Weights[i]] == NotCalculated)
                    {
                        CalculateFunction(k - Weights[i]);
                    }

                    int functionCur;
                    if (!Set[k - Weights[i], i])
                    {
                        functionCur = Values[i] + Fn[k - Weights[i]];
                    }
                    else
                    {
                        functionCur = 0;
                    }

                    if (functionCur > functionBest)
                    {
                        bestI = i;
                        functionBest = functionCur;
                    }
                }
            }

            /* Регистриране на най-голямата стойност на функцията */
            Fn[k] = functionBest;
            if (bestI > 0)
            {
                for (int p = 0; p < N; p++)
                {
                    Set[k, p] = Set[k - Weights[bestI], p];
                }

                Set[k, bestI] = true;
            }
        }

        private static void Calculate()
        {
            int maxValue,
                /* Максимална постигната стойност */
                maxIndex; /* Индекс, за който е постигната */

            /* Пресмятане на стойностите на целевата функция */
            /* Търсим макс. стойност на Fn(i) */
            for (int i = 1; i <= TotalCapacity; i++)
            {
                maxValue = maxIndex = 0;
                for (int j = 1; j <= N; j++)
                {
                    if (Weights[j] <= i && !Set[i - Weights[j], j])
                    {
                        if (Values[j] + Fn[i - Weights[j]] > maxValue)
                        {
                            maxValue = Values[j] + Fn[i - Weights[j]];
                            maxIndex = j;
                        }
                    }
                }

                if (maxIndex > 0)
                {
                    /* Има ли предмет с тегло по-малко от i? */
                    Fn[i] = maxValue;

                    /* Новото множество set[i] се получава от set[i-m[maxIndex]]
                * чрез добавяне на елемента maxIndex */
                    for (int p = 0; p < N; p++)
                    {
                        Set[i, p] = Set[i - Weights[maxIndex], p];
                    }

                    Set[i, maxIndex] = true;
                }

                if (Fn[i] < Fn[i - 1])
                {
                    /* Побират се всички предмети и още */
                    Fn[i] = Fn[i - 1];
                    for (int p = 0; p < N; p++)
                    {
                        Set[i, p] = Set[i - 1, p];
                    }
                }
            }

            /* Извеждане на резултата */
            Console.Write("Вземете предметите с номера: ");
            for (int i = 1; i <= N; i++)
            {
                if (Set[TotalCapacity, i])
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine("\nМаксимална постигната стойност: {0}", Fn[TotalCapacity]);
        }
    }
}