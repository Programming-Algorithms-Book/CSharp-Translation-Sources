namespace CombSort
{
    using System;
    using System.Diagnostics;

    public class CombSorter
    {
        private const int MaxValue = 100;
        private static readonly Random Rand = new Random();

        internal static void Main()
        {
            Element[] array = new Element[MaxValue];
            Element[] saveArray = new Element[MaxValue];
            Initialize(array);
            Array.Copy(array, saveArray, array.Length); /* Запазва се копие на масива */
            Console.WriteLine("Масивът преди сортирането");
            Print(array);
            CombSort(array);
            Console.WriteLine("Масивът след сортирането");
            Print(array);

            Check(array, saveArray);
        }

        private static void Swap(ref Element element1, ref Element element2)
        {
            Element tempElement = element1;
            element1 = element2;
            element2 = tempElement;
        }

        private static void Initialize(Element[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                array[i].Key = Rand.Next() % n;
            }
        }

        private static void Print(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i].Key);
            }

            Console.WriteLine();
        }

        private static void Check(Element[] array, Element[] coppiedArray)
        {
            /* 1. Проверка за наредба във възходящ ред */
            for (int i = 0; i < array.Length - 1; i++)
            {
                Debug.Assert(array[i].Key <= array[i + 1].Key, "Wrong order");
            }

            /* 2. Проверка за пермутация на изходните елементи */
            bool[] found = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int j;
                for (j = 0; j < array.Length; j++)
                {
                    if (!found[j] && array[i].Equals(coppiedArray[j]))
                    {
                        found[j] = true;
                        break;
                    }
                }

                Debug.Assert(j < array.Length, "No element found"); /* Пропада, ако не е намерен съответен */
            }
        }

        private static void CombSort(Element[] array)
        {
            int n = array.Length;
            int gap = array.Length, s;
            do
            {
                s = 0;
                gap = (int)(gap / 1.3);
                if (gap < 1)
                {
                    gap = 1;
                }

                for (int i = 0; i < n - gap; i++)
                {
                    int j = i + gap;
                    if (array[i].Key > array[j].Key)
                    {
                        Swap(ref array[i], ref array[j]);
                        s++;
                    }
                }
            } 
            while (s != 0 || gap == 0);
        }
    }
}