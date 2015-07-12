namespace Shift2
{
    using System;

    public class Shift2
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

        /* Разменя местата на подмасивите m[a..a+l-1] и m[b..b+l-1] */
        private static void Swap(Element[] array, int a, int b, int l)
        {
            for (int i = 0; i < l; i++)
            {
                Element tempElement = array[a + i];
                array[a + i] = array[b + i];
                array[b + i] = tempElement;
            }
        }

        /* Измества масива m[] на k позиции наляво. 
         * Рекурсивен процес, реализиран итеративно */
        private static void ShiftLeft(Element[] array)
        {
            int i = K;
            int p = K;
            int j = N - K;
            while (i != j)
            {
                if (i > j)
                {
                    Swap(array, p - i, p, j);
                    i -= j;
                }
                else
                {
                    Swap(array, p - i, p + j - i, i);
                    j -= i;
                }
            }

            Swap(array, p - i, p, i);
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