using System;

class Setsort2
{
    const int Max = 100;
    const int Factor = 5;
    const int MaxValue = (Max * Factor);
    const int NOIndex = int.MinValue;

    struct CElem
    {
        public int Key;
        /* .............
        Някакви данни
        ............. */
    };

    static void Init(CElem[] array, uint n) /* Запълва масива със случайни цели числа */
    {
        /* 1. Запълване със случайни стойности в нарастващ ред */
        Random rand = new Random();
        array[0].Key = rand.Next() % Factor;
        for (int i = 1; i < n; i++)
            array[i].Key = 1 + array[i - 1].Key + rand.Next() % Factor;

        /* 2. Разменяме елементи */
        for (int i = 1; i < n; i++)
        {
            long index1, index2;
            CElem tmp;

            /* 2.1. Избиране на два случайни индекса */
            index1 = rand.Next() % n;
            index2 = rand.Next() % n;

            /* 2.2. Разменяме ги */
            tmp = array[index1];
            array[index1] = array[index2];
            array[index2] = tmp;
        }
    }

    static void Print(CElem[] array, uint n) /* Извежда ключовете на масива на екрана */
    {
        for (int i = 0; i < n; i++)
            Console.Write("{0,4}", array[i].Key);
        Console.WriteLine();
    }

    static void Do4Elem(CElem e)
    {
        Console.Write("{0,4}", e.Key);
    }

    static void SetSort(CElem[] array, uint n) /* Сортира масив с използване на множество */
    {
        int[] indexSet = new int[MaxValue]; /* Индексно множество */

        /* 0. Инициализиране на множеството */
        for (int i = 0; i < MaxValue; i++)
            indexSet[i] = NOIndex;

        /* 1. Формиране на множеството */
        for (int j = 0; j < n; j++)
        {
            if ((array[j].Key >= 0 && array[j].Key < MaxValue) == false ||
                (NOIndex == indexSet[array[j].Key]) == false)
                Environment.Exit(0);
            indexSet[array[j].Key] = j;
        }

        /* 2. Генериране на сортирана последователност */
        for (int i = 0; i < MaxValue; i++)
            if (NOIndex != indexSet[i])
                Do4Elem(array[indexSet[i]]);
    }

    static void Main(string[] args)
    {
        CElem[] m = new CElem[Max];
        Init(m, Max);
        Console.WriteLine("Масивът преди сортирането:");
        Print(m, Max);
        Console.WriteLine("Масивът след сортирането:");
        SetSort(m, Max);
        Console.WriteLine();
    }
}