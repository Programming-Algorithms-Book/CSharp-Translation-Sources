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
                Console.Write("{0:F6} ", PDynamic3(i, j));
            Console.WriteLine();
        }
    }
    
    static double PDynamic3(int i, int j)
    {
        double[,] P = new double[2*n-1, 2*n-1];
        for (int s = 1; s <= i + j; s++)
        {
            P[0, s] = 1.0;
            P[s, 0] = 0.0;
            for (int k = 1; k <= s - 1; k++)
                P[k, s - k] = p * P[k - 1, s - k] + (1 - p) * P[k, s - k - 1];
        }
        return P[i, j];
    }
}
