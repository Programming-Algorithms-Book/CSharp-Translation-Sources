using System;

class PrimeNimbersEratosthenesSieve
{
    const uint n = 200;
    static bool[] sieve = new bool[n + 1];

    static void Main()
    {
        FindPrimeNumbersToN(n);
        Console.WriteLine();
    }

    static void FindPrimeNumbersToN(uint n)
    {
        uint i = 2;
        while (i <= n)
        {
            if (!sieve[i])
            {
                Console.Write("{0} ", i);
                uint j = i * i;
                while (j <= n)
                {
                    sieve[j] = true;
                    j += i;
                }
            }

            i++;
        }
    }
}