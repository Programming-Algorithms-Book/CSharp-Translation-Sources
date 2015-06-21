namespace Knapsack5
{
    using System;

    public class Knapsack5
    {
        private const int MaxN = 30; /* Максимален брой предмети */
        private const int MaxCapacity = 1000; /* Максимална вместимост на раницата */
        private const int TotalCapacity = 70; /* Обща вместимост на раницата */
        private const int N = 8; /* Брой предмети */

        private static readonly int[] F = new int[MaxCapacity]; /* Целева функция */
        private static readonly int[] Best = new int[MaxCapacity]; /* Последен добавен предмет при достигане на максимума */

        private static readonly int[] Weights = new int[] { 0, 30, 15, 50, 10, 20, 40, 5, 65 }; /* Тегло на предметите */
        private static readonly int[] Values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12 }; /* Стойност на предметите */

        internal static void Main()
        {
            Console.WriteLine("Брой предмети: {0}", N);
            Console.WriteLine("Максимална допустима обща маса: {0}", TotalCapacity);
            Calculate();
            Console.WriteLine("Максимална постигната ценност: {0}", F[TotalCapacity]);
            Console.Write("Вземете следните предмети: ");
            PrintSet();
        }

        private static bool IsUsed(int i, int j)
        {
            /* Проверява дали j участва в оптималното множество, определено от f[i] */
            while (i != 0 && Best[i] != 0)
            {
                if (Best[i] == j)
                {
                    return true;
                }
                else
                {
                    i -= Weights[Best[i]];
                }
            }

            return false;
        }

        private static void Calculate()
        {
            for (int i = 1; i <= TotalCapacity; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (i >= Weights[j])
                    {
                        if (F[i] < F[i - Weights[j]] + Values[j])
                        {
                            if (!IsUsed(i - Weights[j], j))
                            {
                                F[i] = F[i - Weights[j]] + Values[j];
                                Best[i] = j;
                            }
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
            while (value != 0)
            {
                Console.Write("{0} ", Best[value]);
                value -= Weights[Best[value]];
            }

            Console.WriteLine();
        }
    }
}