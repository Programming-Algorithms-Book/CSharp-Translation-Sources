using System;
using System.Collections.Generic;

class IterativePrint
{
    const uint n = 7892;

    static void Main()
    {
        Stack<uint> digits = new Stack<uint>();
        uint number = n;
        while (number > 0)
        {
            digits.Push(number % 10);
            number /= 10;
        }

        while (digits.Count > 0) Console.Write(digits.Pop());
        Console.WriteLine();
    }
}
