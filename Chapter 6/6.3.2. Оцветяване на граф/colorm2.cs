using System;
using System.Collections.Generic;

class Program
{
    /* Максимален брой върхове в графа */ 
    const int MAXN = 200 ;
 
    /* Брой върхове в графа */ 
    const uint n = 5; 
    /* Матрица на съседство на графа */ 
    static int[,] A =
    {
        { 0, 1, 0, 0, 1 },
        { 1, 0, 1, 1, 1 },
        { 0, 1, 0, 1, 0 },
        { 0, 1, 1, 0, 1 },
        { 1, 1, 0, 1, 0 }
    }; 
 
    static uint maxCol, count = 0; 
    static uint[] col = new uint[MAXN];
    int foundSol = 0; 
 
    static void ShowSol() 
    {
        uint i; 
        count++; 
        Console.WriteLine("Минимално оцветяване на графа: "); 
        for (i = 0; i < n; i++) 
            Console.WriteLine("Връх {0} - с цвят {1} ", i + 1, col[i]); 
    }
 
    static void NextCol(uint i) 
    {
        uint k, j, success; 
 
        if (i == n)
        {
            ShowSol();
            return;
        }
        for (k = 1; k <= maxCol; k++)
        { 
            col[i] = k; 
            success = 1; 
            for (j = 0; j < n; j++) 
                if (1 == A[i,j] && col[j] == col[i])
                { 
                    success = 0; 
                    break; 
                }
            if (success == 1)
                NextCol(i + 1); 
            col[i] = 0; 
        }
    }
    
    static void Main(string[] args)
    {
        uint i; 
        for (maxCol = 1; maxCol <= n; maxCol++)
        { 
            for (i = 0; i < n; i++)
                col[i] = 0; 
            NextCol(0); 
            if (count > 0)
                break; 
        }
        Console.WriteLine("Общ брой намерени оцветявания с {0} цвята: {1} \n", maxCol, count); 
    }
}