using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majorant4
{
    class Majorant4
    {
        public static void HeapSort(int[] input)
        {
            //Build-Max-Heap
            int heapSize = input.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(input, heapSize, p);

            for (int i = input.Length - 1; i > 0; i--)
            {
                //Swap
                int temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                MaxHeapify(input, heapSize, 0);
            }
        }

        private static void MaxHeapify(int[] input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapify(input, heapSize, largest);
            }
        }

        static void FindMajority(int[] array, out int majority)
        {
            majority = 0;
            int size2 = array.Length/2;
            HeapSort(array);
            if (CountElements(array, array[size2]) > size2)
                majority = array[size2];
        }

        static int CountElements(int[] array, int candidate)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i].Equals(candidate))
                    counter++;

            return counter;
        }

        static void Main()
        {
            int[] array = { 1, 4, 2, 3, 4, 2, 6, 5, 4, 4, 4, 4, 4 };
            int majority = 0;
            FindMajority(array, out majority);
            if (majority != 0)
                Console.WriteLine("Мажорант: {0}", majority);
            else
                Console.WriteLine("Няма мажорант.");
        }
    }
}
