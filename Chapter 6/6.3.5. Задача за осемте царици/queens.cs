using System;

class queens
{
    /* Максимален размер на дъската */
    const int MAXN = 100;

    /* Размер на дъската */
    const uint n = 13;

    static uint[] col = new uint[MAXN], 
        RD = new uint[2*MAXN - 1],
        LD = new uint[2*MAXN], 
        queens = new uint[MAXN];

    /* Отпечатва намереното разположение на цариците */
    static void PrintBoard()
    {
        uint i , j ;
        for (i = 0; i < n; i++)
        {
            Console.WriteLine();
            for (j = 0; j < n; j++)
                if (queens[i] == j)
                    Console.Write("x ");
                else
                    Console.Write(". ");
        }
        Console.WriteLine();
        Environment.Exit(0);
    }

    /* Намира следваща позиция за поставяне на царица */
    static void Generate(uint i)
    {
        if (i == n)
            PrintBoard();
        uint k;    
        for (k = 0; k <= n; k++)
        {
            if (col[k]!=0 && RD[i + k]!=0 && LD[n + i - k]!=0)
            {
                col[k] = 0;
                RD[i + k] = 0;
                LD[n + i - k] = 0;
                queens[i] = k;
                Generate(i + 1);
                col[k] = 1;
                RD[i + k] = 1;
                LD[n + i - k] = 1;
            }
        }
    }

    static void Main(string[] args)
    {
        uint i;
        for (i = 0; i < n; i++)
            col[i] = 1;
        for (i = 0; i < (2 * n - 1); i++)
            RD[i] = 1;
        for (i = 0; i < 2 * n; i++)
            LD[i] = 1;
        Generate(0);
        Console.WriteLine("Задачата няма решение!");
    }
}