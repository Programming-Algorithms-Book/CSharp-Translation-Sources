namespace RingExpression
{
    using System;

    public class Program
    {
        private static readonly long[] X = new long[] { 0, 9, -3, 8, 7, -8, 0, 7 }; /* Стойности на числата (без първото) */
        private static readonly char[] Sign = new char[] { ' ', '+', '*', '*', '-', '+', '*', '-' }; /* Знаци между тях */
        private static readonly int N = X.Length - 1; /* Брой числа */
        private static readonly Goal[,] F = new Goal[N + 1, N + 1]; /* Целеви функции Fmin() и Fmax() */

        internal static void Main()
        {
            Solve();
            Print();
        }

        /* Намира максимума и минимума, както и как се получават */
        private static void Solve()
        {
            /* Инициализация */
            Sign[0] = Sign[N];
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    F[i, j].Min = int.MaxValue;
                }
            }

            /* Пресмятане на стойностите на целевата функция */
            for (int i = 1; i <= N; i++)
            {
                Calculate(i, N);
            }
        }

        /* Пресмята стойностите на целевата функция */

        private static void Calculate(int beg, int len)
        {
            if (beg > N)
            {
                beg -= N;
            }

            /* Стойността вече е била сметната */
            if (F[beg, len].Min != int.MaxValue)
            {
                return;
            }

            if (len == 1)
            {
                F[beg, len].Min = F[beg, len].Max = X[beg];
                F[beg, len].LenMin = F[beg, len].LenMax = 0;
                return;
            }

            /* Стойността трябва да се пресметне */
            F[beg, len].Min = int.MaxValue;
            F[beg, len].Max = -int.MaxValue;
            for (int i = 1; i < len; i++)
            {
                /* Пресмятане на всички стойности f[beg, i] и f[beg+i, len-i] */
                Calculate(beg, i);
                int beg2;
                if (beg + i > N)
                {
                    beg2 = beg + i - N;
                }
                else
                {
                    beg2 = beg + i;
                }

                Calculate(beg2, len - i);
                var val1 = Oper(F[beg, i].Min, Sign[beg2 - 1], F[beg2, len - i].Min);
                var val2 = Oper(F[beg, i].Min, Sign[beg2 - 1], F[beg2, len - i].Max);
                var val3 = Oper(F[beg, i].Max, Sign[beg2 - 1], F[beg2, len - i].Min);
                var val4 = Oper(F[beg, i].Max, Sign[beg2 - 1], F[beg2, len - i].Max);
                /* Актуализиране на минималната стойност на f[beg, len] */
                var minValue = Math.Min(val1, Math.Min(val2, Math.Min(val3, val4)));
                if (minValue < F[beg, len].Min)
                {
                    F[beg, len].Min = minValue;
                    F[beg, len].LenMin = i;
                }

                /* Актуализиране на максималната стойност на f[beg, len] */
                var maxValue = Math.Max(val1, Math.Max(val2, Math.Max(val3, val4)));
                if (maxValue > F[beg, len].Max)
                {
                    F[beg, len].Max = maxValue;
                    F[beg, len].LenMax = i;
                }
            }
        }

        /* Извършва операцията */

        private static long Oper(long v1, char sign, long v2)
        {
            switch (sign)
            {
                case '+':
                    return v1 + v2;
                case '-':
                    return v1 - v2;
                case '*':
                    return v1 * v2;
            }

            return 0;
        }

        /* Търси и извежда максимума и минимума */

        private static void Print()
        {
            int i, minIndex, maxIndex;
            for (minIndex = 1, i = 2; i <= N; i++)
            {
                if (F[i, N].Min < F[minIndex, N].Min)
                {
                    minIndex = i;
                }
            }

            for (maxIndex = 1, i = 2; i <= N; i++)
            {
                if (F[i, N].Max > F[maxIndex, N].Max)
                {
                    maxIndex = i;
                }
            }

            Console.WriteLine("Минимална стойност: {0}", F[minIndex, N].Min);
            PrintMinMax(minIndex, N, true);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Максимална стойност: {0}", F[maxIndex, N].Max);
            PrintMinMax(maxIndex, N, false);
        }

        /* Извежда израз, за който се получава min/max */

        private static void PrintMinMax(int beg, int len, bool printMin)
        {
            int i, beg2;
            if (beg > N)
            {
                beg -= N;
            }

            if (1 == len)
            {
                Console.Write(X[beg]);
            }
            else
            {
                if (len < N)
                {
                    Console.Write("(");
                }

                i = printMin ? F[beg, len].LenMin : F[beg, len].LenMax;
                if ((beg2 = beg + i) > N)
                {
                    beg2 -= N;
                }

                PrintMinMax(beg, i, printMin); /* Рекурсия за лявата част на израза */
                Console.Write(Sign[beg2 - 1]); /* Извеждане на операцията */
                PrintMinMax(beg2, len - i, printMin); /* Рекурсия за дясната част на израза */
                if (len < N)
                {
                    Console.Write(")");
                }
            }
        }
    }
}