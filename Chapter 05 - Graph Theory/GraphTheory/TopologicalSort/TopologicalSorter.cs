namespace TopologicalSort
{
    using System;

    public class TopologicalSorter
    {
        private const int VerticesCount = 5;

        private static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
        {
            { 0, 1, 0, 0, 0 },
            { 0, 0, 1, 0, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };

        private static readonly bool[] Used = new bool[VerticesCount];

        internal static void Main()
        {
            Console.Write("Топологично сортиране (в обратен ред): ");
            for (int i = 0; i < VerticesCount; i++)
            {
                if (!Used[i])
                {
                    TopologicalSort(i);
                }
            }

            Console.WriteLine();
        }

        private static void TopologicalSort(int vertex)
        {
            Used[vertex] = true;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (Graph[vertex, i] == 1 && !Used[i])
                {
                    TopologicalSort(i);
                }
            }

            Console.Write("{0} ", vertex + 1);
        }
    }
}