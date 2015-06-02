using System;

class Shell
{
    const int MAX = 100;
    const int TEST_LOOP_CNT = 100;

    const int STEPS_CNT = 4;
    const int steps0 = 40;
    static uint[] steps = new uint[STEPS_CNT] { steps0, 13, 4, 1 };

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

    static void shellSort(CElem[] m, uint n)
    {
        int i,j,k,s;
        uint stepInd;
        CElem x;

        for (stepInd = 0; stepInd < STEPS_CNT; stepInd++)
        {
            s = -(k = (int)steps[stepInd]); /* Ограничител */
            for (i = k + 1; i <= (int)n; i++)
            {
                x = m[i]; 
                j = i - k;
                if (0 == s)
                    s = -k;
                m[++s] = x;
                while (x.key < m[j].key)
                {
                    m[j + k] = m[j];
                    j -= k;
                }
                m[j + k] = x;
            }
        }
    }

    static void print(CElem[] m, uint n) /* Извежда ключовете на масива на екрана */
    {
        uint i;
        for (i = 1; i <= n; i++)
            Console.Write("{0,8}", m[i].key);
    }

    static void check(CElem[] m, CElem[] saveM, uint n)
    {
        uint i, j;
        bool[] found = new bool[n+1]; /* третира се като масив от булев тип */

        /* 1. Проверка за наредба във възходящ ред */
        for (i = 1; i < n; i++)
            if(m[i].key <= m[i + 1].key == false)
                Environment.Exit(0);
        /* 2. Проверка за пермутация на изходните елементи */
        
        for (i = 1; i <= n; i++)
        {
            for (j = 1; j <= n; j++)
                if (found[j]==false && m[i].key == saveM[j].key)
                {
                    found[j] = true;
                    break;
                }
            if(j <= n ==false)
                Environment.Exit(0); /* Пропада, ако не е намерен съответен */
        }
    }

    static void Main(string[] args)
    {
        CElem[] pm = new CElem[MAX + steps0 + 2], 
            saveM = new CElem[MAX + 1], 
            m = new CElem[MAX+1];
        uint loopInd;
        //m = pm + steps0 + 1;
        Console.WriteLine("start -- ");
        for (loopInd = 1; loopInd <= TEST_LOOP_CNT; loopInd++)
        {
            init(m, MAX);
            m.CopyTo(saveM,0);
            Console.WriteLine("Масивът преди сортирането:");
            print(m, MAX);
            shellSort(m, MAX);
            Console.WriteLine("Масивът след сортирането:");
            print(m, MAX);
            check(m, saveM, MAX);
        }
    }
}