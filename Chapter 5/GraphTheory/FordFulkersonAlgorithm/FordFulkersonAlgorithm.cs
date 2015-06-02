using System;

class FordFulkersonAlgorithm
{
    const int VerticesCount = 6;
    const int StartVertex = 1; // Връх-източник
    const int EndVertex = 6; // Връх-консуматор

    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0, 5, 5, 10, 0, 0 },
        { 0, 0, 4, 0, 0, 5 },
        { 0, 0, 0, 0, 7, 0 },
        { 0, 0, 0, 0, 0, 7 },
        { 0, 0, 0, 0, 0, 8 },
        { 0, 0, 0, 0, 0, 0 }
    };
    static readonly int[,] FlowGraph = new int[VerticesCount, VerticesCount];
    static readonly bool[] Used = new bool[VerticesCount];
    static readonly int[] Path = new int[VerticesCount];
    static bool found = false;

    static void FindAugmentingPath(int vertex, int level)
    {
        if (found) return;
        if (vertex == EndVertex - 1)
        {
            found = true;
            UpdateFlow(level - 1);
        }
        else
            for (int i = 0; i < VerticesCount; i++)
                if (!Used[i] && Graph[vertex, i] > 0)
                {
                    Used[i] = true;
                    Path[level] = i;
                    FindAugmentingPath(i, level + 1);
                    if (found) return;
                }
    }

    static void UpdateFlow(int level)
    {
        int increasingFlow = int.MaxValue;
        Console.Write("Намерен увеличаващ път: ");
        for (int i = 0; i < level; i++)
        {
            int p1 = Path[i];
            int p2 = Path[i + 1];
            Console.Write("{0}, ", p1 + 1);
            if (increasingFlow > Graph[p1, p2]) increasingFlow = Graph[p1, p2];
        }
        Console.WriteLine("{0} ", Path[level] + 1);

        for (int i = 0; i < level; i++)
        {
            int p1 = Path[i];
            int p2 = Path[i + 1];
            FlowGraph[p1, p2] += increasingFlow;
            FlowGraph[p2, p1] -= increasingFlow;
            Graph[p1, p2] -= increasingFlow;
            Graph[p2, p1] += increasingFlow;
        }
    }

    static void Main()
    {
        // Намира увеличаващ път, докато е възможно
        do
        {
            for (int i = 0; i < VerticesCount; i++) Used[i] = false;
            found = false;
            Used[StartVertex - 1] = true;
            Path[0] = StartVertex - 1;
            FindAugmentingPath(StartVertex - 1, 1);
        } while (found);

        Console.WriteLine("Максимален поток през графа:");
        for (int i = 0; i < VerticesCount; i++)
        {
            for (int j = 0; j < VerticesCount; j++) Console.Write("{0,4}", FlowGraph[i, j]);
            Console.WriteLine();
        }

        int flow = 0;
        for (int i = 0; i < VerticesCount; i++) flow += FlowGraph[i, EndVertex - 1];
        Console.WriteLine("С големина: {0}", flow);
    }
}
