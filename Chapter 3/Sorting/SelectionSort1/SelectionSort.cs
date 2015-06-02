using System;
using System.Diagnostics;

class SelectionSort
{
    private const int Max = 100;
    private const int TestLoopCount = 100;

    private static Random random = new Random();

    struct CustomElement
    {
        public int Key { get; set; }
        // Структурата може да има още данни
    }

    // Запълва масива със случайни цели числа
    static void Init(CustomElement[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            int key = random.Next() % elements.Length;
            elements[i] = new CustomElement() { Key = key };
        }
    }

    static void Swap(CustomElement e1, CustomElement e2)
    {
        CustomElement old = e1;
        e1 = e2;
        e2 = old;
    }

    static void StraightSelection(CustomElement[] elements)
    {
        for (int i = 0; i < elements.Length - 1; i++)
        {
            for (int j = i + 1; j < elements.Length; j++)
            {
                if (elements[i].Key > elements[j].Key)
                {
                    Swap(elements[i], elements[j]);
                    CustomElement old = elements[i];
                    elements[i] = elements[j];
                    elements[j] = old;
                }
            }
        }
    }

    // Извежда ключовете на масива на екрана
    static void Print(CustomElement[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            Console.Write("{0} ", elements[i].Key);
        }
        Console.WriteLine();
    }

    static void Check(CustomElement[] elements)
    {
        // 1. Проверка за наредба във възходящ ре
        for (int i = 0; i < elements.Length - 1; i++)
        {
            Debug.Assert(elements[i].Key <= elements[i + 1].Key);
        }

        // 2. Проверка за пермутация на изходните елементи
        bool[] found = new bool[elements.Length];

        for (int i = 0; i < elements.Length; i++)
        {
            for (int j = 0; j < elements.Length; j++)
            {
                if (!found[j] && elements[i].Key == elements[j].Key)
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
        CustomElement[] elements = new CustomElement[Max];

        for (int i = 1; i <= TestLoopCount; i++)
        {
            Console.WriteLine("{0}<<<<< Тест {1} >>>>>", Environment.NewLine, i);
            Init(elements);

            Console.WriteLine("Масивът преди сортирането:");
            Print(elements);
            StraightSelection(elements);

            Console.WriteLine("Масивът след сортирането:");
            Print(elements);

            Check(elements);
        }
    }
}