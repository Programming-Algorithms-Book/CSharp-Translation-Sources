using System;

class IterativeGreatestCommonDivisor
{
    const uint a = 24;
    const uint b = 108;

    static uint GetGreatestCommonDivisor(uint a, uint b)
    {
        uint swap = 0;
        while (b > 0)
        {
            swap = b;
            b = a % b;
            a = swap;
        }

        return a;
    }

    static void Main()
    {
        Console.WriteLine("Най-големият общ делител на {0} и {1} е {2}",
            a, b, GetGreatestCommonDivisor(a, b));
    }
}
