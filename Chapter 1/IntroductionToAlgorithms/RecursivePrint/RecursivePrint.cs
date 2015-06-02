using System;

class RecursivePrint
{
    const uint n = 7892;

    static void PrintN(uint n)
    {
        if (n >= 10) PrintN(n / 10);
        Console.Write(n % 10);
    }

    static void Main()
    {
        PrintN(n);
        Console.WriteLine();
    }
}
