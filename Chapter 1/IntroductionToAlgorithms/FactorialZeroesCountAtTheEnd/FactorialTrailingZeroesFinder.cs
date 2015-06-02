using System;

class FactorialTrailingZeroesFinder
{
    const uint n = 10;

    static void Main()
    {
        uint zeroesCount = 0;
        uint p = 5;
        while (n >= p)
        {
            zeroesCount += (n / p);
            p *= 5;
        }

        Console.WriteLine("Броят на нулите в края на {0}! е {1}", n, zeroesCount);
    }
}
