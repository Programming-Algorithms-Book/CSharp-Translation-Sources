using System;

class RecursiveGreatestCommonDivisor
{
    const uint a = 24;
    const uint b = 108;

    static uint GetGreatestCommonDivisor(uint a, uint b)
    {
        return (b == 0) ? a : GetGreatestCommonDivisor(b, a % b);
    }

    static void Main()
    {
        Console.WriteLine("Най-големият общ делител на {0} и {1} е {2}",
            a, b, GetGreatestCommonDivisor(a, b));
    }
}
