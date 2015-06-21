namespace LongestPathProblem
{
    using System;

    public class Program
    {
        /* Максимален брой върхове в графа */
        private const int MaxN = 200;
        /* Брой върхове в графа */
        private const uint N = 6;
        /* Матрица на съседство на графа */
        private static readonly int[,] A = new int[,]
                          {
                              { 0, 10, 0, 5, 0, 0 },
                              { 0, 0, 5, 0, 0, 15 },
                              { 0, 0, 0, 10, 5, 0 },
                              { 0, 10, 0, 0, 10, 0 },
                              { 0, 5, 0, 0, 0, 0 },
                              { 0, 0, 0, 0, 0, 0 }
                          };

        private static readonly uint[] Vertex = new uint[MaxN];
        private static readonly uint[] SavePath = new uint[MaxN];
        private static readonly int[] Used = new int[MaxN];
        private static int maxLen, tempLen, si, ti;

        internal static void Main(string[] args)
        {
            uint i;
            maxLen = 0;
            tempLen = 0;
            si = 0;
            ti = 1;
            for (i = 0; i < N; i++)
            {
                Used[i] = 0;
            }

            for (i = 0; i < N; i++)
            {
                Used[i] = 1;
                Vertex[0] = i;

                AddVertex(i);
                Used[i] = 0;
            }

            Console.WriteLine("Най-дългият път е: ");
            for (i = 0; i < si; i++)
            {
                Console.Write("{0} ", SavePath[i] + 1);
            }

            Console.WriteLine("\nс обща дължина {0}", maxLen);
        }

        private static void AddVertex(uint i)
        {
            uint j, k;
            if (tempLen > maxLen)
            { /* намерили сме по-дълъг път => запазваме го */
                maxLen = tempLen;
                for (j = 0; j <= ti; j++)
                {
                    SavePath[j] = Vertex[j];
                }

                si = ti;
            }

            for (k = 0; k < N; k++)
            {
                if (Used[k] == 0)
                { /* ако върхът k не участва в пътя до момента */
                    /* ако върхът, който добавяме, е съседен на последния от пътя */
                    if (A[i, k] > 0)
                    {
                        tempLen += A[i, k];
                        Used[k] = 1;    /* маркираме k като участващ в пътя */
                        Vertex[ti++] = k;  /* добавяме върха k към пътя */
                        AddVertex(k);
                        Used[k] = 0;    /* връщане от рекурсията */
                        tempLen -= A[i, k];
                        ti--;
                    }
                }
            }
        }
    }
}