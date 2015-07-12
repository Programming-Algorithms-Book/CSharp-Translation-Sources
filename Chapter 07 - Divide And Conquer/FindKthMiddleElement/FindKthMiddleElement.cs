namespace MiddleFindKthElement
{
    using System;

    public class FindKthMiddleElement
    {
        private static readonly Random Rand = new Random();

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

        public static void FindKthElement(int[] array, int n, int k)
        {
            int left = 0;
            int right = n - 1;

            while (left < right)
            {
                int x = array[k];
                int i = left;
                int j = right;

                while (true)
                {
                    while (x > array[i])
                    {
                        i++;
                    }

                    while (x < array[j])
                    {
                        j--;
                    }

                    if (i > j)
                    {
                        break;
                    }

                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }

                if (j < k)
                {
                    left = i;
                }

                if (k < i)
                {
                    right = j;
                }
            }
        }

        internal static void Main()
        {
            /* Брой елементи в масива */
            int n = 10;

            /* Пореден номер на търсения елемент */
            int k = 4;

            int[] array = new int[n];
            InitializeArray(array);
            Console.WriteLine("Масивът преди търсенето: ");
            PrintArray(array);

            Console.WriteLine("\nТърсим k-ия елемент: k={0}", k);
            FindKthElement(array, n, k);
            Console.WriteLine("\nМасивът след търсенето:");
            PrintArray(array);

            Console.WriteLine("\nk-ият елемент е: {0}", array[k]);
        }

        /* Запълва масива със случайни числа */
        private static void InitializeArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Rand.Next() % ((2 * array.Length) + 1);
            }
        }
    }
}