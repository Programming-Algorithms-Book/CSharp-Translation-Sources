using System;

class TopologicalSorter
{
    const int VerticesCount = 5;

    static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
    {
        { 0, 1, 0, 0, 0 },
        { 0, 0, 1, 0, 1 },
        { 0, 0, 0, 1, 0 },
        { 0, 0, 0, 0, 0 },
        { 0, 0, 1, 0, 0 }
    };
    static readonly bool[] Used = new bool[VerticesCount];

    static void TopologicalSort(int vertex)
    {
        Used[vertex] = true;
        for (int i = 0; i < VerticesCount; i++)
            if (Graph[vertex, i] == 1 && !Used[i]) TopologicalSort(i);
        Console.Write("{0} ", vertex + 1);
    }

    static void Main()
    {
        Console.Write("Топологично сортиране (в обратен ред): ");
        for (int i = 0; i < VerticesCount; i++)
            if (!Used[i]) TopologicalSort(i);
        Console.WriteLine();
    }
}
