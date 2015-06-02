using System;

class PrimeNumbersFinder
{
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
        if (number == 2) return true;
        uint divider = 2;
        while (divider <= Math.Sqrt(number))
        {
            if (number % divider == 0) return false;
            divider++;
        }

        return true;
    }
}
