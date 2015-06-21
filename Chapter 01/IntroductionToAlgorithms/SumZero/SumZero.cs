namespace SumZero
{
    using System;

    public class SumZero
    {
        // Брой числа в редицата
        private const uint N = 8;

        // Търсена сума
        private const int Sum = 0;

        // Редицата
        private static readonly int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };

        internal static void Main()
        {
            Variate(0);
        }

        private static void CheckSolution()
        {
            int tempSum = 0;
            for (uint i = 0; i < N; i++)
            {
                tempSum += Numbers[i];
            }

            // Намерено е решение => отпечатваме го
            if (tempSum == Sum) 
            {
                for (uint i = 0; i < N; i++)
                {
                    if (Numbers[i] > 0)
                    {
                        Console.Write("+{0} ", Numbers[i]);
                    }
                    else
                    {
                        Console.Write("{0} ", Numbers[i]);
                    }
                }

                Console.WriteLine("= {0}", tempSum);
            }
        }

        private static void Variate(uint i)
        {
            if (i >= N)
            {
                CheckSolution();
                return;
            }

            Numbers[i] = Math.Abs(Numbers[i]); 
            Variate(i + 1);

            Numbers[i] = -Math.Abs(Numbers[i]); 
            Variate(i + 1);
        }
    }
}
