using System;

class PreprocessedPrimeNumbersFinder
{
    static uint[] primeNumbers = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 
                                     47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
    const uint n = 23;

    static void Main()
    {
        if (IsPrime(n))
            Console.WriteLine("Числото {0} е просто.", n);
        else
            Console.WriteLine("Числото {0} е съставно.", n);
    }

    static bool IsPrime(uint number)
    {
        uint i = 0;
        while (i < primeNumbers.Length && primeNumbers[i] * primeNumbers[i] <= n)
        {
            if (n % primeNumbers[i] == 0) return false;
            i++;
        }

        return true;
    }
}

