using System;

class CompanyControl
{
    const int VerticesCount = 6; // Брой компании (върхове в графа)
    const int MasterCompany = 1; // Tърсим кои компании контролира компания 1

    static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
    {
        { 0,  8, 40, 20, 55, 20 },
        { 0,  0,  0,  0,  0, 25 },
        { 0,  0,  0,  0,  0, 10 },
        { 0, 45,  0,  0,  0,  0 },
        { 0,  0,  0, 31,  0,  0 },
        { 0,  0,  0,  0,  0,  0 }
    };
    static readonly bool[] Used = new bool[VerticesCount];
    static readonly int[] Control = new int[VerticesCount];

    static void AddControls()
    {
        for (int i = 0; i < VerticesCount; i++)
            // Ако компания i е контролирана, прибавяме акциите ѝ към тези на MasterCompany
            if (Control[i] > 50 && !Used[i])
            {
                for (int j = 0; j < VerticesCount; j++) Control[j] += Graph[i, j];
                Used[i] = true;
            }
    }

    static void PrintResult()
    {
        Console.WriteLine("Компания {0} контролира следните компании:", MasterCompany);
        for (int i = 0; i < VerticesCount; i++)
            if (Control[i] > 50) Console.WriteLine("{0}: {1,3}%", i, Control[i]);
    }

    static void Main()
    {
        for (int i = 0; i < VerticesCount; i++) Control[i] = Graph[MasterCompany - 1, i];
        for (int i = 0; i < VerticesCount; i++) AddControls();
        PrintResult();
    }
}
