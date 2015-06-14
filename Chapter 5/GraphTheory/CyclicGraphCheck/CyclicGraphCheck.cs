namespace CyclicGraphCheck
{
    using System;

    internal class CyclicGraphCheck
    {
        private const int VerticesCount = 14;

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
        private static bool isCyclicGraph = false;

        // Модифициран Depth-First-Search
        private static void DFS(int vertex, int parent)
        {
            Used[vertex] = true;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (isCyclicGraph)
                {
                    return;
                }

                if (Graph[vertex, i] == 1)
                {
                    if (Used[i] && i != parent)
                    {
                        Console.WriteLine("Графът е цикличен!");
                        isCyclicGraph = true;
                        return;
                    }
                    else if (i != parent)
                    {
                        DFS(i, vertex);
                    }
                }
            }
        }

        private static void Main()
        {
            for (int i = 0; i < VerticesCount; i++)
            {
                if (!Used[i])
                {
                    DFS(i, -1);
                }

                if (isCyclicGraph)
                {
                    return;
                }
            }

            Console.WriteLine("Графът е дърво (не съдържа цикли)!");
        }
    }
}