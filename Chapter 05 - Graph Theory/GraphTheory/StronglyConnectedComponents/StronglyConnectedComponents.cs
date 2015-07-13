namespace StronglyConnectedComponents
{
    using System;

    public class StronglyConnectedComponents
    {
        private const int VerticesCount = 10;

        private static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
        {
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }
        };

        private static readonly bool[] Used = new bool[VerticesCount];
        private static readonly int[] Postnum = new int[VerticesCount];
        private static int traversedVertices = 0;

        internal static void Main()
        {
            Console.WriteLine("Силно свързаните компоненти в графа са:");
            FindStronglyConnectedComponents();
        }

        private static void FindStronglyConnectedComponents()
        {
            while (traversedVertices < VerticesCount - 1)
            {
                for (int i = 0; i < VerticesCount; i++)
                {
                    if (!Used[i])
                    {
                        Dfs(i);
                    }
                }
            }

            for (int i = 0; i < VerticesCount; i++)
            {
                Used[i] = false;
            }

            traversedVertices = 0;
            while (traversedVertices < VerticesCount - 1)
            {
                int max = -1;
                int maxVertex = -1;
                for (int i = 0; i < VerticesCount; i++)
                {
                    if (!Used[i] && Postnum[i] > max)
                    {
                        max = Postnum[i];
                        maxVertex = i;
                    }
                }

                Console.Write("{ ");
                BackDfs(maxVertex);
                Console.WriteLine("}");
            }
        }

        // Обхождане в дълбочина със запазване на номерацията
        private static void Dfs(int vertex)
        {
            Used[vertex] = true;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (!Used[i] && Graph[vertex, i] == 1)
                {
                    Dfs(i);
                }
            }

            Postnum[vertex] = traversedVertices++;
        }

        // Обхождане в дълбочина на графа G'
        private static void BackDfs(int vertex)
        {
            Console.Write("{0} ", vertex + 1);
            traversedVertices++;
            Used[vertex] = true;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (!Used[i] && Graph[i, vertex] == 1)
                {
                    BackDfs(i);
                }
            }
        }
    }
}