using System;

class MaximalIndependentSets
{
    const int VerticesCount = 8;

    static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
    {
        { 0, 1, 0, 0, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 0, 1, 0, 0 },
        { 0, 1, 0, 1, 1, 0, 0, 0 },
        { 0, 0, 1, 0, 1, 0, 1, 0 },
        { 0, 0, 1, 1, 0, 1, 0, 0 },
        { 1, 1, 0, 0, 1, 0, 1, 1 },
        { 0, 0, 0, 1, 0, 1, 0, 0 },
        { 1, 0, 0, 0, 0, 1, 0, 0 }
    };
    static readonly int[] S = new int[VerticesCount];
    static readonly int[] T = new int[VerticesCount];
    static int sN = 0;
    static int tN = 0;

    static void PrintSet()
    {
        Console.Write("{ ");
        for (int i = 0; i < VerticesCount; i++)
            if (T[i] == 1) Console.Write("{0} ", i + 1);
        Console.WriteLine("}");
    }

    static void FindMaxIndependentSets(int last)
    {
        if (sN + tN == VerticesCount)
        {
            PrintSet();
            return;
        }

        for (int i = last; i < VerticesCount; i++)
            if (S[i] == 0 && T[i] == 0)
            {
                for (int j = 0; j < VerticesCount; j++)
                    if (Graph[i, j] == 1 && S[j] == 0)
                    {
                        S[j] = last + 1; sN++;
                    }
                T[i] = 1; tN++;
                FindMaxIndependentSets(i + 1); // Рекурсия
                T[i] = 0; tN--;
                for (int j = 0; j < VerticesCount; j++)
                    if (S[j] == last + 1)
                    {
                        S[j] = 0; sN--;
                    }
            }
    }

    static void Main()
    {
        Console.WriteLine("Всички максимални независими множества в графа са:");
        FindMaxIndependentSets(0);
    }
}
