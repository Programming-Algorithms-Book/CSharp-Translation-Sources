namespace SequencePrint2
{
    using System;

    public class SequencePrint2
    {
        private const uint N = 5;

        private static uint k = 0;

        internal static void Main()
        {
            PrintSequence(10);
            Console.WriteLine();
        }

        private static void PrintSequence(ulong result)
        {
            k++;
            Console.Write("{0} ", result);
            if (k < N)
            {
                PrintSequence(result * 10);
            }

            Console.Write("{0} ", result);
        }
    }
}
