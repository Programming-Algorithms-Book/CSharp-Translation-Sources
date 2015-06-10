namespace PrimeNimbersEratosthenes
{
    using System;

    public class PrimeNimbersEratosthenesSieve
    {
        private const uint N = 200;
        private static bool[] sieve = new bool[N + 1];

        internal static void Main()
        {
            FindPrimeNumbersToN(N);
            Console.WriteLine();
        }

        private static void FindPrimeNumbersToN(uint n)
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
}