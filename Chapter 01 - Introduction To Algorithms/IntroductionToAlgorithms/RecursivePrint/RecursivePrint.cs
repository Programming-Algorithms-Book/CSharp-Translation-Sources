namespace RecursivePrint
{
    using System;

    public class RecursivePrint
    {
        private const uint N = 7892;

        internal static void Main()
        {
            PrintN(N);
            Console.WriteLine();
        }

        private static void PrintN(uint n)
        {
            if (n >= 10)
            {
                PrintN(n / 10);
            }

            Console.Write(n % 10);
        }
    }
}
