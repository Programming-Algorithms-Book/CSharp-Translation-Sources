using System;

class domino
{
    const int Max = 100;
    const int NumeralSystemBase = 10; /* Основа на бройната система */
    const int N = 17; /* Брой елементи в редицата */

    static int[] successors = new int[Max]; /* Наследници за всеки връх */
    static int[] maxLengths = new int[NumeralSystemBase]; /* F[i]: текуща макс. дължина на подредица за i */
    static int[] startIndices = new int[NumeralSystemBase]; /* ind[i]: индекс на началото на редицата за i */
    static int[] sequence = new int[] {0, 72, 121, 1445, 178, 123, 3462, 762, 33434,
                    444, 472, 4, 272, 4657, 7243, 7326, 3432, 3465}; /* Редица */

    /* Намира максимална домино-редица */
    static void Solve()
    {
        int l, r;

        for (int i = 0; i < NumeralSystemBase; i++)
            maxLengths[i] = startIndices[i] = 0;

        /* Намиране дължините на редиците, започващи с цифрите от 0 до 9 */
        for (int i = N; i > 0; i--)
        {
            /* Определяне на най-старшата и най-младшата цифри на числото */
            r = sequence[i] % NumeralSystemBase;
            l = sequence[i];

            while (l > NumeralSystemBase)
                l /= NumeralSystemBase;

            /* Актуализиране на редицата, започваща със старшата цифра */
            if (maxLengths[r] >= maxLengths[l])
            {
                maxLengths[l] = maxLengths[r] + 1;
                successors[i] = startIndices[r];
                startIndices[l] = i;
            }
        }
    }

    static void Print()
    {
        int i, bestIndex = 0;
        /* Определяне на най-дългата редица */
        for (i = 1; i < NumeralSystemBase; i++) /* Никое число не започва с 0 */
            if (maxLengths[i] > maxLengths[bestIndex])
                bestIndex = i;

        /* Извеждане на редицата на екрана */
        Console.WriteLine("Дължина на максималната домино-подредица: {0}", maxLengths[bestIndex]);
        i = startIndices[bestIndex];
        do
        {
            Console.Write("{0} ", sequence[i]);
            i = successors[i];
        } while (i > 0);

        Console.WriteLine();
    }

    static void Main()
    {
        Solve();
        Print();
    }
}
