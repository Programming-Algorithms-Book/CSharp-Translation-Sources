using System;

class LongestPath
{
    const int VerticesCount = 6;

    // Матрица на теглата на графа
    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0, 12, 0, 0, 0, 0 },
        { 0, 0, 40, 0, 17, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 30, 0 },
        { 0, 0, 0, 0, 0, 20 },
        { 0, 0, 20, 0, 0, 0 }
    };

    static readonly int[] MaximalDistances = new int[VerticesCount];
    static readonly int[] SavePath = new int[VerticesCount];

    static void DFS(int vertex)
    {
        if (MaximalDistances[vertex] > 0) return;
        int max = MaximalDistances[vertex];
        for (int i = 0; i < VerticesCount; i++)
            if (Graph[vertex, i] != 0)
            {
                DFS(i);
                int distance = MaximalDistances[i] + Graph[vertex, i];
                if (distance > max)
                {
                    max = distance;
                    SavePath[vertex] = i;
                }
            }

        MaximalDistances[vertex] = max;
    }

    static void Main()
    {
        for (int i = 0; i < VerticesCount; i++)
            SavePath[i] = -1;

        for (int i = 0; i < VerticesCount; i++)
            if (MaximalDistances[i] == 0) DFS(i);

        int maxI = 0;
        for (int i = 0; i < VerticesCount; i++)
            if (MaximalDistances[i] > MaximalDistances[maxI]) maxI = i;

        Console.Write("Дължината на критичния път е {0}\nПътят е: ", MaximalDistances[maxI]);
        while (SavePath[maxI] >= 0)
        {
            Console.Write("{0} ", maxI + 1);
            maxI = SavePath[maxI];
        }

        Console.WriteLine("{0} ", maxI + 1);
    }
}
