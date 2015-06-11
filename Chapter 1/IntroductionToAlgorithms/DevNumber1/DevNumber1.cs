namespace DevNumber1
{
    using System;

    public class DevNumber1
    {
        private const int Number = 7;
        private static int[] mp = new int[Number + 1];

        internal static void Main()
        {
            mp[0] = Number + 1;
            DevNum(Number, 1);
        }

        private static void Print(int length)
        {
            for (int i = 1; i < length; i++)
            {
                Console.Write("{0} + ", mp[i]);
            }

            Console.WriteLine("{0}", mp[length]);
        }

        private static void DevNum(int n, int pos)
        {
            if (n == 0)
            {
                Print(pos - 1);
            }
            else
            {
                for (int k = n; k >= 1; k--)
                {
                    mp[pos] = k;
                    if (mp[pos] <= mp[pos - 1])
                    {
                        DevNum(n - k, pos + 1);
                    }
                }
            }
        }
    }
}