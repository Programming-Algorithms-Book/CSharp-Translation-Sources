namespace SequencePrint3
{
    using System;

    public class SequencePrint3
    {
        private const uint N = 5;

        private static uint k = 0;
        private static ulong result = 1;

        internal static void Main()
        {
            PrintSequence();
            Console.WriteLine();
        }

        private static void PrintSequence()
        {
            k++; 
            result *= 10;

            Console.Write("{0} ", result);
            if (k < N)
            {
                PrintSequence();
            }

            Console.Write("{0} ", result);
            result /= 10;
        }
    }
}
