namespace SequencePrint1
{
    using System;

    public class SequencePrint1
    {
        private const uint N = 5;

        internal static void Main()
        {
            PrintSequence(1, 10);
            Console.WriteLine();
        }

        private static void PrintSequence(uint k, ulong result)
        {
            Console.Write("{0} ", result);
            if (k < N)
            {
                PrintSequence(k + 1, result * 10);
            }

            Console.Write("{0} ", result);
        }
    }
}
