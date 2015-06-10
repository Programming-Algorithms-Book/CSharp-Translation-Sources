namespace FastRecursiveFactorialCalculator
{
    using System;

    public class FastRecursiveFactorialCalculator
    {
        private const uint N = 6;
        private static uint i = 0;

        internal static void Main()
        {
            i = N + 1;
            Console.WriteLine("{0}! = {1}", N, GetFactorial());
        }

        private static ulong GetFactorial()
        {
            if (i == 1)
            {
                return 1;
            }

            return --i * GetFactorial();
        }
    }
}
