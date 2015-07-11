namespace FibunacciSearch
{
    using System;
    using System.Text;

    public class FibunacciSearch
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 50;
        private const int NotFound = -1;

        // Генератор на произволни числа.
        private static readonly Random Random = new Random();

        // Числата на Фибоначи, ненадвишаващи n
        private static readonly int[] FibunacciNumbers = new int[MaxValue];

        // Брой елементи в масива
        private static int n;
        
        public static void PerformSearchTest(Element<int>[] elements)
        {
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                int index = DoFibunacciSearch(elements, elementToSearch);
                if (index == -1)
                {
                    Console.WriteLine("Елемент с такъв ключ не съществува!");
                }
                else
                {
                    Console.WriteLine("Елементът е намерен! Стойност на инф. част: {0}.", index);
                }
            }
        }

        internal static void Main()
        {
            // Брой елементи в масива.
            n = MaxValue;

            // Инициализация на масив със записи.
            Element<int>[] elements = new Element<int>[MaxValue];
            for (int index = 0; index < MaxValue; index++)
            {
                int randomNumber = Random.Next(0, 2 * MaxValue);

                // Пълнене на масива с произволни числа.
                elements[index] = new Element<int>(randomNumber, index);
            }

            SortElementsArray(elements);

            Console.WriteLine("Списъкът съдържа следните елементи: ");
            PrintElements(elements);

            Console.WriteLine("\nТестване:");
            PerformSearchTest(elements);
        }

        // Сортира елементите в масива.
        private static void SortElementsArray(Element<int>[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length; j++)
                {
                    if (elements[i].Key < elements[j].Key)
                    {
                        var swapElement = elements[i];
                        elements[i] = elements[j];
                        elements[j] = swapElement;
                    }
                }
            }
        }

        private static int DoFibunacciSearch(Element<int>[] elements, int keyToSearch)
        {
            int index = FindFibNumber(n);
            int first = FibunacciNumbers[index - 3];
            int second = FibunacciNumbers[index - 2];
            int third = FibunacciNumbers[index - 1];

            if (keyToSearch > elements[index].Key)
            {
                third += n - FibunacciNumbers[index] + 1;
            }

            while (third > 0 && third < elements.Length)
            {
                if (keyToSearch == elements[third].Key)
                {
                    return third;
                }

                if (keyToSearch < elements[third].Key)
                {
                    if (0 == first)
                    {
                        third = 0;
                    }
                    else
                    {
                        third -= first;
                        int exchangeVariable = second;
                        second = first;
                        first = exchangeVariable - first;
                    }
                }
                else
                {
                    if (1 == second)
                    {
                        third = 0;
                    }
                    else
                    {
                        third += first;
                        second -= first;
                        first -= second;
                    }
                }
            }

            return NotFound;
        }

        private static int FindFibNumber(int n)
        {
            FibunacciNumbers[0] = 0;
            FibunacciNumbers[1] = 1;
            int index = 2;
            while (true)
            {
                FibunacciNumbers[index] = FibunacciNumbers[index - 2] + FibunacciNumbers[index - 1];
                if (FibunacciNumbers[index] > n)
                {
                    return index - 1;
                }

                index++;
            }
        }

        // Принтира елементите на масива върху конзолата.
        private static void PrintElements(Element<int>[] elements)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < elements.Length; i++)
            {
                output.Append(elements[i]);
                if (i < elements.Length - 1)
                {
                    output.Append(",");
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
