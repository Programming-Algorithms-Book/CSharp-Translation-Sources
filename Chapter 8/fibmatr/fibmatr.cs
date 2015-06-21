namespace Fibmatr
{
    using System;

    public class Fibmatr
    {
        private const int N = 10;

        private static readonly int[,] MatrE = new int[,] { { 1, 1 }, { 1, 0 } }; /* Изходна матрица */
        private static readonly int[,] Matrix = new int[2, 2]; /* Резултатна матрица */
        private static readonly int[,] HelpMatrix = new int[2, 2]; /* Помощна матрица */

        private static int sq12; /* Помощна променлива */

        internal static void Main()
        {
            FibMatr(N - 1, Matrix);
            Console.WriteLine("{0}-тото число на Фибоначи е: {1}", N, Matrix[0, 0]);
        }

        private static void FibMatr(int n, int[,] matr)
        {
            if (n < 2)
            {
                for (int row = 0; row < MatrE.GetLength(0); row++)
                {
                    for (int col = 0; col < MatrE.GetLength(1); col++)
                    {
                        matr[row, col] = MatrE[row, col];
                    }
                }
            }
            else if (0 == n % 2)
            {
                FibMatr(n / 2, HelpMatrix);
                sq12 = (int)Math.Pow(HelpMatrix[0, 1], 2);
                matr[0, 0] = (int)Math.Pow(HelpMatrix[0, 0], 2) + sq12;
                matr[1, 1] = (int)Math.Pow(HelpMatrix[1, 1], 2) + sq12;
                matr[0, 1] = matr[0, 0] - matr[1, 1];
                matr[1, 0] = matr[0, 1];
            }
            else
            {
                FibMatr(n - 1, HelpMatrix);
                matr[1, 1] = HelpMatrix[0, 1];
                matr[0, 1] = HelpMatrix[0, 0];
                matr[0, 0] = HelpMatrix[0, 0] + HelpMatrix[1, 0];
                matr[1, 0] = HelpMatrix[0, 1];
            }
        }
    }
}