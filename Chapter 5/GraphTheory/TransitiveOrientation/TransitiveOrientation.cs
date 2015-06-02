using System;

class TransitiveOrientation
{
    const int VerticesCount = 6;

    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0, 1, 0, 0, 0, 1 },
        { 1, 0, 1, 0, 0, 0 },
        { 0, 1, 0, 1, 0, 0 },
        { 0, 0, 1, 0, 1, 0 },
        { 0, 0, 0, 1, 0, 1 },
        { 1, 0, 0, 0, 1, 0 }
    };

    /* // Пример за транзитивно неориентируем граф
    const int VerticesCount = 5;
    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0, 1, 0, 0, 1 },
        { 1, 0, 1, 0, 0 },
        { 0, 1, 0, 1, 0 },
        { 0, 0, 1, 0, 1 },
        { 1, 0, 0, 1, 0 }
    }; */

    static bool IsTransitiveOrientable()
    {

        // Намира броя на ребрата в графа
        int tr = 0;
        for (int i = 0; i < VerticesCount - 1; i++)
            for (int j = i + 1; j < VerticesCount; j++)
                if (Graph[i, j] != 0) tr++;

        // Повтаряме, докато всички ребра от графа бъдат ориентирани
        int r = 0;
        do
        {
            // Стъпка 1 – ориентираме произволно ребро (i,j)
            for (int i = 0; i < VerticesCount; i++)
            {
                int j = 0;
                for (; j < VerticesCount; j++)
                    if (Graph[i, j] == 1)
                    {
                        Graph[i, j] = 2;
                        Graph[j, i] = -2;
                        break;
                    }

                if (j < VerticesCount) break;
            }

            // Прилагаме правило 1) и 2), докато е възможно
            bool flag;
            do
            {
                flag = false;
                for (int i = 0; i < VerticesCount; i++)
                    for (int j = 0; j < VerticesCount; j++)
                        if (Graph[i, j] == 2)
                            for (int k = 0; k < VerticesCount; k++)
                                if (i != k && j != k)
                                {
                                    if (Graph[i, k] == 0 || Graph[i, k] < -2) // случай 2.1)
                                    {
                                        // a) -> графът е транзитивно неориентируем
                                        if (Graph[j, k] == 2) return false;
                                        // b) -> ориентираме реброто (j,k)
                                        if (Graph[j, k] == 1)
                                        {
                                            Graph[k, j] = 2;
                                            Graph[j, k] = -2;
                                            flag = true;
                                        }
                                    }

                                    if (Graph[j, k] == 0 || Graph[j, k] < -2) // случай 2.2)
                                    {
                                        // a) -> графът е транзитивно неориентируем
                                        if (Graph[k, i] == 2) return false;
                                        // b) -> ориентираме реброто (j,k)
                                        if (Graph[i, k] == 1)
                                        {
                                            Graph[i, k] = 2;
                                            Graph[k, i] = -2;
                                            flag = true;
                                        }
                                    }
                                }
            } while (flag);

            // Стъпка 3 – изключваме ориентираните ребра от графа
            for (int i = 0; i < VerticesCount; i++)
                for (int j = 0; j < VerticesCount; j++)
                    if (Graph[i, j] == 2)
                    {
                        Graph[i, j] = -3;
                        Graph[j, i] = -4;
                        r++;
                    }
        } while (r < tr);

        return true;
    }

    static void PrintGraph()
    {
        Console.WriteLine("Транзитивната ориентация е:");
        for (int i = 0; i < VerticesCount; i++)
        {
            for (int j = 0; j < VerticesCount; j++)
                if (Graph[i, j] == -3) Console.Write("  1");
                else
                {
                    if (Graph[i, j] == -4) Console.Write(" -1");
                    else Console.Write("  0");
                }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        if (IsTransitiveOrientable()) PrintGraph();
        else Console.WriteLine("Графът е транзитивно неориентируем!");
    }
}
