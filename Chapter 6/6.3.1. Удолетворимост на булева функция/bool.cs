using System;

class Program
{
    const int MAXN = 100; /* Максимален брой булеви променливи */
    const int MAXK = 100; /* Максимален брой дизюнкти */

    const uint n = 4;  /* Брой на булевите променливи */
    const uint k = 5;  /* Брой на дизюнктите */

    static int[][] expr = new int[][]
    {
        new int[] { 1, 4, 0 },
        new int[] { -1, 2, 0 },
        new int[] { 1, -3, 0 },
        new int[] { -2, 3, -4, 0 },
        new int[] { -1, -2, -3, 0 }
    };    

    static int[] values = new int[MAXN];

    static void PrintAssignment()
    {
        uint i;
        Console.Write("Изразът е удовлетворим за: ");
        for (i = 0; i < n; i++)
            Console.Write("X{0}={1} ", i + 1, values[i]);
        Console.WriteLine();
    }

    /* поне един литерал трябва да има стойност “истина” във всеки дизюнкт */
    static int True()
    {
        uint i;
        for (i = 0; i < k; i++)
        {
            uint j = 0;
            int ok = 0;
            while (expr[i][j] != 0)
            {
                int p = expr[i][j];
                if ((p > 0) && (1 == values[p - 1]))
                {
                    ok = 1;
                    break;
                }
                if ((p < 0) && (0 == values[-p - 1]))
                {
                    ok = 1;
                    break;
                }
                j++;
            }
            if (ok == 0)
                return 0;
        }
        return 1;
    }

    /* присвоява стойности на променливите */
    static void Assign(uint i)
    {
        if (i == n)
        {
            if (True() == 1)
                PrintAssignment();
            return;
        }
        values[i] = 1;
        Assign(i + 1);
        values[i] = 0;
        Assign(i + 1);
    }

    static void Main(string[] args)
    {
        Assign(0);
    }
}