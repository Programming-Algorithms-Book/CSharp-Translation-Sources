using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Majorant6
{
    class Majorant6
    {
        static void FindMajority<T>(T[] array, out T majority)
        {
            int arrayLength = array.Length;
            int length2 = arrayLength / 2;
            majority = default(T);
            Dictionary<T, int> counter = new Dictionary<T, int>(arrayLength);
            /* Инициализация */
            for (int i = 0; i < arrayLength; i++)
                if (!counter.ContainsKey(array[i]))
                    counter.Add(array[i], 0);
            /* Броене */
            for (int j = 0; j < arrayLength; j++)
                counter[array[j]]++;
            /* Проверка за мажорант */
            for (int i = 0; i < arrayLength; i++)
                if (counter[array[i]] > length2)
                {
                    majority = array[i];
                    break;
                }
        }

        static void Main()
        {
            char majority;
            char[] array = { 'A', 'A', 'A', 'C', 'C', 'B', 'B', 'C', 'C', 'C', 'B', 'C', 'C', };
            FindMajority(array, out majority);
            if (majority != default(char))
                Console.WriteLine("Мажорант: {0}", majority);
            else
                Console.WriteLine("Няма мажорант.");
        }
    }
}
