namespace MiddleFindKthElement2
{
    using System;

    public class MiddleFindKthElement2
    {
        private static readonly Random Rand = new Random();
        private static int[] array;

        /* Извежда масива на екрана */
        public static void PrintArray(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();
        }

        /* Разменя стойностите на две променливи */
        public static void Swap(ref int element1, ref int element2)
        {
            int temp = element1;
            element1 = element2;
            element2 = temp;
        }

        /* Търсене по Хоор */
        public static int FindKthElement(int left, int right, int k)
        {
            if (left == right)
            {
                return left;
            }

            int middle = Partition(left, right);
            int p = middle - left + 1;
            return k > p ? FindKthElement(left, middle, k) : FindKthElement(middle + 1, right, k - p);
        }

        internal static void Main()
        {
            int n = 10;
            int k = 4;
            array = new int[n];
            InitializeArray(array);
            PrintArray(array);
            FindKthElement(0, n - 1, k);
            PrintArray(array);
        }

        /* Раделяне по Ломуто */
        private static int Partition(int left, int right)
        {
            int i = left - 1;
            int x = array[right];
            for (int j = left; j <= right; j++)
            {
                if (array[j] <= x)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            /* Всички са <= x. Стесняване на областта с 1. */
            if (i == right)
            {
                i--;
            }

            return i;
        }

        /* Запълва масива със случайни числа */
        private static void InitializeArray(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Rand.Next() % ((2 * input.Length) + 1);
            }
        }
    }
}