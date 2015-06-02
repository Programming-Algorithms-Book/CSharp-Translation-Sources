using System;

class DevNumber1
{
    const int Number = 7;
    static int[] mp = new int[Number + 1];

    static void Print(int length)
    {
        for (int i = 1; i < length; i++)
        {
            Console.Write("{0} + ", mp[i]);
        }

        Console.WriteLine("{0}", mp[length]);
    }

    static void DevNum(int n, int pos)
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

    static void Main()
    {
        mp[0] = Number + 1;
        DevNum(Number, 1);
    }
}