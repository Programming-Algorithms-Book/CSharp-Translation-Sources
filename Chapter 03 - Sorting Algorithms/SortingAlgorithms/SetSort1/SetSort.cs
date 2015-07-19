namespace SetSort1
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class SetSort
    {
        private const int Max = 100;
        private const int TestLoopCount = 100;
        private const int Factor = 5;
        private const int MaxValue = Max * Factor;

        private static readonly Random Random = new Random();

        internal static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

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

        private static void Init(int[] elements)
        {
            // 1. Запълване със случайни стойности в нарастващ ред
            elements[0] = Random.Next() % Factor;
            for (int i = 1; i < elements.Length; i++)
            {
                elements[i] = 1 + elements[i - 1] + (Random.Next() % Factor);
            }

            // 2. Разменяме многократно произволни двойки елементи
            for (int i = 1; i < elements.Length; i++)
            {
                // 2.1 Избиране на ва случайни индекса
                int index1 = Random.Next() % elements.Length;
                int index2 = Random.Next() % elements.Length;

                // 2.2 Разменяме ги
                int old = elements[index1];
                elements[index1] = elements[index2];
                elements[index2] = old;
            }
        }

        // Сортира масив с използване на множество
        private static void SortWithSet(int[] elements)
        {
            // 0. Инициализиране на множество;
            bool[] set = new bool[MaxValue];

            // 1. Формиране на множеството
            for (int i = 0; i < elements.Length; i++)
            {
                Debug.Assert(elements[i] >= 0 && elements[i] < MaxValue, "Element out of range");
                Debug.Assert(!set[elements[i]], "Invalid element");
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

            Debug.Assert(j == elements.Length, "Out of range");
        }

        private static void Print(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write("{0} ", elements[i]);
            }

            Console.WriteLine();
        }

        // TODO: Transfer to unit tests
        private static void Check(int[] elements)
        {
            // 1. Проверка за наредба във възходящ ре
            for (int i = 0; i < elements.Length - 1; i++)
            {
                Debug.Assert(elements[i] <= elements[i + 1], "Wrong order");
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
                    Debug.Assert(j < elements.Length, "Element not found");
                }
            }
        }
    }
}