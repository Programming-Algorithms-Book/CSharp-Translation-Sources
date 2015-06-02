using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift3
{
    struct Element
    {
        public int Data { get; set; }
    }

    class Shift3
    {
        const int N = 10; /* Брой елементи в масива */
        const int K = 2;  /* Брой позицции на отместване */

        static void InitializeArray(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i].Data = i;
        }

        static void Reverse(Element[] array, int a, int b)  /* Обръща подмасива m[a..b] */
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

        static void ShiftLeft(Element[] array)
        { /* Измества масива m на k позиции наляво, на три стъпки */
            Reverse(array, 0, K - 1);
            Reverse(array, K, N - 1);
            Reverse(array, 0, N - 1);
        }

        static void PrintArray(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i].Data);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            Element[] elements = new Element[N];
            InitializeArray(elements);
            ShiftLeft(elements);
            PrintArray(elements);
        }
    }
}
