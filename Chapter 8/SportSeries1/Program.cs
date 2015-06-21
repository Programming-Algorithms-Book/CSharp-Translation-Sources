namespace SportSeries1
{
    using System;

    public class Program
    {
        private const double Probability = 0.5; /* Вероятност A да спечели отделен мач */
        private const int N = 5;

        internal static void Main()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0:F6} ", P(i, j));
                }

                Console.WriteLine();
            }
        }

        /* Неефективен рекурсивен вариант */
        private static double P(int i, int j)
        {
            if (0 == j)
            {
                return 0.0;
            }
            else if (0 == i)
            {
                return 1.0;
            }
            else
            {
                return (Probability * P(i - 1, j)) + ((1 - Probability) * P(i, j - 1));
            }
        }
    }
}