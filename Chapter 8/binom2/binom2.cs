using System;

internal class binom2
{
    private const int Max = 200;

    /* Динамично оптимиране */
    private static int[] array = new int[Max];

    private static int CalculateBinomDynamic(int n, int k)
    {
        int j;
        for (int i = 0; i <= n; i++)
        {
            array[i] = 1;
            if (i > 1)
            {
                if (k < i - 1)
                {
                    j = k;
                }
                else
                {
                    j = i - 1;
                }
                for (; j >= 1; j--)
                {
                    array[j] += array[j - 1];
                }
            }
        }
        return array[k];
    }

    private static void Main()
    {
        Console.WriteLine(CalculateBinomDynamic(7, 3));
    }
}