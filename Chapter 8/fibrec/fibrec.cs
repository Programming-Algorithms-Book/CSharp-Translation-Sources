using System;

class fibrec
{
    const int N = 7;

    static int Fib(int n)
    {
        if (n < 2)
            return 1;
        else
            return Fib(n - 1) + Fib(n - 2);
    }

    static void Main()
    {
        Console.WriteLine("Fib({0}) = {1}", N, Fib(N));
    }
}
