using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Majorant5
{
    class Majorant5
    {
        static int CountElements<T>(T[] array, T candidate)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i].Equals(candidate))
                    counter++;

            return counter;
        }

        static void FindMajority<T>(T[] array, out T majority)
        {
            T median;
            majority = default(T);
            median = FindMedian<T>(array);
            if (CountElements(array, median) > array.Length / 2)
            {
                majority = median;
            }
        }

        private static T FindMedian<T>(T[] array)
        {
            //TODO: Implement blum, floyd prat, rivest algorithm for finding
            return array[0];
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
