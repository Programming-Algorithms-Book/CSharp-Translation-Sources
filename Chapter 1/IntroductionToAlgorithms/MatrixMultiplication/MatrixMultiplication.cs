using System;

class MatrixMultiplication
{
    static void Main()
    {
        int[,] A = { { 3, 52, 1, 2 }, { -3, 2, 11, 6 }, { 7, 8, 2, 9 } };
        int[,] B = { { -5, 2, 7, 6 }, { 3, 5, 7, 2 }, { 7, 3, 11, 2 }, { 2, 55, -6, 83 } };

        int[,] product = GetProduct(A, B);
        PrintMatrix(product);
    }

    static int[,] GetProduct(int[,] A, int[,] B)
    {
        int[,] product = new int[A.GetLength(0), B.GetLength(1)];
        for (int row = 0; row < product.GetLength(0); row++)
            for (int col = 0; col < product.GetLength(1); col++)
                for (int i = 0; i < A.GetLength(1); i++)
                    product[row, col] += A[row, i] * B[i, col];
        return product;
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
