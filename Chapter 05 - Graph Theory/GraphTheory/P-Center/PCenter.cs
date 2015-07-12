namespace P_Center
{
    using System;

    public class PCenter
    {
        private const int MaxValue = 1000000;
        private const int VerticesCount = 7;
        private const int P = 3; // P-център

        // Матрица на теглата на графа
        private static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
        {
            { 0, 1, 0, 0, 2, 0, 0 },
            { 1, 0, 4, 0, 0, 0, 0 },
            { 0, 4, 0, 3, 0, 5, 0 },
            { 0, 0, 3, 0, 4, 0, 8 },
            { 2, 0, 0, 4, 0, 0, 0 },
            { 0, 0, 5, 0, 0, 0, 2 },
            { 0, 0, 0, 8, 0, 2, 0 }
        };

        private static readonly int[] Center = new int[VerticesCount];
        private static readonly int[] CenterP = new int[P];
        private static int radiusP = 0;

        internal static void Main()
        {
            Floyd();
            radiusP = MaxValue;
            GenerateCombinations(0, 0);
            PrintPCenter();
        }

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

        // Изчисляваме S за текущо генерираното подмножество
        private static void FindPCenter()
        {
            int radiusC = 0;
            for (int j = 0; j < VerticesCount; j++)
            {
                int bT = MaxValue;
                for (int i = 0; i < P; i++)
                {
                    if (Graph[Center[i], j] < bT)
                    {
                        bT = Graph[Center[i], j];
                    }
                }

                if (radiusC < bT)
                {
                    radiusC = bT;
                }
            }

            if (radiusC < radiusP)
            {
                radiusP = radiusC;
                for (int i = 0; i < P; i++)
                {
                    CenterP[i] = Center[i];
                }
            }
        }

        // Kомбинации C(n,p) – генериране на всички p-елементни подмножества на G
        private static void GenerateCombinations(int k, int last)
        {
            for (int i = last; i < VerticesCount - P + k; i++)
            {
                Center[k] = i;
                if (k == P)
                {
                    FindPCenter();
                }
                else
                {
                    GenerateCombinations(k + 1, i + 1);
                }
            }
        }

        // Печатаме p-центъра и p-радиуса
        private static void PrintPCenter()
        {
            Console.Write("{0}-центърът в графа е следното множество от върхове: ( ", P);
            for (int i = 0; i < P; i++)
            {
                Console.Write("{0} ", CenterP[i] + 1);
            }

            Console.WriteLine(")");
            Console.WriteLine("{0}-радиусът в графа е {1}", P, radiusP);
        }
    }
}