using System;

class Boolcut
{
    /* Максимален брой булеви променливи */ 
    const int MAXN = 100;

    /* Максимален брой дизюнкти */ 
    const int MAXK = 100;
 
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
 
    static void printAssign() 
    {       
        Console.Write("Изразът е удовлетворим за: "); 
        for (uint i = 0; i < n; i++)
            Console.Write("X{0}={1} ", i + 1, values[i]); 
        Console.Write("\n"); 
    }
 
    /* поне един литерал трябва да има стойност “истина” във всеки дизюнкт */ 
    static int True(uint t) 
    {
        for (uint i = 0; i < k; i++)
        { 
            uint j = 0; 
            bool isOk = false; 
            while (expr[i][j] != 0)
            { 
                int p = expr[i][j]; 
                if ((p > t) || (-p > t))
                {
                    isOk = true;
                    break;
                }
                if ((p > 0) && (1 == values[p - 1]))
                {
                    isOk = true;
                    break;
                }
                if ((p < 0) && (0 == values[-p - 1]))
                {
                    isOk = true;
                    break;
                }
     
                j++; 
            }
            if (isOk == false)
                return 0; 
        }
        return 1; 
    }
 
    /* присвоява стойности на променливите */ 
    static void Assign(uint i) 
    {
        if (True(i)==0)
            return; 
        if (i == n)
        { 
            printAssign(); 
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