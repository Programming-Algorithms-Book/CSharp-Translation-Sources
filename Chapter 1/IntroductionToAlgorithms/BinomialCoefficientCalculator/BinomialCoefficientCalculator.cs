namespace BinomialCoefficientCalculator
{
    using System;
    using System.Collections.Generic;

    public class BinomialCoefficientCalculator
    {
        private static readonly List<long> Primes = new List<long>();
        private static readonly List<long> Counts = new List<long>();

        private static long n = 7;
        private static long k = 3;

        internal static void Main()
        {
            Console.Write("C({0}, {1}) = ", n, k);
            if (n - k < k)
            {
                k = n - k;
            }

            Solve(n - k + 1, n, 1); // Факторизира числителя (n – k + 1), ..., n
            Solve(1, k, -1); // Факторизира знаменателя 1, ..., k
            Console.WriteLine(CalculateBinomialCoefficient());
        }

        private static void Modify(long x, long how)
        {
            for (int i = 0; i < Primes.Count; i++)
            {
                if (Primes[i] == x)
                {
                    Counts[i] += how;
                    return;
                }
            }

            Counts.Add(how);
            Primes.Add(x);
        }

        private static void Solve(long start, long end, long inc)
        {
            for (long i = start; i <= end; i++)
            {
                long multiplier = i;
                long prime = 2;
                while (multiplier != 1)
                {
                    int how = 0;
                    while (multiplier % prime == 0)
                    {
                        multiplier /= prime;
                        how++;
                    }

                    if (how > 0)
                    {
                        Modify(prime, inc * how);
                    }

                    prime++;
                }
            }
        }

        private static long CalculateBinomialCoefficient()
        {
            long result = 1;
            for (int i = 0; i < Primes.Count; i++)
            {
                for (long j = 0; j < Counts[i]; j++)
                {
                    result *= Primes[i];
                }
            }

            return result;
        }
    }
}
