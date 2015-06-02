using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majorant9
{
    class Majorant9
    {
        static void FindMajority<T>(T[] array, out T majority)
        {
            int size = array.Length;
            majority = default(T);
            do
            {
                int currentCounter = 0;
                for (int i = 1; i < size; i += 2)
                    if (array[i - 1].Equals(array[i]))
                        array[currentCounter++] = array[i];
                if (size % 2 == 1)
                    majority = array[size - 1];
                size = currentCounter;
            } while (size > 0);
        }

        static void Main()
        {
            char majority;
            char[] array = { 'A', 'A', 'A', 'C', 'C', 'C', 'B', 'C', 'B', 'C', 'C', 'C', 'A', };
            FindMajority(array, out majority);
            Console.WriteLine("Мажорант: {0}", majority);
        }
    }
}
