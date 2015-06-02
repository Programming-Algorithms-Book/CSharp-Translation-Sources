using System;

class Program
{
    const double p = 0.5; /* Вероятност A да спечели отделен мач */
    const int n = 5;
    
    static void Main()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write("{0:F6} ", P(i, j));
            Console.WriteLine();
        }
    }
    
    /* Неефективен рекурсивен вариант */
    static double P(int i, int j)
    {
        if (0 == j)
            return 0.0;
        else if (0 == i)
            return 1.0;
        else
            return p * P(i - 1, j) + (1 - p) * P(i, j - 1);
    }
}
