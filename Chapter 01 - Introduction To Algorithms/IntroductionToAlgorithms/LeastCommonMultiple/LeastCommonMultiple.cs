namespace LeastCommonMultiple
{
    using System;

    public class LeastCommonMultiple
    {
        private const uint N = 4;
        private static readonly uint[] A = { 10, 8, 5, 9 };

        internal static void Main()
        {
            Console.WriteLine(GetLeastCommonMultiple(A, N));
        }

        private static uint GetGreatestCommonDivisor(uint a, uint b)
        {
            return (b == 0) ? a : GetGreatestCommonDivisor(b, a % b);
        }

        private static uint GetLeastCommonMultiple(uint[] a, uint n)
        {
            if (n == 2)
            {
                return (a[0] * a[1]) / GetGreatestCommonDivisor(a[0], a[1]);
            }
            else
            {
                uint b = GetLeastCommonMultiple(a, n - 1);
                return (a[n - 1] * b) / GetGreatestCommonDivisor(a[n - 1], b);
            }
        }
    }
}
