using System;

class RecursiveFibonacci
{
    const uint n = 7;

    static ulong GetFibonacciNumber(uint n)
    {
        if (n < 2) return n;
        return GetFibonacciNumber(n - 1) + GetFibonacciNumber(n - 2);
    }

    static void Main()
    {
        Console.WriteLine("Fibonacci({0}) = {1}", n, GetFibonacciNumber(n));
    }
}
