using System;

class VariationsGenerator
{
    const uint n = 4;
    const uint k = 2;

    static readonly uint[] Variation = new uint[k];

    static void Print(uint i)
    {
        Console.Write("( ");
        for (uint k = 0; k < i; k++) Console.Write("{0} ", Variation[k] + 1);
        Console.WriteLine(")");
    }

    // Вариации на n елемента от клас k
    static void GenerateVariations(uint i)
    {
        /* Без if (i >= k) и return; тук (а само Print(i); ако искаме всички
         * генерирания с дължина 1, 2, …, k, а не само вариациите с дължина k */
        if (i >= k) { Print(i); return; }
        for (uint j = 0; j < n; j++)
        {
            // if (allowed(k)) {
            Variation[i] = j;
            GenerateVariations(i + 1);
        }
    }

    static void Main()
    {
        GenerateVariations(0);
    }
}
