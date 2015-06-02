using System;

class SequencePrint2
{
    const uint n = 5;

    static uint k = 0;

    static void PrintSequence(ulong result)
    {
        k++;
        Console.Write("{0} ", result);
        if (k < n) PrintSequence(result * 10);
        Console.Write("{0} ", result);
    }

    static void Main()
    {
        PrintSequence(10);
        Console.WriteLine();
    }
}
