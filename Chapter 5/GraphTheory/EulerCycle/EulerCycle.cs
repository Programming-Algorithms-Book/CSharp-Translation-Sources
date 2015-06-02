using System;
using System.Collections.Generic;

class EulerCycle
{
    const int VerticesCount = 8;

    static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
    {
        { 0, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 1, 0, 1, 0, 0, 0 },
        { 0, 0, 0, 1, 1, 0, 1, 0 },
        { 0, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 1, 0, 0, 1, 0, 0 },
        { 0, 0, 1, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0 }
    };

    static void FindEulerCycle(int vertex)
    {
        Stack<int> currentCycle = new Stack<int>();
        Stack<int> mergedCycles = new Stack<int>();
        currentCycle.Push(vertex);
        while (currentCycle.Count > 0)
        {
            vertex = currentCycle.Peek();
            int i = 0;
            for (i = 0; i < VerticesCount; i++)
                if (Graph[vertex, i] == 1)
                {
                    Graph[vertex, i] = 0;
                    vertex = i;
                    break;
                }

            if (i < VerticesCount)
                currentCycle.Push(i);
            else
                mergedCycles.Push(currentCycle.Pop());
        }

        Console.Write("Ойлеровият цикъл е: ");
        while (mergedCycles.Count > 0)
            Console.Write("{0} ", mergedCycles.Pop() + 1);

        Console.WriteLine();
    }

    static bool IsEulerGraph()
    {
        for (int i = 0; i < VerticesCount; i++)
        {
            int edgesIn = 0;
            int edgesOut = 0;
            for (int j = 0; j < VerticesCount; j++)
            {
                if (Graph[i, j] == 1) edgesIn++;
                if (Graph[j, i] == 1) edgesOut++;
            }

            if (edgesIn != edgesOut) return false;
        }

        return true;
    }

    static void Main()
    {
        if (IsEulerGraph()) FindEulerCycle(0);
        else Console.WriteLine("Графът не е Ойлеров!");
    }
}
