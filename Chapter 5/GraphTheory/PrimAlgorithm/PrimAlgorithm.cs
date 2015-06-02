using System;

class PrimAlgorithm
{
    const int VerticesCount = 9;

    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0,  1, 0,  2,  0,  0,  0, 0,  0 },
        { 1,  0, 3,  0, 13,  0,  0, 0,  0 },
        { 0,  3, 0,  4,  0,  3,  0, 0,  0 },
        { 2,  0, 4,  0,  0, 16, 14, 0,  0 },
        { 0, 13, 0,  0,  0, 12,  0, 1, 13 },
        { 0,  0, 3, 16, 12,  0,  1, 0,  1 },
        { 0,  0, 0, 14,  0,  1,  0, 0,  0 },
        { 0,  0, 0,  0,  1,  0,  0, 0,  0 },
        { 0,  0, 0,  0, 13,  1,  0, 0,  0 }
    };
    static readonly bool[] Used = new bool[VerticesCount];
    static readonly int[] Previous = new int[VerticesCount];
    static readonly int[] T = new int[VerticesCount];

    static void FindMinSpanningTree()
    {
        Used[0] = true; // Избираме произволен начален връх
        for (int i = 0; i < VerticesCount; i++)
            T[i] = (Graph[0, i] != 0) ? Graph[0, i] : int.MaxValue;

        int minSpanningTree = 0;
        for (int k = 0; k < VerticesCount - 1; k++)
        {
            // Tърсене на следващо минимално ребро
            int minDistance = int.MaxValue;
            int j = -1;
            for (int i = 0; i < VerticesCount; i++)
                if (!Used[i] && T[i] < minDistance)
                {
                    minDistance = T[i];
                    j = i;
                }

            Used[j] = true;
            Console.Write("({0}, {1}) ", Previous[j] + 1, j + 1);
            minSpanningTree += minDistance;
            for (int i = 0; i < VerticesCount; i++)
                if (!Used[i] && Graph[j, i] != 0 && T[i] > Graph[j, i])
                {
                    T[i] = Graph[j, i];
                    // Запазване на предшественика, за евентуално отпечатване на следващо минимално ребро
                    Previous[i] = j;
                }
        }

        Console.WriteLine("\nЦената на минималното покриващо дърво е {0}.", minSpanningTree);
    }

    static void Main()
    {
        FindMinSpanningTree();
    }
}
