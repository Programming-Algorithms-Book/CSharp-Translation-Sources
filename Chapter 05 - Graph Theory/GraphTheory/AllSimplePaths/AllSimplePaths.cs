namespace AllSimplePaths
{
    using System;
    using System.Collections.Generic;

    public class AllSimplePaths
    {
        private const int VerticesCount = 14;
        private const int StartVertex = 1;
        private const int EndVertex = 10;

        private static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
        {
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0 }
        };

        private static readonly bool[] Used = new bool[VerticesCount];
        private static readonly List<int> Path = new List<int>();

        internal static void Main()
        {
            Console.WriteLine("Прости пътища между {0} и {1}:", StartVertex, EndVertex);
            AllDfs(StartVertex - 1, EndVertex - 1);
        }

        // Намира всички прости пътища между върховете i и j
        private static void AllDfs(int i, int j)
        {
            if (i == j)
            {
                Path.Add(j);
                PrintPath();
                Path.RemoveAt(Path.Count - 1);
                return;
            }

            Used[i] = true; // Маркиране на посетения връх
            Path.Add(i);

            // Рекурсия за всички съседи на i
            for (int k = 0; k < VerticesCount; k++)
            {
                if (Graph[i, k] == 1 && !Used[k])
                {
                    AllDfs(k, j);
                }
            }

            // Връщане: размаркиране на посетения връх
            Used[i] = false;
            Path.RemoveAt(Path.Count - 1);
        }

        private static void PrintPath()
        {
            for (int i = 0; i < Path.Count; i++)
            {
                Console.Write("{0} ", Path[i] + 1);
            }

            Console.WriteLine();
        }
    }
}