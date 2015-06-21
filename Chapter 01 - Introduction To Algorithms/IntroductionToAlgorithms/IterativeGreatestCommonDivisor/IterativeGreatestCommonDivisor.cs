namespace IterativeGreatestCommonDivisor
{
    using System;

    public class IterativeGreatestCommonDivisor
    {
        private const uint A = 24;
        private const uint B = 108;

        internal static void Main()
        {
            Console.WriteLine(
                              "Най-големият общ делител на {0} и {1} е {2}",
                              A,
                              B,
                              GetGreatestCommonDivisor(A, B));
        }

        private static uint GetGreatestCommonDivisor(uint a, uint b)
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
    }
}
