namespace Fibrec
{
    using System;

    public class Fibrec
    {
        private const int N = 7;

        internal static void Main()
        {
            Console.WriteLine("Fib({0}) = {1}", N, Fib(N));
        }

        private static int Fib(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
    }
}