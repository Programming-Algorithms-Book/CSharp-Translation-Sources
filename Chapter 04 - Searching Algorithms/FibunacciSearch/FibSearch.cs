namespace FibunacciSearch
{
    using System;
    using System.Text;

    public class FibSearch
    {
        private const int MaxValue = 50;              // Максимална стойност на елементите от масива.
        private const int NotFound = -1;

        private static readonly Random Random = new Random();         // Генератор на произволни числа.
        private static readonly int[] FibunacciNumbers = new int[MaxValue]; // Числата на Фибоначи, ненадвишаващи n

        private static int n;              // Брой елементи в масива
        
        public static void PerformSearchTest(Element<int>[] elements)
        {
            int index;
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                index = FibunacciSearch(elements, elementToSearch);
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
            n = MaxValue;                                                   // Брой елементи в масива.
            Element<int>[] elements = new Element<int>[MaxValue];                  // Инициализация на масив със записи.
            for (int index = 0; index < MaxValue; index++)
            {
                int randomNumber = Random.Next(0, 2 * MaxValue);
                elements[index] = new Element<int>(randomNumber, index);     // Пълнене на масива с произволни числа.
            }

            SortElementsArray(elements);

            Console.WriteLine("Списъкът съдържа следните елементи: ");
            PrintElements(elements);

            Console.WriteLine("\nТестване:");
            PerformSearchTest(elements);
        }

        private static void SortElementsArray(Element<int>[] elements)        // Сортира елементите в масива.
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

        private static int FibunacciSearch(Element<int>[] elements, int keyToSearch)
        {
            int third, second, first;
            int index = FindFibNumber(n);
            third = FibunacciNumbers[index - 1];
            second = FibunacciNumbers[index - 2];
            first = FibunacciNumbers[index - 3];
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
                        int exchangeVariable;
                        third -= first;
                        exchangeVariable = second;
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

        private static void PrintElements(Element<int>[] elements)        // Принтира елементите на масива върху конзолата.
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
