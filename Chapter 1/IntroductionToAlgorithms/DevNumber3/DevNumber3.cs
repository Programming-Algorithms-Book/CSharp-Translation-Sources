using System;

class DevNumber3
{
    const int MaxAdds = 100;
    const int N = 15; // Сума, която ще разбиваме
    const int GivenCount = 3; // Брой различни стойности на монетите

    static int[] given = new int[GivenCount] { 2, 3, 5 }; // Стойности на монетите
    static int[] mp = new int[MaxAdds];

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
        int k;
        for (int p = GivenCount; p > 0; p--)
        {
            k = given[p - 1];
            if (n > k)
            {
                mp[pos] = k;

                if (mp[pos] <= mp[pos - 1])
                {
                    DevNum(n - k, pos + 1);
                }
            }
            else if (n == k)
            {
                mp[pos] = k;

                if (mp[pos] <= mp[pos - 1])
                {
                    Print(pos);
                }
            }
        }
    }

    static void Main()
    {
        mp[0] = N + 1;
        DevNum(N, 1);
    }
}
