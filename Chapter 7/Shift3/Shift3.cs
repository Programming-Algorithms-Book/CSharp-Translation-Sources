namespace Shift3
{
    using System;

    internal struct Element
    {
        public int Data { get; set; }
    }

    internal class Shift3
    {
        private const int N = 10; /* Брой елементи в масива */
        private const int K = 2; /* Брой позицции на отместване */

        private static void InitializeArray(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Data = i;
            }
        }

        private static void Reverse(Element[] array, int a, int b) /* Обръща подмасива m[a..b] */
        {
            int count = (b - a) / 2;
            int k = a;
            int j = b;
            for (int i = 0; i <= count; i++, j--, k++)
            {
                Element temp = array[k];
                array[k] = array[j];
                array[j] = temp;
            }
        }

        private static void ShiftLeft(Element[] array)
        {
            /* Измества масива m на k позиции наляво, на три стъпки */
            Reverse(array, 0, K - 1);
            Reverse(array, K, N - 1);
            Reverse(array, 0, N - 1);
        }

        private static void PrintArray(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i].Data);
            }

            Console.WriteLine();
        }

        private static void Main()
        {
            Element[] elements = new Element[N];
            InitializeArray(elements);
            ShiftLeft(elements);
            PrintArray(elements);
        }
    }
}