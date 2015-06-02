using System;

class SequencePrint3
{
    const uint n = 5;

    static uint k = 0;
    static ulong result = 1;

    static void PrintSequence()
    {
        k++; result *= 10;
        Console.Write("{0} ", result);
        if (k < n) PrintSequence();
        Console.Write("{0} ", result);
        result /= 10;
    }

    static void Main()
    {
        PrintSequence();
        Console.WriteLine();
    }
}
