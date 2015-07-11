namespace KinightsTour
{
    using System;

    public class Program
    {
        /* Максимален размер на дъската */
        private const int MaxN = 10;
        /* Максимален брой правила за движение на коня */
        private const int MaxD = 10;

        /* Размер на дъската */
        private const uint N = 6;

        /* Стартова позиция */
        private const uint StartX = 1;
        private const uint StartY = 1;

        /* Правила за движение на коня */
        private const uint MaxDiff = 8;
        private static readonly int[] DiffX = { 1, 1, -1, -1, 2, -2, 2, -2 };
        private static readonly int[] DiffY = { 2, -2, 2, -2, 1, 1, -1, -1 };

        private static readonly uint[,] Board = new uint[MaxN, MaxN];
        private static uint newX, newY;

        internal static void Main(string[] args)
        {
            uint i, j;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    Board[i, j] = 0;
                }
            }

            NextMove(StartX - 1, StartY - 1, 1);
            Console.WriteLine("Задачата няма решение.");
        }

        private static void PrintBoard()
        {
            uint i, j;
            for (i = N; i > 0; i--)
            {
                for (j = 0; j < N; j++)
                {
                    Console.Write("{0,3}", Board[i - 1, j]);
                }

                Console.WriteLine();
            }

            Environment.Exit(0);  /* изход от програмата */
        }

        private static void NextMove(uint x, uint y, uint i)
        {
            uint k;
            Board[x, y] = i;
            if (i == N * N)
            {
                PrintBoard();
                return;
            }

            for (k = 0; k < MaxDiff; k++)
            {
                newX = (uint)(x + DiffX[k]);
                newY = (uint)(y + DiffY[k]);
                if ((newX >= 0 && newX < N && newY >= 0 && newY < N) && (0 == Board[newX, newY]))
                {
                    NextMove(newX, newY, i + 1);
                }
            }

            Board[x, y] = 0;
        }
    }
}