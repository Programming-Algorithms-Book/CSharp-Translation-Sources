namespace StringTransform
{
    using System;

    public class Program
    {
        private const int CostDelete = 1;
        private const int CostInsert = 2;

        private static readonly string S1 = "_abracadabra"; /* Изходен низ (първият символ няма значение) */
        private static readonly string S2 = "_mabragabra"; /* Низ-цел (първият символ няма значение) */
        private static readonly int N1 = S1.Length - 1; /* Дължина на първия низ */
        private static readonly int N2 = S2.Length - 1; /* Дължина на втория низ */

        private static readonly int[,] F = new int[N1 + 1, N2 + 1]; /* Целева функция */

        internal static void Main()
        {
            Console.WriteLine("Минимално разстояние между двата низа: {0}", EditDistance());
            PrintEditOperations(N1, N2);
        }

        private static int ReplaceOrMatch(char c1, char c2)
        {
            return (c1 == c2) ? 0 : 3;
        }

        /* Намира разстоянието между два низа */

        private static int EditDistance()
        {
            /* Инициализация */
            for (int i = 0; i <= N1; i++)
            {
                F[i, 0] = i * CostDelete;
            }

            for (int j = 0; j <= N2; j++)
            {
                F[0, j] = j * CostInsert;
            }

            /* Основен цикъл */
            for (int i = 1; i <= N1; i++)
            {
                for (int j = 1; j <= N2; j++)
                {
                    F[i, j] = Math.Min(F[i - 1, j - 1] + ReplaceOrMatch(S1[i], S2[j]), Math.Min(F[i, j - 1] + CostInsert, F[i - 1, j] + CostDelete));
                }
            }

            return F[N1, N2];
        }

        /* Извежда операциите по редактирането */

        private static void PrintEditOperations(int i, int j)
        {
            if (j == 0)
            {
                for (j = 1; j <= i; j++)
                {
                    Console.Write("DELETE({0}) ", j);
                }
            }
            else if (i == 0)
            {
                for (i = 1; i <= j; i++)
                {
                    Console.Write("INSERT({0}, {1}) ", i, S2[i]);
                }
            }
            else if (i > 0 && j > 0)
            {
                if (F[i, j] == F[i - 1, j - 1] + ReplaceOrMatch(S1[i], S2[j]))
                {
                    PrintEditOperations(i - 1, j - 1);
                    if (ReplaceOrMatch(S1[i], S2[j]) > 0)
                    {
                        Console.Write("REPLACE({0}, {1}) ", i, S2[j]);
                    }
                }
                else if (F[i, j] == F[i, j - 1] + CostInsert)
                {
                    PrintEditOperations(i, j - 1);
                    Console.Write("INSERT({0}, {1}) ", i, S2[j]);
                }
                else if (F[i, j] == F[i - 1, j] + CostDelete)
                {
                    PrintEditOperations(i - 1, j);
                    Console.Write("DELETE({0}) ", i);
                }
            }
        }
    }
}