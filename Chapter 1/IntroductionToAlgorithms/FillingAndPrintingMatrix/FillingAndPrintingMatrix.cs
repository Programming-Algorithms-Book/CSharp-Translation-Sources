namespace FillingAndPrintingMatrix
{
    using System;

    public class FillingAndPrintingMatrix
    {
        internal static void Main()
        {
            int[,] a = new int[5, 4];
            FillMatrixByRows(a);
            PrintMatrix(a);

            int[,] b = new int[5, 4];
            FillMatrixByColumns(b);
            PrintMatrix(b);
        }

        private static void FillMatrixByRows(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("Въведи число на ред {0} колона {1}: ", row, col);
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }
        }

        private static void FillMatrixByColumns(int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    Console.Write("Въведи число на ред {0} колона {1}: ", row, col);
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }
            }
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
