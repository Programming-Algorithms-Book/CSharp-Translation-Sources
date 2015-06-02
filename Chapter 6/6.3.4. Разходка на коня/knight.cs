using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    /* Максимален размер на дъската */
    const int MAXN = 10;
    /* Максимален брой правила за движение на коня */
    const int MAXD = 10;

    /* Размер на дъската */
    const uint n = 6;
    /* Стартова позиция */
    const uint startX = 1;
    const uint startY = 1;
    /* Правила за движение на коня */
    const uint maxDiff = 8;
    static int[] diffX = { 1, 1, -1, -1, 2, -2, 2, -2 };
    static int[] diffY = { 2, -2, 2, -2, 1, 1, -1, -1 };

    static uint[,] board = new uint[MAXN, MAXN];
    static uint newX, newY;

    static void printBoard()
    {
        uint i, j;
        for (i = n; i > 0; i--)
        {
            for (j = 0; j < n; j++)
                Console.Write("{0,3}", board[i - 1,j]);
            Console.WriteLine();
        }
        Environment.Exit(0);  /* изход от програмата */
    }

    static void NextMove(uint X, uint Y, uint i)
    {
        uint k;
        board[X,Y] = i;
        if (i == n * n)
        {
            printBoard();
            return;
        }
        for (k = 0; k < maxDiff; k++)
        {
            newX =(uint)(X + diffX[k]);
            newY = (uint)(Y + diffY[k]);
            if ((newX >= 0 && newX < n && newY >= 0 && newY < n) && (0 == board[newX,newY]))
                NextMove(newX, newY, i + 1);
        }
        board[X,Y] = 0;
    }

    static void Main(string[] args)
    {
        uint i, j;
        for (i = 0; i < n; i++)
            for (j = 0; j < n; j++)
                board[i,j] = 0;
        NextMove(startX - 1, startY - 1, 1);
        Console.WriteLine("Задачата няма решение.");
    }
}