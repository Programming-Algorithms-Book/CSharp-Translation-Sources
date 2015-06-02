using System;

class IterativeFibonacci
{
    const uint n = 7;

    // Пресмята n-тото число на Фибоначи, използвайки три променливи
    static ulong GetFibonacciNumber1(uint n)
    {
        ulong fn = 1, fn1 = 0, fn2 = 0;
        while (n-- > 0)
        {
            fn2 = fn1;
            fn1 = fn;
            fn = fn1 + fn2;
        }

        return fn1;
    }

    // Пресмята n-тото число на Фибоначи, използвайки две променливи
    static ulong GetFibonacciNumber2(uint n)
    {
        ulong f1 = 0, f2 = 1;
        while (n-- > 0)
        {
            f2 = f1 + f2;
            f1 = f2 - f1;
        }

        return f1;
    }

    static void Main()
    {
        Console.WriteLine("Fibonacci({0}) = {1}", n, GetFibonacciNumber2(n));
    }
}
