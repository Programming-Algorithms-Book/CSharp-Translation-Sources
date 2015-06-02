using System;

class DevNumber2
{
    const int MaxLn = 20; // Множители: най-много log2n (минималният е 2)
    const int Number = 50; // Число, което ще разбиваме

    static int[] mp = new int[MaxLn];

    static void Print(int length)
    {
        for (int i = 1; i < length; i++)
        {
            Console.Write("{0} * ", mp[i]);
        }

        Console.WriteLine("{0}", mp[length]);
    }

    static void DevNum(int n, int pos)
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

    static void Main()
    {
        mp[0] = Number + 1;
        DevNum(Number, 1);
    }
}