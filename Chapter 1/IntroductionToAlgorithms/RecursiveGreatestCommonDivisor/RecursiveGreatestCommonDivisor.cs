namespace RecursiveGreatestCommonDivisor
{
    using System;

    public class RecursiveGreatestCommonDivisor
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
            return (b == 0) ? a : GetGreatestCommonDivisor(b, a % b);
        }
    }
}
