namespace MinimalDominatingSets
{
    using System;

    public class MinimalDominatingSets
    {
        private const int VerticesCount = 6;

        private static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
        {
            { 0, 1, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0, 1 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0 }
        };

        private static readonly int[] Cover = new int[VerticesCount];
        private static readonly bool[] T = new bool[VerticesCount];

        internal static void Main()
        {
            Console.WriteLine("Минималните доминиращи множества в графа са:");
            FindMinDominatingSets(0);
        }

        private static void PrintSet()
        {
            Console.Write("{ ");
            for (int i = 0; i < VerticesCount; i++)
            {
                if (T[i])
                {
                    Console.Write("{0} ", i + 1);
                }
            }

            Console.WriteLine("}");
        }

        private static bool Ok()
        {
            for (int i = 0; i < VerticesCount; i++)
            {
                if (T[i])
                {
                    // Проверка дали покритието се запазва при премахване на върха i
                    if (Cover[i] == 0)
                    {
                        continue;
                    }

                    int j = 0;
                    for (; j < VerticesCount; j++)
                    {
                        if (Cover[j] != 0 && Cover[j] - Graph[i, j] == 0 && !T[j])
                        {
                            break; // Остава непокрит връх
                        }
                    }

                    if (j == VerticesCount)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void FindMinDominatingSets(int last)
        {
            // Проверява се дали е намерено решение
            int i = 0;
            for (; i < VerticesCount; i++)
            {
                if (Cover[i] == 0 && !T[i])
                {
                    break;
                }
            }

            if (i == VerticesCount)
            {
                PrintSet();
                return;
            }

            // Не - продължаваме да конструираме доминиращото множество
            for (i = last; i < VerticesCount; i++)
            {
                T[i] = true;
                for (int j = 0; j < VerticesCount; j++)
                {
                    if (Graph[i, j] == 1)
                    {
                        Cover[j]++;
                    }
                }

                if (Ok())
                {
                    FindMinDominatingSets(i + 1);
                }

                for (int j = 0; j < VerticesCount; j++)
                {
                    if (Graph[i, j] == 1)
                    {
                        Cover[j]--;
                    }
                }

                T[i] = false;
            }
        }
    }
}