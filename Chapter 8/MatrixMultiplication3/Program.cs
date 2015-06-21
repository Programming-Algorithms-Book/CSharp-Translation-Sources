namespace MatrixMultiplication3
{
    using System;

    public class Program
    {
        private static readonly int[] R = { 12, 13, 35, 3, 34, 2, 21, 10, 21, 6 }; /* Размерности на матриците */
        private static readonly int N = R.Length - 1; /* Брой матрици */
        private static readonly int[,] M = new int[N + 1, N + 1]; /* Таблица - целева функция */
        private static readonly Order[] MatrixOrder = new Order[(N + 1) * (N + 1)]; /* Ред на умножение на матриците */
        private static int cnt; /* Брой действия за пресмятането */

        internal static void Main()
        {
            Solve();
            cnt = 0;
            BuildOrder(1, N);
            Console.WriteLine("Минималният брой умножения е: {0}", M[1, N]);
            PrintMatrix();
            Console.WriteLine();
            PrintMultiplyPlan();
            Console.WriteLine();
            Console.Write("Ред на умножение на матриците: ");
            GetOrder(1, N);
        }

        /* Формира таблица, съдържаща минималния брой умножения, необходими за
     * умножението на всяка двойка матрици, както и индексът, за който се постига */

        private static void Solve()
        {
            /* Инициализация */
            for (int i = 0; i < MatrixOrder.Length; ++i)
            {
                MatrixOrder[i] = new Order();
            }

            for (int i = 1; i <= N; i++)
            {
                M[i, i] = 0;
            }

            /* Основен цикъл */
            for (int j = 1; j <= N; j++)
            {
                for (int i = 1; i <= N - j; i++)
                {
                    M[i, i + j] = int.MaxValue;
                    for (int k = i; k < i + j; k++)
                    {
                        int t = M[i, k] + M[k + 1, i + j] + (R[i - 1] * R[k] * R[i + j]);
                        /* Подобряване на текущото решение */
                        if (t < M[i, i + j])
                        {
                            M[i, i + j] = t;
                            M[i + j, i] = k;
                        }
                    }
                }
            }
        }

        private static int BuildOrder(int ll, int rr) /* Формира алгоритъм за умножение */
        {
            int ret = cnt++;
            if (ll < rr)
            {
                MatrixOrder[ret].Left = BuildOrder(ll, M[rr, ll]);
                MatrixOrder[ret].Right = BuildOrder(M[rr, ll] + 1, rr);
            }
            else
            {
                MatrixOrder[ret].Left = ll;
                MatrixOrder[ret].Right = rr;
            }

            return ret;
        }

        private static void PrintMatrix() /* Извежда матрицата на минимумите на екрана */
        {
            Console.WriteLine("Матрица на минимумите:");
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    Console.Write("{0, 8}", M[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void PrintMultiplyPlan() /* Извежда план за умножение на матриците */
        {
            Console.WriteLine("План за умножение на матриците:");
            for (int i = 0; i < cnt; i++)
            {
                if (MatrixOrder[i].Left == MatrixOrder[i].Right)
                {
                    Console.WriteLine("L[{0}] = M{1}", i, MatrixOrder[i].Left);
                }
                else
                {
                    Console.WriteLine("L[{0}] = L[{1}] * L[{2}]", i, MatrixOrder[i].Left, MatrixOrder[i].Right);
                }
            }
        }

        private static void GetOrder(int ll, int rr) /* Изразява реда на умножение с помощта на скоби */
        {
            if (ll == rr)
            {
                Console.Write("M{0}", ll);
            }
            else
            {
                Console.Write("(");
                GetOrder(ll, M[rr, ll]);
                Console.Write("*");
                GetOrder(M[rr, ll] + 1, rr);
                Console.Write(")");
            }
        }
    }
}