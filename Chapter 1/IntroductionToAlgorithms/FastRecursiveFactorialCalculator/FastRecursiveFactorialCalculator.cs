using System;

class FastRecursiveFactorialCalculator
{
    const uint n = 6;
    static uint i = 0;

    static ulong GetFactorial()
    {
        if (i == 1) return 1;
        return --i * GetFactorial();
    }

    static void Main()
    {
        i = n + 1;
        Console.WriteLine("{0}! = {1}", n, GetFactorial());
    }
}
