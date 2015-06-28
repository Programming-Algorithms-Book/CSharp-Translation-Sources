namespace KnightsTour
{
    using System;

    public class Program
    {
        private const int MaxMoves = 8;
        private const int N = 12;

        private static readonly int[] MoveX = { +1, -1, +1, -1, +2, +2, -2, -2 };
        private static readonly int[] MoveY = { +2, +2, -2, -2, +1, -1, +1, -1 };

        internal static void Main()
        {
            Solve();
        }

        private static void Solve()
        {
            /* инициализация */
            int[,] a = new int[12, 12];
            a[0, 0] = 1;
            int x = 0;
            int y = 0;
            int p = 1;

            /* повтаря "алчната" стъпка, докато попълни цялата дъска */
            while (p < 12 * 12)
            {
                int min = int.MaxValue;
                int choose = -1;
                for (int i = 0; i < MaxMoves; i++)
                {
                    int temp = CountMoves(a, x + MoveX[i], y + MoveY[i]);
                    if (temp < min)
                    {
                        min = temp;
                        choose = i;
                    }
                }

                x += MoveX[choose];
                y += MoveY[choose];
                a[x, y] = ++p;
            }

            /* отпечатва резултата */
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0, 4}", a[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static int CountMoves(int[,] a, int x, int y)
        {
            int i, number = 0;
            if (x < 0 || y < 0 || x >= N || y >= N || a[x, y] != 0)
            {
                return int.MaxValue; /* невалиден ход */
            }

            for (i = 0; i < MaxMoves; i++)
            {
                int nx = x + MoveX[i], ny = y + MoveY[i];
                if (nx >= 0 && ny >= 0 && nx < N && ny < N && a[nx, ny] == 0)
                {
                    number++;
                }
            }

            return number;
        }
    }
}