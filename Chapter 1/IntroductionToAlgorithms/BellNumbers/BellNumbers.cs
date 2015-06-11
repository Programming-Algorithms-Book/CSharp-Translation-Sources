namespace BellNumbers
{
    using System;

    public class BellNumbers
    {
        private const int MaxN = 100;
        private const ulong N = 10;

        private static ulong[] m = new ulong[MaxN + 1];

        internal static void Main()
        {
            Stirling(N);
            Console.WriteLine("Bell({0}) = {1}", N, Bell(N));
        }

        private static void Stirling(ulong n)
        {
            if (n == 0)
            {
                m[0] = 1;
            }
            else
            {
                m[0] = 0;
            }

            for (ulong i = 1; i <= n; i++)
            {
                m[i] = 1;

                for (ulong j = i - 1; j >= 1; j--)
                {
                    m[j] = (j * m[j]) + m[j - 1];
                }
            }
        }

        private static ulong Bell(ulong n)
        {
            ulong result = 0;
            for (ulong i = 0; i <= n; i++)
            {
                result += m[i];
            }

            return result;
        }
    }
}