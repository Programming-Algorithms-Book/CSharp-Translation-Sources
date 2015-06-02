using System;
using System.Diagnostics;

class SetSort
{
    private const int Max = 100;
    private const int TestLoopCount = 100;
    private const int Factor = 5;
    private const int MaxValue = Max * Factor;

    private static Random random = new Random();

    static void Init(int[] elements)
    {
        // 1. Запълване със случайни стойности в нарастващ ред
        elements[0] = random.Next() % Factor;
        for (int i = 1; i < elements.Length; i++)
        {
            elements[i] = 1 + elements[i - 1] + random.Next() % Factor;
        }

        // 2. Разменяме многократно произволни двойки елементи
        for (int i = 1; i < elements.Length; i++)
        {
            // 2.1 Избиране на ва случайни индекса
            int index1 = random.Next() % elements.Length;
            int index2 = random.Next() % elements.Length;

            // 2.2 Разменяме ги
            int old = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = old;
        }
    }

    // Сортира масив с използване на множество
    static void SortWithSet(int[] elements)
    {
        // 0. Инициализиране на множество;
        bool[] set = new bool[MaxValue];

        // 1. Формиране на множеството
        for (int i = 0; i < elements.Length; i++)
        {
            Debug.Assert(elements[i] >= 0 && elements[i] < MaxValue);
            Debug.Assert(!set[elements[i]]);
            set[elements[i]] = true;
        }

        // 2. Генериране на сортирана последователност
        int j = 0;
        for (int i = 0; i < MaxValue; i++)
        {
            if (set[i])
            {
                elements[j] = i;
                j++;
            }
        }

        Debug.Assert(j == elements.Length);
    }

    static void Print(int[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            Console.Write("{0} ", elements[i]);
        }

        Console.WriteLine();
    }

    static void Check(int[] elements)
    {
        // 1. Проверка за наредба във възходящ ре
        for (int i = 0; i < elements.Length - 1; i++)
        {
            Debug.Assert(elements[i] <= elements[i + 1]);
        }

        // 2. Проверка за пермутация на изходните елементи
        bool[] found = new bool[elements.Length];

        for (int i = 0; i < elements.Length; i++)
        {
            for (int j = 0; j < elements.Length; j++)
            {
                if (!found[j] && elements[i] == elements[j])
                {
                    found[j] = true;
                    break;
                }

                // Пропада, ако не е намерен съответен
                Debug.Assert(j < elements.Length);
            }
        }
    }

    static void Main()
    {
        int[] elements = new int[Max];

        for (int i = 1; i <= TestLoopCount; i++)
        {
            Console.WriteLine("{0}<<<<< Тест {1} >>>>>", Environment.NewLine, i);
            Init(elements);

            Console.WriteLine("Масивът преди сортирането:");
            Print(elements);

            SortWithSet(elements);
            Console.WriteLine("Масивът след сортирането:");
            Print(elements);

            Check(elements);
        }
    }
}