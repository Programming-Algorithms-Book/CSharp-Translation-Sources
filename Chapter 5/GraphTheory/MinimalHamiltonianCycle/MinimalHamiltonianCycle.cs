using System;

class MinimalHamiltonianCycle
{
    const int VerticesCount = 6;

    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0, 5, 0, 0, 7, 7 },
        { 5, 0, 5, 0, 0, 0 },
        { 0, 5, 0, 6, 5, 0 },
        { 0, 0, 6, 0, 3, 3 },
        { 7, 0, 5, 3, 0, 5 },
        { 7, 0, 0, 3, 5, 0 }
    };
    static readonly bool[] Used = new bool[VerticesCount];
    static readonly int[] CurrentCycle = new int[VerticesCount];
    static readonly int[] MinimalCycle = new int[VerticesCount];
    static int currentSum = 0, minSum = int.MaxValue;

    static void FindMinHamiltonianCycle(int vertex, int level)
    {
        if (vertex == 0 && level > 0)
        {
            if (level == VerticesCount)
            {
                minSum = currentSum;
                CurrentCycle.CopyTo(MinimalCycle, 0);
            }

            return;
        }

        if (Used[vertex]) return;
        Used[vertex] = true;
        for (int i = 0; i < VerticesCount; i++)
            if (Graph[vertex, i] != 0 && i != vertex)
            {
                CurrentCycle[level] = i;
                currentSum += Graph[vertex, i];
                if (currentSum < minSum) // Прекъсване на генерирането
                    FindMinHamiltonianCycle(i, level + 1);
                currentSum -= Graph[vertex, i];
            }

        Used[vertex] = false;
    }

    static void PrintCycle()
    {
        Console.Write("Минимален Хамилтонов цикъл: 1");
        for (int i = 0; i < VerticesCount; i++)
            Console.Write(" {0}", MinimalCycle[i] + 1);
        Console.WriteLine(" с дължина {0}.", minSum);
    }

    static void Main()
    {
        CurrentCycle[0] = 1;
        FindMinHamiltonianCycle(0, 0);
        PrintCycle();
    }
}
