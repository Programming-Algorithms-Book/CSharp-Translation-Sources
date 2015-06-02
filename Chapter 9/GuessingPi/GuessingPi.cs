using System;

class Program
{
    static void Main()
    {
        long t = 1000000;     /* брой тестове */
        int d = 10000;        /* диаметър на окръжността */
        double r = d / 2;
        long k = 0;
        var rand = new Random(0);
        
        for (int i = 0; i < t; i++)
        {
            int a = (int)(rand.Next(d) - r + 1);
            int b = (int)(rand.Next(d) - r + 1);
            if (Math.Sqrt(a * a + b * b) <= r) k++;
        }

        Console.WriteLine("Приближение на pi = {0:F10}", (4.0 * k) / t);
    }
}