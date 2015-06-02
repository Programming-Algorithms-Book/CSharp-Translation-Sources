using System;
using System.Collections.Generic;

namespace Majorant12FindWithStack
{
    class Majorant12FindWithStack
    {
        static bool FindMajority<T>(T[] array, out T majority)
        {
            majority = default(T);
            int size = array.Length;
            var stack = new Stack<T>();
            stack.Push(array[0]);
            for (int i = 1; i < size; i++)
            {
                if (stack.Count == 0)
                    stack.Push(array[i]);
                else if (stack.Peek().Equals(array[i]))
                    stack.Push(array[i]);
                else
                    stack.Pop();
            }
            if (stack.Count == 0)
            {
                return false;
            }
            majority = stack.Pop();
            int counter = 0;
            for (int i = 0; i < size; i++)
                if (array[i].Equals(majority))
                    counter++;
            bool isThereMajority = counter > size/2;
            return isThereMajority;
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
