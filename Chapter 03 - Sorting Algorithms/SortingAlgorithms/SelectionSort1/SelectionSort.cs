namespace SelectionSort1
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class SelectionSort
    {
        private const int Max = 100;
        private const int TestLoopCount = 100;

        private static readonly Random Random = new Random();

        internal static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Element[] elements = new Element[Max];

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

        // Запълва масива със случайни цели числа
        private static void Init(Element[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                int key = Random.Next() % elements.Length;
                elements[i] = new Element() { Key = key };
            }
        }

        private static void Swap(Element e1, Element e2)
        {
            Element old = e1;
            e1 = e2;
            e2 = old;
        }

        private static void StraightSelection(Element[] elements)
        {
            for (int i = 0; i < elements.Length - 1; i++)
            {
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[i].Key > elements[j].Key)
                    {
                        Swap(elements[i], elements[j]);
                        Element old = elements[i];
                        elements[i] = elements[j];
                        elements[j] = old;
                    }
                }
            }
        }

        // Извежда ключовете на масива на екрана
        private static void Print(Element[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write("{0} ", elements[i].Key);
            }

            Console.WriteLine();
        }

        // TODO: Transfer to unit tests
        private static void Check(Element[] elements)
        {
            // 1. Проверка за наредба във възходящ ре
            for (int i = 0; i < elements.Length - 1; i++)
            {
                Debug.Assert(elements[i].Key <= elements[i + 1].Key, "Wrong order");
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
                    Debug.Assert(j < elements.Length, "No element found");
                }
            }
        }
    }
}