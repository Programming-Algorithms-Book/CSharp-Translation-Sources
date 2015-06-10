namespace RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        private const uint N = 7;

        internal static void Main()
        {
            Console.WriteLine("Fibonacci({0}) = {1}", N, GetFibonacciNumber(N));
        }

        private static ulong GetFibonacciNumber(uint number)
        {
            if (number < 2)
            {
                return number;
            }

            return GetFibonacciNumber(number - 1) + GetFibonacciNumber(number - 2);
        }
    }
}
