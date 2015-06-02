using System;

class PCenter
{
    const int MaxValue = 1000000;
    const int VerticesCount = 7;
    const int P = 3; // P-център

    // Матрица на теглата на графа
    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0, 1, 0, 0, 2, 0, 0 },
        { 1, 0, 4, 0, 0, 0, 0 },
        { 0, 4, 0, 3, 0, 5, 0 },
        { 0, 0, 3, 0, 4, 0, 8 },
        { 2, 0, 0, 4, 0, 0, 0 },
        { 0, 0, 5, 0, 0, 0, 2 },
        { 0, 0, 0, 8, 0, 2, 0 }
    };
    static readonly int[] center = new int[VerticesCount];
    static readonly int[] pCenter = new int[P];
    static int pRadius = 0;

    // Намира дължината на минималния път между всяка двойка върхове
    static void Floyd()
    {
        InitializeGraph();
        // Алгоритъм на Флойд
        for (int k = 0; k < VerticesCount; k++)
            for (int i = 0; i < VerticesCount; i++)
                for (int j = 0; j < VerticesCount; j++)
                    if (Graph[i, j] > Graph[i, k] + Graph[k, j])
                        Graph[i, j] = Graph[i, k] + Graph[k, j];

        for (int i = 0; i < VerticesCount; i++) Graph[i, i] = 0;
    }

    static void InitializeGraph()
    {
        // Стойностите 0 се променят на MaxValue
        for (int i = 0; i < VerticesCount; i++)
            for (int j = 0; j < VerticesCount; j++)
                if (Graph[i, j] == 0) Graph[i, j] = MaxValue;
    }

    // Изчисляваме S за текущо генерираното подмножество
    static void FindPCenter()
    {
        int cRadius = 0;
        for (int j = 0; j < VerticesCount; j++)
        {
            int bT = MaxValue;
            for (int i = 0; i < P; i++)
                if (Graph[center[i], j] < bT) bT = Graph[center[i], j];
            if (cRadius < bT) cRadius = bT;
        }

        if (cRadius < pRadius)
        {
            pRadius = cRadius;
            for (int i = 0; i < P; i++) pCenter[i] = center[i];
        }
    }

    // Kомбинации C(n,p) – генериране на всички p-елементни подмножества на G
    static void GenerateCombinations(int k, int last)
    {
        for (int i = last; i < VerticesCount - P + k; i++)
        {
            center[k] = i;
            if (k == P)
                FindPCenter();
            else
                GenerateCombinations(k + 1, i + 1);
        }
    }

    // Печатаме p-центъра и p-радиуса
    static void PrintPCenter()
    {
        Console.Write("{0}-центърът в графа е следното множество от върхове: ( ", P);
        for (int i = 0; i < P; i++) Console.Write("{0} ", pCenter[i] + 1);
        Console.WriteLine(")");
        Console.WriteLine("{0}-радиусът в графа е {1}", P, pRadius);
    }

    static void Main()
    {
        Floyd();
        pRadius = MaxValue;
        GenerateCombinations(0, 0);
        PrintPCenter();
    }
}
