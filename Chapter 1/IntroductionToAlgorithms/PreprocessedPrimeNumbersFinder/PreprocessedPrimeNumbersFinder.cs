namespace PreprocessedPrimeNumbersFinder
{
    using System;

    public class PreprocessedPrimeNumbersFinder
    {
        private const uint N = 23;

        private static uint[] primeNumbers =
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,
            47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
        };

        internal static void Main()
        {
            if (IsPrime(N))
            {
                Console.WriteLine("Числото {0} е просто.", N);
            }
            else
            {
                Console.WriteLine("Числото {0} е съставно.", N);
            }
        }

        private static bool IsPrime(uint number)
        {
            uint i = 0;
            while (i < primeNumbers.Length && primeNumbers[i] * primeNumbers[i] <= N)
            {
                if (N % primeNumbers[i] == 0)
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}