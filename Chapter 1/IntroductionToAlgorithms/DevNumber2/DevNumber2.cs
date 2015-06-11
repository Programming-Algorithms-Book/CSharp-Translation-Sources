namespace DevNumber2
{
    using System;

    public class DevNumber2
    {
        private const int MaxLn = 20; // Множители: най-много log2n (минималният е 2)
        private const int Number = 50; // Число, което ще разбиваме

        private static int[] mp = new int[MaxLn];

        internal static void Main()
        {
            mp[0] = Number + 1;
            DevNum(Number, 1);
        }

        private static void Print(int length)
        {
            for (int i = 1; i < length; i++)
            {
                Console.Write("{0} * ", mp[i]);
            }

            Console.WriteLine("{0}", mp[length]);
        }

        private static void DevNum(int n, int pos)
        {
            if (n == 1)
            {
                Print(pos - 1);
            }
            else
            {
                for (int k = n; k > 1; k--)
                {
                    mp[pos] = k;
                    if ((mp[pos] <= mp[pos - 1]) && (n % k == 0))
                    {
                        DevNum(n / k, pos + 1);
                    }
                }
            }
        }
    }
}