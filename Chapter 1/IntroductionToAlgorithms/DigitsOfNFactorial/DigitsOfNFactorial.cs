using System;

class DigitsOfNFactorial
{
    const uint n = 123;

    static void Main()
    {
        double digitsCount = 0;
        for (int i = 1; i <= n; i++)
            digitsCount += Math.Log(i, 10);
        Console.WriteLine("Броят на цифрите на {0}! е {1}", n, (ulong)digitsCount + 1);
    }
}