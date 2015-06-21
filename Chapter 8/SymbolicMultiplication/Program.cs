namespace SymbolicMultiplication
{
    using System;

    public class Program
    {
        private const string S = "bacacbcabbbcacab";
        private const int LettersCount = 3; /* Брой букви */

        /* Таблица на умножение */
        private static readonly char[,] Rel =
        {
            { 'b', 'b', 'a' },
            { 'c', 'b', 'a' },
            { 'a', 'c', 'c' }
        };

        private static readonly bool? NotCalculated = null;
        private static readonly bool?[,,] Table = new bool?[S.Length, S.Length, LettersCount];
        private static readonly int[,] Split = new int[S.Length, S.Length];

        internal static void Main()
        {
            int len = S.Length;

            if (Can(0, len - 1, 0))
            {
                PutBrackets(0, len - 1);
            }
            else
            {
                Console.Write("Няма решение");
            }
        }

        private static bool Can(int i, int j, int ch)
        {
            int c1, c2, pos;
            if (Table[i, j, ch] != NotCalculated)
            {
                return Table[i, j, ch].Value; /* Вече сметнато */
            }

            if (i == j)
            {
                return S[i] == (ch + 'a');
            }

            for (c1 = 0; c1 < LettersCount; c1++)
            {
                for (c2 = 0; c2 < LettersCount; c2++)
                {
                    if (Rel[c1, c2] == ch + 'a')
                    {
                        for (pos = i; pos <= j - 1; pos++)
                        {
                            if (Can(i, pos, c1))
                            {
                                if (Can(pos + 1, j, c2))
                                {
                                    Table[i, j, ch] = true;
                                    Split[i, j] = pos;
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            Table[i, j, ch] = false;
            return false;
        }

        private static void PutBrackets(int i, int j)
        {
            /* Поставя скобите с израза */
            if (i == j)
            {
                Console.Write(S[i]);
            }
            else
            {
                Console.Write("(");
                PutBrackets(i, Split[i, j]);
                Console.Write("*");
                PutBrackets(Split[i, j] + 1, j);
                Console.Write(")");
            }
        }
    }
}