using System;

class SumOfMatrices
{
    static void Main()
    {
        int[,] A = { { 3, 52, 1, 2 }, { -3, 2, 11, 6 }, { 7, 8, 2, 9 } };
        int[,] B = { { -5, 2, 7, 6 }, { 3, 5, 71, 2 }, { 7, 3, 11, 2 } };
        
        int[,] sum = GetSum(A, B);
        PrintMatrix(sum);
    }

    static int[,] GetSum(int[,] A, int[,] B)
    {
        int[,] sum = new int[A.GetLength(0), A.GetLength(1)];
        for (int row = 0; row < sum.GetLength(0); row++)
            for (int col = 0; col < sum.GetLength(1); col++)
                sum[row, col] = A[row, col] + B[row, col];
        return sum;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
                Console.Write("{0, 3} ", matrix[row, col]);
            Console.WriteLine();
        }
    }
}
