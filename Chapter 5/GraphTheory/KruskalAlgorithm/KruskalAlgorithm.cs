using System;

struct Arc : IComparable<Arc>
{
    public int Vertex1 { get; set; }
    public int Vertex2 { get; set; }
    public int Weight { get; set; }

    public int CompareTo(Arc other)
    {
        return this.Weight.CompareTo(other.Weight);
    }
}

class KruskalAlgorithm
{
    const int NoParent = -1;
    const int VerticesCount = 9;
    const int EdgesCount = 13;

    // Списък от ребрата на графа и техните тегла
    static readonly Arc[] Graph = new Arc[EdgesCount]
    {
        new Arc() { Vertex1 = 1, Vertex2 = 2, Weight = 1 },
        new Arc() { Vertex1 = 1, Vertex2 = 4, Weight = 2 },
        new Arc() { Vertex1 = 2, Vertex2 = 3, Weight = 3 },
        new Arc() { Vertex1 = 2, Vertex2 = 5, Weight = 13 },
        new Arc() { Vertex1 = 3, Vertex2 = 4, Weight = 4 },
        new Arc() { Vertex1 = 3, Vertex2 = 6, Weight = 3 },
        new Arc() { Vertex1 = 4, Vertex2 = 6, Weight = 16 },
        new Arc() { Vertex1 = 4, Vertex2 = 7, Weight = 14 },
        new Arc() { Vertex1 = 5, Vertex2 = 6, Weight = 12 },
        new Arc() { Vertex1 = 5, Vertex2 = 8, Weight = 1 },
        new Arc() { Vertex1 = 5, Vertex2 = 9, Weight = 13 },
        new Arc() { Vertex1 = 6, Vertex2 = 7, Weight = 1 },
        new Arc() { Vertex1 = 6, Vertex2 = 9, Weight = 1 }
    };
    static readonly int[] Previous = new int[VerticesCount + 1];

    static void FindMinSpanningTree()
    {
        Array.Sort(Graph);

        Console.WriteLine("Ето ребрата, които участват в минималното покриващо дърво:");
        int minSpanningTree = 0;
        for (int i = 0; i < EdgesCount; i++)
        {
            int vertex1 = GetRoot(Graph[i].Vertex1);
            int vertex2 = GetRoot(Graph[i].Vertex2);
            if (vertex1 != vertex2)
            {
                Console.Write("({0}, {1}) ", Graph[i].Vertex1, Graph[i].Vertex2);
                minSpanningTree += Graph[i].Weight;
                Previous[vertex2] = vertex1;
            }
        }

        Console.WriteLine("\nЦената на минималното покриващо дърво е {0}.", minSpanningTree);
    }

    static int GetRoot(int vertex)
    {
        // Намиране на корена на дървото
        int root = vertex;
        while (Previous[root] != NoParent) root = Previous[root];

        // Свиване на пътя
        int saveVertex = 0;
        while (vertex != root)
        {
            saveVertex = vertex;
            vertex = Previous[vertex];
            Previous[saveVertex] = root;
        }
        return root;
    }

    static void Main()
    {
        for (int i = 0; i < VerticesCount + 1; i++) Previous[i] = NoParent;
        FindMinSpanningTree();
    }
}
