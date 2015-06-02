using System;
using System.Collections.Generic;

class ListPreprocessedPrimeNumbersFinder
{
    const uint n = 500;
    static List<uint> primeNumbers = new List<uint>();

    static void Main()
    {
        FindPrimeNumbersToN(n);
        Console.WriteLine();
    }

    static void FindPrimeNumbersToN(uint n)
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

    static bool IsPrime(uint number)
    {
        int i = 0;
        int primeNumbersCount = primeNumbers.Count;
        while (i < primeNumbersCount && primeNumbers[i] * primeNumbers[i] <= n)
        {
            if (number % primeNumbers[i] == 0) return false;
            i++;
        }

        return true;
    }
}
