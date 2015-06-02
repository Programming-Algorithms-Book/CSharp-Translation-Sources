using System;

class PrimeFactorization
{
    static uint n = 435; // Число, което ще се разлага

    static void Main()
    {
        Console.Write("{0} = ", n);
        uint i = 1;
        while (n != 1)
        {
            i++;
            uint how = 0;
            while (n % i == 0)
            {
                how++;
                n /= i;
            }

            for (int j = 0; j < how; j++)
            {
                Console.Write("{0} ", i);
            }
        }

        Console.WriteLine();
    }
}
