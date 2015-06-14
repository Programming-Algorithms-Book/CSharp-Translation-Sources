using System;

internal class Program
{
    private static int n = 10; /* Брой фенове */

    private static int[] F = new int[n + 1]; /* Целева функция */

    private static int[] T = { 8, 5, 3, 9, 2, 1, 4, 4, 1, 17 }; /* Време за обслужване на един фен */
    private static int[] R = { 1, 3, 9, 4, 2, 4, 9, 3, 8 }; /* Време за обслужване на двойка фенове */

    private static void Main()
    {
        Solve();
        Print();
    }

    /* Пресмята стойностите на целевата функция */

    private static void Solve()
    {
        F[0] = 0;
        F[1] = T[0];
        for (int i = 2; i <= n; i++)
        {
            F[i] = Math.Min(F[i - 1] + T[i - 1], F[i - 2] + R[i - 2]);
        }
    }

    /* Извежда решението на екрана */

    private static void Print()
    {
        Console.WriteLine("Минимално време за обслужване на опашката: {0}", F[n]);
        do
        {
            if (F[n - 1] + T[n - 1] == F[n])
            {
                Console.WriteLine("{0}", n--);
            }
            else
            {
                Console.WriteLine("({0}, {1})", n - 1, n);
                n -= 2;
            }
        }
        while (n > 0);
    }
}