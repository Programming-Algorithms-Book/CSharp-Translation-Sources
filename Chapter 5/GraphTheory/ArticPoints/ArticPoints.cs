using System;
using System.Collections.Generic;

class ArticPoints
{
    const int VerticesCount = 7;

    // Матрица на съседство на графа
    static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
    {
        { 0, 1, 0, 0, 0, 0, 0 },
        { 1, 0, 1, 0, 0, 1, 0 },
        { 0, 1, 0, 1, 0, 1, 0 },
        { 0, 0, 1, 0, 1, 1, 0 },
        { 0, 0, 0, 1, 0, 0, 0 },
        { 0, 1, 1, 1, 0, 0, 1 },
        { 0, 0, 0, 0, 0, 1, 0 }
    };
    static readonly int[] Prenum = new int[VerticesCount];
    static readonly int[] Lowest = new int[VerticesCount];
    static int cN = 0;

    static void DFS(int vertex)
    {
        Prenum[vertex] = ++cN;
        for (int j = 0; j < VerticesCount; j++)
            if (Graph[vertex, j] != 0 && Prenum[j] == 0)
            {
                Graph[vertex, j] = 2; // Строим покриващо дърво T
                DFS(j);
            }
    }

    // Обхождане на дървото в postorder
    static void TraversePostOrder(int vertex)
    {
        for (int j = 0; j < VerticesCount; j++)
            if (Graph[vertex, j] == 2) TraversePostOrder(j);
        Lowest[vertex] = Prenum[vertex];
        for (int j = 0; j < VerticesCount; j++)
            if (Graph[vertex, j] == 1) Lowest[vertex] = Math.Min(Lowest[vertex], Prenum[j]);
        for (int j = 0; j < VerticesCount; j++)
            if (Graph[vertex, j] == 2) Lowest[vertex] = Math.Min(Lowest[vertex], Lowest[j]);
    }

    static void FindArticPoints()
    {
        DFS(0);
        for (int i = 0; i < VerticesCount; i++)
            if (Prenum[i] == 0)
            {
                Console.WriteLine("Графът не е свързан!");
                return;
            }

        TraversePostOrder(0);

        List<int> articPoints = new List<int>();
        // Проверяваме 3.1)
        int count = 0;
        for (int i = 0; i < VerticesCount; i++)
            if (Graph[0, i] == 2) count++;
        if (count > 1) articPoints.Add(0);

        // Прилагаме стъпка 2)
        for (int i = 1; i < VerticesCount; i++)
        {
            int j = 0;
            for (; j < VerticesCount; j++)
                if (Graph[i, j] == 2 && Lowest[j] >= Prenum[i]) break;
            if (j < VerticesCount)
                articPoints.Add(i);
        }

        Console.Write("Разделящите точки в графа са: ");
        for (int i = 0; i < articPoints.Count; i++)
            Console.Write("{0} ", articPoints[i] + 1);
        Console.WriteLine();
    }

    static void Main()
    {
        FindArticPoints();
    }
}
