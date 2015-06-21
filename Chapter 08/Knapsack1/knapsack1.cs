namespace Knapsack1
{
    using System;

    public class Knapsack1
    {
        private const int NotCalculated = -1;
        private const int MaxN = 30;
        private const int MaxCapacity = 1000;
        private const int TotalCapacity = 70; /* Обща вместимост на раницата */
        private const int N = 8; /* Брой предмети */

        private static readonly bool[,] Set = new bool[MaxCapacity, MaxN];
        private static readonly int[] Fn = new int[MaxCapacity]; /* Целева функция */
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
            int functionCur;
            /* Пресмятане на най-голямата стойност на F */
            for (bestI = functionBest = 0, i = 1; i <= N; i++)
            {
                if (k >= Weights[i])
                {
                    if (Fn[k - Weights[i]] == NotCalculated)
                    {
                        CalculateFunction(k - Weights[i]);
                    }

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
            int i, sumM;

            /* Инициализиране */
            /* Иниц. на целевата функция */
            for (i = 0; i <= TotalCapacity; i++)
            {
                Fn[i] = NotCalculated;
            }

            /* Дали не можем да вземем всички предмети? */
            for (sumM = Weights[1], i = 2; i <= N; i++)
            {
                sumM += Weights[i];
            }

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
}