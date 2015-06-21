namespace PrimeFactorization
{
    using System;

    public class PrimeFactorization
    {
        // Число, което ще се разлага
        private static uint n = 435; 

        internal static void Main()
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
}
