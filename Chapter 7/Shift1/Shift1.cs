using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift1
{
    struct Element
    {
        public int Data { get; set; } 
    }

    class Shift1
    {
        const int N = 10; /* Брой елементи в масива */
        const int K = 2;  /* Брой позиции на отместване */
        
        static void InitializeArray(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i].Data = i;
        }

        static int GreatestCommonDivisor(int x, int y)
        {
            while (y > 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }
            return x;
        }

        static void ShiftLeft(Element[] array)
        {
            var tempElement = new Element();
            var greatestCommonDivisor = GreatestCommonDivisor(N, K);
            for (int i = 0; i < greatestCommonDivisor; i++)
            {
                int currentIndex = i;
                tempElement = array[i];
                var nextIndex = currentIndex + K;
                if (nextIndex >= N)
                    nextIndex -= N;
                while (nextIndex != i)
                {
                    array[currentIndex] = array[nextIndex];
                    currentIndex = nextIndex;
                    nextIndex += K;
                    if (nextIndex >= N)
                        nextIndex -= N;
                }
                array[currentIndex] = tempElement;
            }
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
            PrintArray(elements);
            ShiftLeft(elements);
            PrintArray(elements);
        }
    }
}
