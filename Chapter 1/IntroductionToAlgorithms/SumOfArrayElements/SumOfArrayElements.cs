namespace SumOfArrayElements
{
    using System;

    public class SumOfArrayElements
    {
        internal static void Main()
        {
            int[] elements = new int[] { -5, 8, 22, 251, -158, 73 };
            long sum = GetSum(elements);
            Console.WriteLine(
                "Сумата на масива с елементи {0} е {1}",
                              string.Join(", ", elements), 
                              sum);
        }

        private static long GetSum(int[] elements)
        {
            long sum = 0L;
            for (int i = 0; i < elements.Length; i++)
            {
                sum += elements[i];
            }

            return sum;
        }
    }
}
