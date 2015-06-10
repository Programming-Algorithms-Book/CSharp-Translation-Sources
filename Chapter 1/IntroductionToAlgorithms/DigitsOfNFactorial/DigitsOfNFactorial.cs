namespace DigitsOfNFactorial
{
    using System;

    public class DigitsOfNFactorial
    {
        private const uint N = 123;

        internal static void Main()
        {
            double digitsCount = 0;
            for (int i = 1; i <= N; i++)
            {
                digitsCount += Math.Log(i, 10);
            }

            Console.WriteLine("Броят на цифрите на {0}! е {1}", N, (ulong)digitsCount + 1);
        }
    }
}