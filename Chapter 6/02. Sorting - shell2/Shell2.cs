using System;

class Shell2
{
    const int MAX = 100;
    const int TEST_LOOP_CNT = 100;

    struct CElem
    {
        public int key;
        /* .............
        Някакви данни
        ............. */
    };

    static void init(CElem[] m, uint n) /* Запълва масива със случайни цели числа */
    {
        uint i;
        Random rand = new Random();
        for (i = 1; i <= n; i++)
            m[i].key = (int)(rand.Next() % n);
    }

    static void shellSort(CElem[] m, uint l, uint r)
    {
        uint[] incs =
        {
            1391376, 463792, 198768, 86961, 33936,
            13776, 4592, 1968, 861, 336, 112, 48,
            21, 7, 3, 1
        };
        uint i, j, k, h;

        CElem v;
        for (k = 0; k < 16; k++)
            for (h = incs[k], i = l + h; i <= r; i++)
            {
                v = m[i];
                j = i;
                while (j > h && m[j - h].key > v.key)
                {
                    m[j] = m[j - h];
                    j -= h;
                }
                m[j] = v;
            }
    }

    static void print(CElem[] m, uint n) /* Извежда ключовете на масива на екрана */
    {
        uint i;
        for (i = 1; i <= n; i++)
            Console.Write("{0}, ", m[i].key);
        Console.WriteLine();
    }

    static void check(CElem[] m, CElem[] saveM, uint n)
    {
        uint i, j;
        bool[] found = new bool[n + 1]; /* третира се като масив от булев тип */
        /* 1. Проверка за наредба във възходящ ред */
        for (i = 1; i < n; i++)
            if (m[i].key > m[i + 1].key)
                Environment.Exit(0);
        /* 2. Проверка за пермутация на изходните елементи */
        for (i = 1; i <= n; i++)
        {
            for (j = 1; j <= n; j++)
                if (found[j] == false && m[i].key == saveM[j].key)
                {
                    found[j] = true;
                    break;
                }
            if (j > n)
                Environment.Exit(0); /* Пропада, ако не е намерен съответен */
        }
    }

    static void Main(string[] args)
    {
        CElem[] m = new CElem[MAX + 1], 
        saveM = new CElem[MAX + 1];
        uint loopInd;
        Console.WriteLine("start -- ");
        for (loopInd = 1; loopInd <= TEST_LOOP_CNT; loopInd++)
        {
            init(m, MAX);
            m.CopyTo(saveM, 0);
            Console.WriteLine("Масивът преди сортирането:");
            print(m, MAX);
            shellSort(m, 1, MAX);
            Console.WriteLine("Масивът след сортирането:");
            print(m, MAX);
            check(m, saveM, MAX);
        }
    }
}