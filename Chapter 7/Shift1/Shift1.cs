namespace Shift1
{
    using System;

    internal struct Element
    {
        public int Data { get; set; }
    }

    internal class Shift1
    {
        private const int N = 10; /* Брой елементи в масива */
        private const int K = 2; /* Брой позиции на отместване */

        private static void InitializeArray(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Data = i;
            }
        }

        private static int GreatestCommonDivisor(int x, int y)
        {
            while (y > 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }

            return x;
        }

        private static void ShiftLeft(Element[] array)
        {
            var tempElement = new Element();
            var greatestCommonDivisor = GreatestCommonDivisor(N, K);
            for (int i = 0; i < greatestCommonDivisor; i++)
            {
                int currentIndex = i;
                tempElement = array[i];
                var nextIndex = currentIndex + K;
                if (nextIndex >= N)
                {
                    nextIndex -= N;
                }

                while (nextIndex != i)
                {
                    array[currentIndex] = array[nextIndex];
                    currentIndex = nextIndex;
                    nextIndex += K;
                    if (nextIndex >= N)
                    {
                        nextIndex -= N;
                    }
                }

                array[currentIndex] = tempElement;
            }
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
            PrintArray(elements);
            ShiftLeft(elements);
            PrintArray(elements);
        }
    }
}