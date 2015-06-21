namespace Catalan
{
    using System;

    public class Catalan
    {
        private const int Max = 80;
        private const int Infinity = int.MaxValue;
        private const int N = 5;

        private static readonly double[,] Distances = new double[Max, Max];
        private static readonly double[,] M = new double[Max, Max]; /* Таблица - целева функция  */

        private static readonly Position[] Coords = new Position[]
        {
            new Position() { X = 1, Y = 1 },
            new Position() { X = 5, Y = -2 },
            new Position() { X = 10, Y = 1 },
            new Position() { X = 7, Y = 7 },
            new Position() { X = 1, Y = 7 }
        };

        internal static void Main()
        {
            CalculateDistances();
            Solve();
            PrintResult();
            Console.WriteLine("Диагонали от минималния разрез: ");
            WriteCut(1, N - 1);
        }

        private static void CalculateDistances()
        {
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    Distances[i, j] = Math.Sqrt(((Coords[i].X - Coords[j].X) *
                                                 (Coords[i].X - Coords[j].X)) +
                                                ((Coords[i].Y - Coords[j].Y) *
                                                 (Coords[i].Y - Coords[j].Y)));
                }
            }
        }

        private static void Solve()
        {
            for (int j = 1; j < N; j++)
            {
                for (int i = 1; i < N - j; i++)
                {
                    M[i, i + j] = Infinity;
                    for (int k = i; k < i + j; k++)
                    {
                        double t = M[i, k] + M[k + 1, i + j] + Distances[i - 1, k]
                                   + Distances[k, i + j] + Distances[i - 1, i + j];

                        if (t < M[i, i + j])
                        {
                            M[i, i + j] = t;
                            M[i + j, i] = k;
                        }
                    }
                }
            }
        }

        private static void PrintResult()
        {
            double p = Distances[0, N - 1]; /* Пресмятане на периметъра */
            for (int i = 0; i < N; i++)
            {
                p += Distances[i, i + 1];
            }

            Console.WriteLine("Дължината на мин. разрез е {0:F2}", (M[1, N - 1] - p) / 2);
        }

        /* Извеждане на минималния разрез на екрана */

        private static void WriteCut(int left, int right)
        {
            if (left != right)
            {
                WriteCut(left, (int)M[right, left]);
                WriteCut((int)M[right, left] + 1, right);
                if (left != 1 || right != N - 1)
                {
                    Console.WriteLine("({0}, {1}) ", left, right + 1);
                }
            }
        }
    }
}