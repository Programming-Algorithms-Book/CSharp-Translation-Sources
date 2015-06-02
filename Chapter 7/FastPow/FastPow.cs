using System;

namespace FastPow
{
    class FastPow
    {
        private const double BaseNumber = 3.14;
        private const int Power = 11;

        static double FastPower(double x, int n)
        {
            if (n == 0)
                return 1;
            else
            {
                if ((n & 1) == 1)
                    return x*FastPower(x, n - 1);
                else
                    return FastPower(x*x, n/2);
            }
        }

        static void Main()
        {
            Console.WriteLine("{0}^{1} = {2}", BaseNumber, Power, FastPower(BaseNumber, Power));
        }
    }
}
