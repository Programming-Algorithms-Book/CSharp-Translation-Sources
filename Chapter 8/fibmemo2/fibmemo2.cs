using System;

class fibmemo2
{
    const int Max = 250;
    const int N = 10;

    static int[] memo = new int[Max + 1];

    /* Бърз рекурсивен логаритмичен вариант, запаметяващ вече изчисленото */
    static int FibMemo(int n)
    {
        if (n < 2)
            memo[n] = 1;
        else if (memo[n] == 0)
            if (n % 2 == 1)
                memo[n] = FibMemo(n - 1) + FibMemo(n - 2);
            else
                memo[n] = GetSquare(FibMemo(n / 2)) + GetSquare(FibMemo(n / 2 - 1));

        return memo[n];
    }

    static int GetSquare(int num)
    {
        int square = (int)Math.Pow(num, 2);
        return square;
    }

    static void Main()
    {
        Console.WriteLine("{0}-тото число на Фибоначи е: {1}", N, FibMemo(N - 1));
    }
}
