namespace DivideAndConquer
{
    using System;

    public class MinAndMaxElement
    {
        private static readonly Random Rand = new Random();

        /* Запълва масива със случайни числа */
        public static void InitializeArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Rand.Next(int.MaxValue) % ((2 * numbers.Length) + 1);
            }
        }

        /* Извежда масива на екрана */
        public static void PrintArray(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();
        }

        /* Намира максималния елемент */
        public static int FindMaxElement(int[] numbers)
        {
            int maxElement = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxElement)
                {
                    maxElement = numbers[i];
                }
            }

            return maxElement;
        }

        /* Намира минималния елемент */
        public static int FindMinElement(int[] numbers)
        {
            int minElement = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < minElement)
                {
                    minElement = numbers[i];
                }
            }

            return minElement;
        }

        /* Разменя стойностите на две променливи */
        public static void Swap(ref int element1, ref int element2)
        {
            int temp = element1;
            element1 = element2;
            element2 = temp;
        }

        /* Намира едновременно максималния и минималния елементи */
        public static void FindMinAndMax(out int min, out int max, int[] numbers, int n)
        {
            // n = 20
            int n2 = n / 2;
            min = max = numbers[n2];
            for (int i = 0; i < n2; i++)
            {
                if (numbers[i] > numbers[n - i - 1])
                {
                    if (numbers[i] > max)
                    {
                        max = numbers[i];
                    }

                    if (numbers[n - i - 1] < min)
                    {
                        min = numbers[n - i - 1];
                    }
                }
                else
                {
                    if (numbers[n - i - 1] > max)
                    {
                        max = numbers[n - i - 1];
                    }

                    if (numbers[i] < min)
                    {
                        min = numbers[i];
                    }
                }
            }
        }

        /* Намира втория по големина елемент */
        public static int FindSecondMax(int[] numbers, int n)
        {
            int x = numbers[0];
            int y = numbers[1];
            if (y > x)
            {
                Swap(ref x, ref y);
            }

            for (int i = 2; i < n; i++)
            {
                if (numbers[i] > y)
                {
                    y = numbers[i];
                    if (y > x)
                    {
                        Swap(ref x, ref y);
                    }
                }
            }

            return y;
        }

        internal static void Main()
        {
            int arrayLength = 10;
            int[] array = new int[arrayLength];
            InitializeArray(array);

            Console.WriteLine("Масивът:");
            PrintArray(array);

            Console.WriteLine("Максимален елемент: {0}", FindMaxElement(array));
            Console.WriteLine("Минимален елемент: {0}", FindMinElement(array));

            int min, max;
            FindMinAndMax(out min, out max, array, arrayLength);
            Console.WriteLine("Едновременно максимален: {0} и минимален: {1} елемент.", min, max);

            Console.WriteLine("Втори по големина елемент: {0}", FindSecondMax(array, arrayLength));
        }
    }
}