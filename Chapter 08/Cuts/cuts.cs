namespace Cuts
{
    using System;

    internal class Cuts
    {
        private const int MaxSize = 100;
        private const int NotCalculated = -1;

        private static readonly Element[,] F = new Element[MaxSize, MaxSize];
        private static int sizeX, sizeY; /* Размерност на парчето */

        private static void Init()
        {
            int x, y;
            /* Входни данни */
            sizeX = 13;
            sizeY = 9;

            /* Инициализация */
            for (x = 1; x <= sizeX; x++)
            {
                for (y = 1; y <= sizeY; y++)
                {
                    F[x, y].Value = NotCalculated;
                    F[x, y].Action = 0;
                }
            }

            /* Входни данни */
            F[11, 1].Value = 28;
            F[5, 3].Value = 31;
            F[1, 2].Value = 4;
            F[2, 1].Value = 2;
            F[3, 1].Value = 7;
            F[10, 1].Value = 23;
            F[3, 2].Value = 14;
            F[3, 3].Value = 17;
            F[5, 4].Value = 41;
            F[5, 7].Value = 96;
        }

        private static int Solve(int x, int y)
        {
            int bestAction = 0;
            int i, bestSolution, x2 = x / 2, y2 = y / 2;
            if (F[x, y].Value != NotCalculated)
            {
                return F[x, y].Value; /* Вече е пресмятана */
            }

            bestSolution = 0;
            if (x > 1)
            {
                /* Срязваме го хоризонтално и викаме рекурсия за двете части */
                for (i = 1; i <= x2; i++)
                {
                    if (Solve(i, y) + Solve(x - i, y) > bestSolution)
                    {
                        bestSolution = Solve(i, y) + Solve(x - i, y);
                        bestAction = i;
                    }
                }
            }

            if (y > 1)
            {
                /* Срязваме го вертикално и викаме рекурсия за двете части */
                for (i = 1; i <= y2; i++)
                {
                    if (Solve(x, i) + Solve(x, y - i) > bestSolution)
                    {
                        bestSolution = Solve(x, i) + Solve(x, y - i);
                        bestAction = -i;
                    }
                }
            }

            F[x, y].Value = bestSolution;
            F[x, y].Action = bestAction;
            return bestSolution;
        }

        private static void PrintSolution(int x, int y)
        {
            if (x > 0 && y > 0 && F[x, y].Value > 0)
            {
                if (F[x, y].Action > 0)
                {
                    PrintSolution(F[x, y].Action, y);
                    PrintSolution(x - F[x, y].Action, y);
                }
                else if (F[x, y].Action < 0)
                {
                    PrintSolution(x, -F[x, y].Action);
                    PrintSolution(x, y - (-F[x, y].Action));
                }
                else
                {
                    Console.Write("({0},{1}) --> {2}  ", x, y, F[x, y].Value);
                }
            }
        }

        private static void Main()
        {
            Init();
            Console.WriteLine("Максимална цена {0}", Solve(sizeX, sizeY));
            Console.WriteLine("Размери (X,Y)-->Цена");
            PrintSolution(sizeX, sizeY);
            Console.WriteLine();
        }
    }
}