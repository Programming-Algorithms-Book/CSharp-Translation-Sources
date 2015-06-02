using System;

namespace Majorant11
{
    class Majorant11
    {
        static void FindMajority<T>(T[] array, out T majority)
        {
            int size = array.Length;
            int[] count = new int[size];
            for (int i = 0; i < size; i++)
                count[i] = 1;
            int currentCounter;
            do
            {
                currentCounter = 0;
                int i;
                for (i = 1; i < size; i += 2)
                {
                    if (array[i - 1].Equals(array[i]))
                    {
                        count[currentCounter] = count[i - 1] + count[i];
                        array[currentCounter++] = array[i];
                    }
                    else if (count[i] > count[i - 1])
                    {
                        count[currentCounter] = count[i] - count[i - 1];
                        array[currentCounter++] = array[i];
                    }
                    else if (count[i] < count[i - 1])
                    {
                        count[currentCounter] = count[i - 1] - count[i];
                        array[currentCounter++] = array[i - 1];
                    }
                }
                if ((size & 1) == 1)
                {
                    count[currentCounter] = count[i - 1];
                    array[currentCounter++] = array[i - 1];
                }
                size = currentCounter;
            } while (size > 1);
            majority = array[0];
        }

        static void Main()
        {
            char majority;
            char[] array = { 'A', 'D', 'A', 'B', 'A', 'B', 'A', 'A', 'B', 'A', 'B', 'A', 'C', };
            FindMajority(array, out majority);
            Console.WriteLine("Мажорант: {0}", majority);
        }
    }
}
