namespace SetSort2
{
    using System;

    public class Program
    {
        private const int Max = 100;
        private const int Factor = 5;
        private const int MaxValue = Max * Factor;
        private const int NoIndex = int.MinValue;

        internal static void Main(string[] args)
        {
            Element[] m = new Element[Max];
            Init(m, Max);
            Console.WriteLine("Масивът преди сортирането:");
            Print(m, Max);
            Console.WriteLine("Масивът след сортирането:");
            SetSort(m, Max);
            Console.WriteLine();
        }

        /* Запълва масива със случайни цели числа */
        private static void Init(Element[] array, uint n)
        {
            /* 1. Запълване със случайни стойности в нарастващ ред */
            Random rand = new Random();
            array[0].Key = rand.Next() % Factor;
            for (int i = 1; i < n; i++)
            {
                array[i].Key = 1 + array[i - 1].Key + (rand.Next() % Factor);
            }

            /* 2. Разменяме елементи */
            for (int i = 1; i < n; i++)
            {
                /* 2.1. Избиране на два случайни индекса */
                var index1 = rand.Next() % n;
                var index2 = rand.Next() % n;

                /* 2.2. Разменяме ги */
                var tmp = array[index1];
                array[index1] = array[index2];
                array[index2] = tmp;
            }
        }

        /* Извежда ключовете на масива на екрана */
        private static void Print(Element[] array, uint n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,4}", array[i].Key);
            }

            Console.WriteLine();
        }

        private static void Do4Elem(Element e)
        {
            Console.Write("{0,4}", e.Key);
        }

        /* Сортира масив с използване на множество */
        private static void SetSort(Element[] array, uint n)
        {
            int[] indexSet = new int[MaxValue]; /* Индексно множество */

            /* 0. Инициализиране на множеството */
            for (int i = 0; i < MaxValue; i++)
            {
                indexSet[i] = NoIndex;
            }

            /* 1. Формиране на множеството */
            for (int j = 0; j < n; j++)
            {
                if ((array[j].Key >= 0 && array[j].Key < MaxValue) == false
                    || (NoIndex == indexSet[array[j].Key]) == false)
                {
                    Environment.Exit(0);
                }

                indexSet[array[j].Key] = j;
            }

            /* 2. Генериране на сортирана последователност */
            for (int i = 0; i < MaxValue; i++)
            {
                if (NoIndex != indexSet[i])
                {
                    Do4Elem(array[indexSet[i]]);
                }
            }
        }
    }
}