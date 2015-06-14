namespace FloydAlgorithm
{
    using System;

    internal class FloydAlgorithm
    {
        private const int VerticesCount = 10;
        private const uint MaxValue = 1000000;

        // Матрица на теглата на графа
        private static readonly uint[,] Graph = new uint[VerticesCount, VerticesCount]
                                                {
                                                    { 0, 23, 0, 0, 0, 0, 0, 8, 0, 0 },
                                                    { 23, 0, 0, 3, 0, 0, 34, 0, 0, 0 },
                                                    { 0, 0, 0, 6, 0, 0, 0, 25, 0, 7 },
                                                    { 0, 3, 6, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 0, 10, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 10, 0, 0, 0, 0, 0 },
                                                    { 0, 34, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 8, 0, 25, 0, 0, 0, 0, 0, 0, 30 },
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 7, 0, 0, 0, 0, 30, 0, 0 }
                                                };

        // Намира дължината на минималния път между всяка двойка върхове
        private static void Floyd()
        {
            InitializeGraph();

            // Алгоритъм на Флойд
            for (int k = 0; k < VerticesCount; k++)
            {
                for (int i = 0; i < VerticesCount; i++)
                {
                    for (int j = 0; j < VerticesCount; j++)
                    {
                        if (Graph[i, j] > Graph[i, k] + Graph[k, j])
                        {
                            Graph[i, j] = Graph[i, k] + Graph[k, j];
                        }
                    }
                }
            }

            for (int i = 0; i < VerticesCount; i++)
            {
                Graph[i, i] = 0;
            }
        }

        private static void InitializeGraph()
        {
            // Стойностите 0 се променят на MaxValue
            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = 0; j < VerticesCount; j++)
                {
                    if (Graph[i, j] == 0)
                    {
                        Graph[i, j] = MaxValue;
                    }
                }
            }
        }

        private static void PrintMinimalPaths()
        {
            Console.WriteLine("Матрица на теглата след изпълнение на алгоритъма на Флойд:");
            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = 0; j < VerticesCount; j++)
                {
                    Console.Write("{0,3} ", Graph[i, j] == MaxValue ? 0 : Graph[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void Main()
        {
            Floyd();
            PrintMinimalPaths();
        }
    }
}