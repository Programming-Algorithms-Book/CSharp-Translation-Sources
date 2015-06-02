using System;
using System.Collections.Generic;

class DijkstraAlgorithm
{
    const int VerticesCount = 10;
    const int StartVertex = 1;
    const int NoParent = -1;
    const int MaxValue = 1000000;

    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0, 23, 0, 0, 0, 0, 0, 8, 0, 0 },
        {23, 0, 0, 3, 0, 0, 34, 0, 0, 0 },
        { 0, 0, 0, 6, 0, 0, 0, 25, 0, 7 },
        { 0, 3, 6, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 10, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 10, 0, 0, 0, 0, 0 },
        { 0, 34, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 8, 0, 25, 0, 0, 0, 0, 0, 0, 30 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 7, 0, 0, 0, 0, 30, 0, 0 }
    };
    static readonly HashSet<int> T = new HashSet<int>();
    static readonly int[] DijkstraDistances = new int[VerticesCount];
    static readonly int[] Predecessors = new int[VerticesCount];

    // Алгоритъм на Дейкстра - минимален път от s до останалите върхове
    static void Dijkstra(int startVertex)
    {
        // Инициализиране: DijkstraDistances[i] = A[StartVertex, i], i∈V, i != StartVertex
        for (int i = 0; i < VerticesCount; i++)
            if (Graph[startVertex, i] == 0)
            {
                DijkstraDistances[i] = MaxValue;
                Predecessors[i] = NoParent;
            }
            else
            {
                DijkstraDistances[i] = Graph[startVertex, i];
                Predecessors[i] = startVertex;
            }

        for (int i = 0; i < VerticesCount; i++)
            T.Add(i);          // T съдържа всички върхове
        T.Remove(startVertex); // от графа, с изключение на startVertex
        Predecessors[startVertex] = NoParent;

        while (T.Count > 0)
        {
            // Избиране на върха j от T, за който DijkstraDistances[j] е минимално
            int j = NoParent;
            int distanceToI = MaxValue;
            for (int i = 0; i < VerticesCount; i++)
                if (T.Contains(i) && DijkstraDistances[i] < distanceToI)
                {
                    distanceToI = DijkstraDistances[i];
                    j = i;
                }

            if (j == NoParent) break; // DijkstraDistances[i] = MaxValue, за всички i: изход
            T.Remove(j);

            // За всяко i от T изпълняваме DijkstraDistances[i] = 
            // min(DijkstraDistances[i], DijkstraDistances[j] + Graph[j, i])
            for (int i = 0; i < VerticesCount; i++)
                if (T.Contains(i) && Graph[j, i] != 0)
                    if (DijkstraDistances[i] > DijkstraDistances[j] + Graph[j, i])
                    {
                        DijkstraDistances[i] = DijkstraDistances[j] + Graph[j, i];
                        Predecessors[i] = j;
                    }
        }
    }

    static void PrintPath(int startVertex, int vertex)
    {
        if (Predecessors[vertex] != startVertex) PrintPath(startVertex, Predecessors[vertex]);
        Console.Write("{0} ", vertex + 1);
    }

    static void PrintResult(int startVertex)
    {
        for (int i = 0; i < VerticesCount; i++)
            if (i != startVertex)
                if (DijkstraDistances[i] == MaxValue)
                    Console.WriteLine("Няма път между върховете {0} и {1}", startVertex + 1, i + 1);
                else
                {
                    Console.Write("Минимален път от връх {0} до {1}: {0} ", startVertex + 1, i + 1);
                    PrintPath(startVertex, i);
                    Console.WriteLine(", дължина на пътя: {0}", DijkstraDistances[i]);
                }
    }

    static void Main()
    {
        Dijkstra(StartVertex - 1);
        PrintResult(StartVertex - 1);
    }
}
