namespace DivideAndConquer
{
    using System;

    class MinAndMaxElement
    {
        private static readonly Random rand = new Random();

        public static void InitializeArray(int[] numbers) /* Запълва масива със случайни числа */
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(int.MaxValue) % (2 * numbers.Length + 1);
            }
        }

        public static void PrintArray(int[] numbers) /* Извежда масива на екрана */
        {
            foreach (int number in numbers)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        public static int FindMaxElement(int[] numbers) /* Намира максималния елемент */
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

        public static int FindMinElement(int[] numbers) /* Намира минималния елемент */
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

        public static void Swap(ref int element1, ref int element2) /* Разменя стойностите на две променливи */
        {
            int temp = element1;
            element1 = element2;
            element2 = temp;
        }

        public static void FindMinAndMax(out int min, out int max, int[] numbers, int n)
        /* Намира едновременно максималния и минималния елементи */
        {
            int n2 = n/2; //n = 20
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

        public static int FindSecondMax(int[] numbers, int n) /* Намира втория по големина елемент */
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

        static void Main()
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
