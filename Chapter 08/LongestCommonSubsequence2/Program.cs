namespace LongestCommonSubsequence2
{
    using System;

    public class Program
    {
        private const int Left = 1;
        private const int Up = 2;
        private const int Upleft = 3;
        private const string X = "acbcacbcaba"; /* Първа редица */
        private const string Y = "abacacacababa"; /* Втора редица */

        private static readonly int M = X.Length; /* Дължина на първата редица */
        private static readonly int N = Y.Length; /* Дължина на втората редица */
        private static readonly int[,] B = new int[M + 1, N + 1]; /* Указател към предходен елемент */
        private static readonly int[,] F = new int[M + 1, N + 1]; /* Целева функция */

        internal static void Main()
        {
            Console.WriteLine("Дължина на най-дългата обща подредица: {0}", LCS_Length());
            Console.Write("PrintLCS:  Максимална обща подредица (в обратен ред): ");
            PrintLcs();
            Console.WriteLine();
            Console.Write("PrintLCS2: Максимална обща подредица: ");
            PrintLcs2(X.Length, Y.Length);
            Console.WriteLine();
            Console.Write("PrintLCS3: Максимална обща подредица: ");
            PrintLcs3(X.Length, Y.Length);
        }

        /* Намира дължината на най-дългата обща подредица */

        private static int LCS_Length()
        {
            /* Начална инициализация */
            for (int i = 1; i <= M; i++)
            {
                F[i, 0] = 0;
            }

            for (int j = 0; j <= N; j++)
            {
                F[0, j] = 0;
            }

            /* Основен цикъл */
            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        F[i, j] = F[i - 1, j - 1] + 1;
                        B[i, j] = Upleft;
                    }
                    else if (F[i - 1, j] >= F[i, j - 1])
                    {
                        F[i, j] = F[i - 1, j];
                        B[i, j] = Up;
                    }
                    else
                    {
                        F[i, j] = F[i, j - 1];
                        B[i, j] = Left;
                    }
                }
            }

            return F[M, N];
        }

        /* Намира една възможна максимална обща подредица (обърната) */

        private static void PrintLcs()
        {
            int i = X.Length;
            int j = Y.Length;
            while (i > 0 && j > 0)
            {
                switch (B[i, j])
                {
                    case Upleft:
                        Console.Write(X[i - 1]);
                        i--;
                        j--;
                        break;
                    case Up:
                        i--;
                        break;
                    case Left:
                        j--;
                        break;
                }
            }
        }

        /* Намира една възможна максимална обща подредица */

        private static void PrintLcs2(int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return;
            }

            if (B[i, j] == Upleft)
            {
                PrintLcs2(i - 1, j - 1);
                Console.Write(X[i - 1]);
            }
            else if (B[i, j] == Up)
            {
                PrintLcs2(i - 1, j);
            }
            else
            {
                PrintLcs2(i, j - 1);
            }
        }

        /* Намира една възможна максимална обща подредица */

        private static void PrintLcs3(int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return;
            }

            if (X[i - 1] == Y[j - 1])
            {
                PrintLcs3(i - 1, j - 1);
                Console.Write(X[i - 1]);
            }
            else if (F[i, j] == F[i - 1, j])
            {
                PrintLcs3(i - 1, j);
            }
            else
            {
                PrintLcs3(i, j - 1);
            }
        }
    }
}