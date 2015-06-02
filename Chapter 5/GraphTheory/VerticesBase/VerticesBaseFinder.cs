using System;
using System.Collections.Generic;

class VerticesBaseFinder
{
    const int VerticesCount = 9;

    static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
    {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 0, 1, 0, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 1, 0 },
        { 0, 0, 0, 0, 0, 1, 0, 0, 0 },
        { 0, 0, 0, 1, 1, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 1, 0, 0, 0 },
        { 0, 1, 0, 0, 0, 0, 0, 0, 0 }
    };
    static readonly bool[] Used = new bool[VerticesCount];
    static readonly HashSet<int> NonVerticesBase = new HashSet<int>();

    static void GetVerticesBase(int vertex)
    {
        Used[vertex] = true;
        for (int i = 0; i < VerticesCount; i++)
            if (Graph[vertex, i] == 1 && !Used[i])
            {
                NonVerticesBase.Add(i);
                GetVerticesBase(i);
            }
    }

    static void Main()
    {
        for (int i = 0; i < VerticesCount; i++)
            if (!NonVerticesBase.Contains(i))
            {
                for (int j = 0; j < VerticesCount; j++) Used[j] = false;
                GetVerticesBase(i);
            }

        Console.Write("Върховете, образуващи база в графа са: ");
        for (int i = 0; i < VerticesCount; i++)
            if (!NonVerticesBase.Contains(i)) Console.Write("{0} ", i + 1);
        Console.WriteLine("\nБрой на върховете в базата: {0}", VerticesCount - NonVerticesBase.Count);
    }
}
