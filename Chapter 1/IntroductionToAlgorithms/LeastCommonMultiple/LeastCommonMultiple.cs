using System;

class LeastCommonMultiple
{
    const uint n = 4;
    static readonly uint[] A = { 10, 8, 5, 9 };

    static uint GetGreatestCommonDivisor(uint a, uint b)
    {
        return (b == 0) ? a : GetGreatestCommonDivisor(b, a % b);
    }

    static uint GetLeastCommonMultiple(uint[] a, uint n)
    {
        if (n == 2)
            return (a[0] * a[1]) / GetGreatestCommonDivisor(a[0], a[1]);
        else
        {
            uint b = GetLeastCommonMultiple(a, n - 1);
            return (a[n - 1] * b) / GetGreatestCommonDivisor(a[n - 1], b);
        }
    }

    static void Main()
    {
        Console.WriteLine(GetLeastCommonMultiple(A, n));
    }
}
