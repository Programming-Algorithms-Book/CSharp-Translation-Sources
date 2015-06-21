namespace ListPreprocessedPrimeNumbersFinder
{
    using System;
    using System.Collections.Generic;

    public class ListPreprocessedPrimeNumbersFinder
    {
        private const uint N = 500;
        private static IList<uint> primeNumbers = new List<uint>();

        internal static void Main()
        {
            FindPrimeNumbersToN(N);
            Console.WriteLine();
        }

        private static void FindPrimeNumbersToN(uint n)
        {
            uint i = 2;
            while (i < n)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                    Console.Write("{0} ", i);
                }

                i++;
            }
        }

        private static bool IsPrime(uint number)
        {
            int i = 0;
            int primeNumbersCount = primeNumbers.Count;
            while (i < primeNumbersCount && primeNumbers[i] * primeNumbers[i] <= N)
            {
                if (number % primeNumbers[i] == 0)
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}
