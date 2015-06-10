namespace PrimeNumbersFinder
{
    using System;

    public class PrimeNumbersFinder
    {
        private const uint N = 23;

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
            if (number == 2)
            {
                return true;
            }

            uint divider = 2;
            while (divider <= Math.Sqrt(number))
            {
                if (number % divider == 0)
                {
                    return false;
                }

                divider++;
            }

            return true;
        }
    }
}
