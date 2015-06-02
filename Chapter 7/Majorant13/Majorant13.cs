using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majorant13
{
    class Majorant13
    {
        static bool FindMajority<T>(T[] array, out T majority)
        {
            majority = default(T);
            int size = array.Length;
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                if (counter == 0)
                {
                    majority = array[i];
                    counter = 1;
                }
                else if (array[i].Equals(majority))
                    counter++;
                else
                    counter--;
            }
            if (counter > 0)
            {
                counter = 0;
                for (int i = 0; i < size; i++)
                    if (array[i].Equals(majority))
                        counter++;
                bool isThereMajority = counter > size/2;
                return isThereMajority;
            }
            return false;
        }
        static void Main()
        {
            char majority;
            char[] array = { 'A', 'D', 'A', 'B', 'A', 'B', 'A', 'A', 'B', 'A', 'B', 'A', 'C', };
            if (FindMajority(array, out majority))
                Console.WriteLine("Мажорант: {0}", majority);
            else
                Console.WriteLine("Няма мажорант.");
        }
    }
}
