using System;

class SequencePrint1
{
    const uint n = 5;

    static void PrintSequence(uint k, ulong result)
    {
        Console.Write("{0} ", result);
        if (k < n) PrintSequence(k + 1, result * 10);
        Console.Write("{0} ", result);
    }

    static void Main()
    {
        PrintSequence(1, 10);
        Console.WriteLine();
    }
}
