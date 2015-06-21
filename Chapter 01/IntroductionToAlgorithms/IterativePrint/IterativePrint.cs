namespace IterativePrint
{
    using System;
    using System.Collections.Generic;

    public class IterativePrint
    {
        private const uint N = 7892;

        internal static void Main()
        {
            Stack<uint> digits = new Stack<uint>();
            uint number = N;
            while (number > 0)
            {
                digits.Push(number % 10);
                number /= 10;
            }

            while (digits.Count > 0)
            {
                Console.Write(digits.Pop());
            }

            Console.WriteLine();
        }
    }
}
