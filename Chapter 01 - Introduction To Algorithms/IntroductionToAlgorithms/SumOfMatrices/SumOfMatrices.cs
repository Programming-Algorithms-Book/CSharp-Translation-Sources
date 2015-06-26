namespace SumOfMatrices
{
    using System;

    public class SumOfMatrices
    {
        internal static void Main()
        {
            int[,] a = { { 3, 52, 1, 2 }, { -3, 2, 11, 6 }, { 7, 8, 2, 9 } };
            int[,] b = { { -5, 2, 7, 6 }, { 3, 5, 71, 2 }, { 7, 3, 11, 2 } };

            int[,] sum = GetSum(a, b);
            PrintMatrix(sum);
        }

        private static int[,] GetSum(int[,] a, int[,] b)
        {
            int[,] sum = new int[a.GetLength(0), a.GetLength(1)];

            for (int row = 0; row < sum.GetLength(0); row++)
            {
                for (int col = 0; col < sum.GetLength(1); col++)
                {
                    sum[row, col] = a[row, col] + b[row, col];
                }
            }

            return sum;
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
