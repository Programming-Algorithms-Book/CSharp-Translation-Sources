using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift2
{
    struct Element
    {
        public int Data { get; set; }
    }

    class Shift2
    {
        const int N = 10; /* Брой елементи в масива */
        const int K = 2;  /* Брой позицции на отместване */

        static void InitializeArray(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i].Data = i;
        }

        static void Swap(Element[] array, int a, int b, int l) /* Разменя местата на подмасивите m[a..a+l-1] и m[b..b+l-1] */
        { 
            Element tempElement = new Element();
            for (int i = 0; i < l; i++) 
            {
                tempElement = array[a + i];
                array[a + i] = array[b + i];
                array[b + i] = tempElement;
            }
        }

        static void ShiftLeft(Element[] array) /* Измества масива m[] на k позиции наляво. 
   * рекурсивен процес, реализиран итеративно } */
        {
            int i = K;
            int p = K;
            int j = N - K;
            while (i != j)
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
            Swap(array, p - i, p, i);
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
