using System;

class RecursiveFactorialCalculator
{
    const uint n = 6;

    static ulong GetFactorial(uint i)
    {
        if (i < 2) return i;
        return i * GetFactorial(i - 1);
    }

    static void Main()
    {
        Console.WriteLine("{0}! = {1}", n, GetFactorial(n));
    }
}
