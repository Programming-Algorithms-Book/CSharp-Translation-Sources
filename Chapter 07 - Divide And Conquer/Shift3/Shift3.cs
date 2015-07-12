namespace Shift3
{
    using System;

    public class Shift3
    {
        /* Брой елементи в масива */
        private const int N = 10;

        /* Брой позицции на отместване */
        private const int K = 2;

        internal static void Main()
        {
            Element[] elements = new Element[N];
            InitializeArray(elements);
            ShiftLeft(elements);
            PrintArray(elements);
        }

        private static void InitializeArray(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Data = i;
            }
        }

        /* Обръща подмасива m[a..b] */
        private static void Reverse(Element[] array, int a, int b)
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
    }
}