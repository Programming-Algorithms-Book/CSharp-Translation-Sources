using System;

class fibmemo
{
    const int Max = 256;
    const int N = 10;

    static int[] memo = new int[Max + 1];

    static int FibMemo(int n)
    {
        if (n < 2)
            memo[n] = n;
        else if (0 == memo[n])
            memo[n] = FibMemo(n - 1) + FibMemo(n - 2);
        return memo[n];
    }

    static void Main()
    {
        Console.WriteLine("{0}-тото число на Фибоначи е: {1}", N, FibMemo(N));
    }
}
