namespace Domino
{
    using System;

    public class Domino
    {
        private const int Max = 100;
        private const int NumeralSystemBase = 10; /* Основа на бройната система */
        private const int SequenceElementCount = 17; /* Брой елементи в редицата */

        private static readonly int[] Successors = new int[Max]; /* Наследници за всеки връх */
        private static readonly int[] MaxLengths = new int[NumeralSystemBase]; /* F[i]: текуща макс. дължина на подредица за i */
        private static readonly int[] StartIndices = new int[NumeralSystemBase]; /* ind[i]: индекс на началото на редицата за i */

        private static readonly int[] Sequence = new int[]
        {
            0, 72, 121, 1445, 178, 123, 3462, 762, 33434,
            444, 472, 4, 272, 4657, 7243, 7326, 3432, 3465
        }; /* Редица */

        internal static void Main()
        {
            Solve();
            Print();
        }

        /* Намира максимална домино-редица */
        private static void Solve()
        {
            int l, r;

            for (int i = 0; i < NumeralSystemBase; i++)
            {
                MaxLengths[i] = StartIndices[i] = 0;
            }

            /* Намиране дължините на редиците, започващи с цифрите от 0 до 9 */
            for (int i = SequenceElementCount; i > 0; i--)
            {
                /* Определяне на най-старшата и най-младшата цифри на числото */
                r = Sequence[i] % NumeralSystemBase;
                l = Sequence[i];

                while (l > NumeralSystemBase)
                {
                    l /= NumeralSystemBase;
                }

                /* Актуализиране на редицата, започваща със старшата цифра */
                if (MaxLengths[r] >= MaxLengths[l])
                {
                    MaxLengths[l] = MaxLengths[r] + 1;
                    Successors[i] = StartIndices[r];
                    StartIndices[l] = i;
                }
            }
        }

        private static void Print()
        {
            int i, bestIndex = 0;
            /* Определяне на най-дългата редица */
            /* Никое число не започва с 0 */
            for (i = 1; i < NumeralSystemBase; i++)
            {
                if (MaxLengths[i] > MaxLengths[bestIndex])
                {
                    bestIndex = i;
                }
            }

            /* Извеждане на редицата на екрана */
            Console.WriteLine("Дължина на максималната домино-подредица: {0}", MaxLengths[bestIndex]);
            i = StartIndices[bestIndex];
            do
            {
                Console.Write("{0} ", Sequence[i]);
                i = Successors[i];
            }
            while (i > 0);

            Console.WriteLine();
        }
    }
}