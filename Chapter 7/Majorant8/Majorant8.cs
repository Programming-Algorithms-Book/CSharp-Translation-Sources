using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majorant8
{
    class Majorant8
    {
        static void FindMajority<T>(T[] array, out T majority)
        {
            int size = array.Length;
            bool part = false;
            do
            {
                int i;
                int currentCounter;
                for (currentCounter = 0, i = 1; i < size; i += 2)
                    if (array[i - 1].Equals(array[i]))
                        array[currentCounter++] = array[i];
                if (i == size)
                {
                    array[currentCounter++] = array[i - 1];
                    part = true;
                }
                else if (part || array[size - 2].Equals(array[size - 1]))
                    array[currentCounter] = array[size - 2];
                else
                    currentCounter--;
                size = currentCounter;
            } while (size > 1);
            majority = array[0];
        }

        static void Main()
        {
            char majority;
            char[] array = { 'A', 'A', 'A', 'B', 'C', 'B', 'B', 'C', 'C', 'C', 'B', 'C', 'C', };
            FindMajority(array, out majority);
            Console.WriteLine("Мажорант: {0}", majority);
        }
    }
}
