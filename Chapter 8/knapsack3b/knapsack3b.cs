namespace Knapsack3b
{
    using System;

    public class Knapsack3B
    {
        private const int MaxN = 30;
        private const int MaxM = 1000;
        private const int M = 14;
        private const int N = 9;

        private static readonly int[,] F = new int[MaxN, MaxM];
        private static readonly int[] Set = new int[MaxN];
        private static readonly int[] Weights = new int[] { 0, 6, 3, 10, 2, 4, 8, 1, 13, 3 }; /* Тегло на предметите */
        private static readonly int[] Values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12, 3 }; /* Цена на предметите */

        internal static void Main()
        {
            Console.WriteLine("Брой предмети: {0}", N);
            Console.WriteLine("Максимално допустимо обща маса: {0}\n", M);
            Calculate();
            Console.Write("Таблица F[i, j]: ");
            PrintTable();
            Console.WriteLine("Максимална постигната стойност: {0}", F[N, M]);
            Console.WriteLine("Следват всевъзможните множества от решения:");
            PrintAllSolutions(N, M, 0);
        }

        private static void Calculate()
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    if (j >= Weights[i] && F[i - 1, j] < F[i - 1, j - Weights[i]] + Values[i])
                    {
                        F[i, j] = F[i - 1, j - Weights[i]] + Values[i];
                    }
                    else
                    {
                        F[i, j] = F[i - 1, j];
                    }
                }
            }
        }

        /* Извежда съдържанието на таблицата F[i, j] */

        private static void PrintTable()
        {
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine();
                for (int j = 0; j <= M; j++)
                {
                    Console.Write("{0, 4}", F[i, j]);
                }
            }

            Console.WriteLine();
        }

        private static void PrintAllSolutions(int i, int j, int k)
        {
            /* Извежда ВСИЧКИ възможни множества от предмети, за които */
            /* се постига максимална стойност на целевата функция */
            if (0 == j)
            {
                Console.Write("Вземете следните предмети: ");
                for (i = 0; i < k; i++)
                {
                    Console.Write("{0} ", Set[i]);
                }

                Console.WriteLine();
            }
            else
            {
                if (F[i, j] == F[i - 1, j])
                {
                    PrintAllSolutions(i - 1, j, k);
                }

                if (j >= Weights[i] && F[i, j] == F[i - 1, j - Weights[i]] + Values[i])
                {
                    Set[k] = i;
                    PrintAllSolutions(i - 1, j - Weights[i], k + 1);
                }
            }
        }
    }
}