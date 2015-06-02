using System;

class knapsack3b
{
    const int MaxN = 30;
    const int MaxM = 1000;
    const int M = 14;
    const int N = 9;

    static int[,] f = new int[MaxN, MaxM];
    static int[] set = new int[MaxN];
    static readonly int[] weights = new int[] { 0, 6, 3, 10, 2, 4, 8, 1, 13, 3 };  /* Тегло на предметите */
    static readonly int[] values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12, 3 };   /* Цена на предметите */

    static void Calculate()
    {
        for (int i = 1; i <= N; i++)
            for (int j = 0; j <= M; j++)
                if (j >= weights[i] && f[i - 1, j] < f[i - 1, j - weights[i]] + values[i])
                    f[i, j] = f[i - 1, j - weights[i]] + values[i];
                else
                    f[i, j] = f[i - 1, j];
    }

    /* Извежда съдържанието на таблицата F[i, j] */
    static void PrintTable()
    {
        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine();
            for (int j = 0; j <= M; j++)
                Console.Write("{0, 4}", f[i, j]);
        }
        Console.WriteLine();
    }

    static void PrintAllSolutions(int i, int j, int k)
    {
        /* Извежда ВСИЧКИ възможни множества от предмети, за които */
        /* се постига максимална стойност на целевата функция */
        if (0 == j)
        {
            Console.Write("Вземете следните предмети: ");
            for (i = 0; i < k; i++)
                Console.Write("{0} ", set[i]);
            Console.WriteLine();
        }
        else
        {
            if (f[i, j] == f[i - 1, j])
                PrintAllSolutions(i - 1, j, k);
            if (j >= weights[i] && f[i, j] == f[i - 1, j - weights[i]] + values[i])
            {
                set[k] = i;
                PrintAllSolutions(i - 1, j - weights[i], k + 1);
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Максимално допустимо обща маса: {0}\n", M);
        Calculate();
        Console.Write("Таблица F[i, j]: ");
        PrintTable();
        Console.WriteLine("Максимална постигната стойност: {0}", f[N, M]);
        Console.WriteLine("Следват всевъзможните множества от решения:");
        PrintAllSolutions(N, M, 0);
    }
}
