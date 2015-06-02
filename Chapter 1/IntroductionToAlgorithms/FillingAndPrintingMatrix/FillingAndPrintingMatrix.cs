using System;

class FillingAndPrintingMatrix
{
    static void Main()
    {
        int[,] A = new int[5, 4];
        FillMatrixByRows(A);
        PrintMatrix(A);

        int[,] B = new int[5, 4];
        FillMatrixByColumns(B);
        PrintMatrix(B);
    }

    static void FillMatrixByRows(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("Въведи число на ред {0} колона {1}: ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
    }

    static void FillMatrixByColumns(int[,] matrix)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("Въведи число на ред {0} колона {1}: ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
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
