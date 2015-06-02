using System;

class fibmatr
{
    const int N = 10;

    static int[,] matrE = new int[,] { { 1, 1 }, { 1, 0 } };    /* Изходна матрица */
    static int[,] matrix = new int[2, 2];   /* Резултатна матрица */
    static int[,] helpMatrix = new int[2, 2];  /* Помощна матрица */

    static int sq12; /* Помощна променлива */

    static void FibMatr(int n, int[,] matr)
    {

        if (n < 2)
        {
            for (int row = 0; row < matrE.GetLength(0); row++)
                for (int col = 0; col < matrE.GetLength(1); col++)
                    matr[row, col] = matrE[row, col];
        }
        else if (0 == n % 2)
        {
            FibMatr(n / 2, helpMatrix);
            sq12 = (int)Math.Pow(helpMatrix[0, 1], 2);
            matr[0, 0] = (int)Math.Pow(helpMatrix[0, 0], 2) + sq12;
            matr[1, 1] = (int)Math.Pow(helpMatrix[1, 1], 2) + sq12;
            matr[0, 1] = matr[0, 0] - matr[1, 1];
            matr[1, 0] = matr[0, 1];
        }
        else
        {
            FibMatr(n - 1, helpMatrix);
            matr[1, 1] = helpMatrix[0, 1];
            matr[0, 1] = helpMatrix[0, 0];
            matr[0, 0] = helpMatrix[0, 0] + helpMatrix[1, 0];
            matr[1, 0] = helpMatrix[0, 1];
        }
    }

    static void Main()
    {
        FibMatr(N - 1, matrix);
        Console.WriteLine("{0}-тото число на Фибоначи е: {1}", N, matrix[0, 0]);
    }
}
