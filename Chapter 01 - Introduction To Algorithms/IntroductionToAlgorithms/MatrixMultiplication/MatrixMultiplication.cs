namespace MatrixMultiplication
{
    using System;

    public class MatrixMultiplication
    {
        internal static void Main()
        {
            int[,] a = { { 3, 52, 1, 2 }, { -3, 2, 11, 6 }, { 7, 8, 2, 9 } };
            int[,] b = { { -5, 2, 7, 6 }, { 3, 5, 7, 2 }, { 7, 3, 11, 2 }, { 2, 55, -6, 83 } };

            int[,] product = GetProduct(a, b);
            PrintMatrix(product);
        }

        private static int[,] GetProduct(int[,] a, int[,] b)
        {
            int[,] product = new int[a.GetLength(0), b.GetLength(1)];
            for (int row = 0; row < product.GetLength(0); row++)
            {
                for (int col = 0; col < product.GetLength(1); col++)
                {
                    for (int i = 0; i < a.GetLength(1); i++)
                    {
                        product[row, col] += a[row, i] * b[i, col];
                    }
                }
            }

            return product;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 3} ", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
