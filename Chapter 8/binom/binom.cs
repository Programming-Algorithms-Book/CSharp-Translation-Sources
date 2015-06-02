using System;

class binom
{
    static int CalculateBinom(int n, int k)
    {
        if (k > n) 
            return 0;
        else if (k == 0 || k == n) 
            return 1;
        else
            return CalculateBinom(n - 1, k - 1) + CalculateBinom(n - 1, k);
    }

    static void Main()
    {
        Console.WriteLine(CalculateBinom(7, 3));
    }
}
