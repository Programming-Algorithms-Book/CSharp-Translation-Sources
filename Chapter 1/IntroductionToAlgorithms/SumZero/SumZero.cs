using System;

class SumZero
{
    // Брой числа в редицата
    const uint n = 8;
    // Търсена сума
    const int Sum = 0;

    // Редицата
    static readonly int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };

    static void CheckSolution()
    {
        int tempSum = 0;
        for (uint i = 0; i < n; i++) tempSum += Numbers[i];
        if (tempSum == Sum) // Намерено е решение => отпечатваме го
        {
            for (uint i = 0; i < n; i++)
                if (Numbers[i] > 0) Console.Write("+{0} ", Numbers[i]);
                else Console.Write("{0} ", Numbers[i]);
            Console.WriteLine("= {0}", tempSum);
        }
    }

    static void Variate(uint i)
    {
        if (i >= n)
        {
            CheckSolution();
            return;
        }

        Numbers[i] = Math.Abs(Numbers[i]); Variate(i + 1);
        Numbers[i] = -Math.Abs(Numbers[i]); Variate(i + 1);
    }

    static void Main()
    {
        Variate(0);
    }
}
