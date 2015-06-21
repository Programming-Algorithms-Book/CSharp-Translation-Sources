namespace FactorialCalculator
{
    using System;

    public class FactorialCalculator
    {
        internal static void Main()
        {
            Console.Write("Въведете N: ");
            uint n = uint.Parse(Console.ReadLine());
            ulong factorial = GetFactorial(n);
            Console.WriteLine("{0}! = {1}", n, factorial);
        }

        private static ulong GetFactorial(uint n)
        {
            ulong factorial = 1UL;
            for (uint i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
