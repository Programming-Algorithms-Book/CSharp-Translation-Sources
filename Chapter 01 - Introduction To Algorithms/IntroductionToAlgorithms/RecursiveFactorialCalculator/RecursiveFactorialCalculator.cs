namespace RecursiveFactorialCalculator
{
    using System;

    public class RecursiveFactorialCalculator
    {
        private const uint N = 6;

        internal static void Main()
        {
            Console.WriteLine("{0}! = {1}", N, GetFactorial(N));
        }

        private static ulong GetFactorial(uint i)
        {
            if (i < 2)
            {
                return i;
            }

            return i * GetFactorial(i - 1);
        }
    }
}
