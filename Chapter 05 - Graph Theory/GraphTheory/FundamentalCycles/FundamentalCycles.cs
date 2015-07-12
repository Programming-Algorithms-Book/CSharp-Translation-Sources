namespace FundamentalCycles
{
    using System;
    using System.Collections.Generic;

    public class FundamentalCycles
    {
        private const int VerticesCount = 6;

        /* Графът, представен с матрица на съседство: 0 - няма ребро; 1 – има;
         * По-късно с 2 ще маркираме ребрата на покриващото дърво на графа. */
        private static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
        {
            { 0, 1, 1, 0, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 1, 1, 0, 0, 0, 1 },
            { 0, 1, 0, 0, 1, 1 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 1, 1, 1, 0 }
        };

        private static readonly bool[] Used = new bool[VerticesCount];
        private static readonly List<int> Cycle = new List<int>();

        internal static void Main()
        {
            FindSpanningTree(0);
            Console.WriteLine("Простите цикли в графа са:");
            for (int i = 0; i < VerticesCount - 1; i++)
            {
                for (int j = i + 1; j < VerticesCount; j++)
                {
                    if (Graph[i, j] == 1)
                    {
                        for (int k = 0; k < VerticesCount; k++)
                        {
                            Used[k] = false;
                        }

                        Cycle.Clear();
                        Cycle.Add(i);
                        FindCycle(i, j);
                    }
                }
            }
        }

        // Намира произволно покриващо дърво
        private static void FindSpanningTree(int vertex)
        {
            Used[vertex] = true;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (!Used[i] && Graph[vertex, i] == 1)
                {
                    Graph[vertex, i] = 2;
                    Graph[i, vertex] = 2;
                    FindSpanningTree(i);
                }
            }
        }

        // Намиране на един цикъл спрямо намереното покриващо дърво
        private static void FindCycle(int v, int u)
        {
            if (v == u)
            {
                PrintCycle();
                return;
            }

            Used[v] = true;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (!Used[i] && Graph[v, i] == 2)
                {
                    Cycle.Add(i);
                    FindCycle(i, u);
                    Cycle.RemoveAt(Cycle.Count - 1);
                }
            }
        }

        private static void PrintCycle()
        {
            for (int i = 0; i < Cycle.Count; i++)
            {
                Console.Write("{0} ", Cycle[i] + 1);
            }

            Console.WriteLine();
        }
    }
}