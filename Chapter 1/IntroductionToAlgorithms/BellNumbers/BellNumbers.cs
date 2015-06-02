using System;

class BellNumbers
{
    const int MaxN = 100;
    const ulong N = 10;

    static ulong[] M = new ulong[MaxN + 1];

    static void Stirling(ulong n)
    {
        if (n == 0)
        {
            M[0] = 1;
        }
        else
        {
            M[0] = 0;
        }

        for (ulong i = 1; i <= n; i++)
        {
            M[i] = 1;

            for (ulong j = i - 1; j >= 1; j--)
            {
                M[j] = j * M[j] + M[j - 1];
            }
        }
    }

    static ulong Bell(ulong n)
    {
        ulong result = 0;
        for (ulong i = 0; i <= n; i++)
        {
            result += M[i];
        }

        return result;
    }

    static void Main()
    {
        Stirling(N);
        Console.WriteLine("Bell({0}) = {1}", N, Bell(N));
    }
}