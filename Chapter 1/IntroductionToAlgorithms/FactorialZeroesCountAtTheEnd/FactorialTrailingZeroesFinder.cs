namespace FactorialZeroesCountAtTheEnd
{
    using System;

    public class FactorialTrailingZeroesFinder
    {
        private const uint N = 10;

        internal static void Main()
        {
            uint zeroesCount = 0;
            uint p = 5;
            while (N >= p)
            {
                zeroesCount += N / p;
                p *= 5;
            }

            Console.WriteLine("Броят на нулите в края на {0}! е {1}", N, zeroesCount);
        }
    }
}
