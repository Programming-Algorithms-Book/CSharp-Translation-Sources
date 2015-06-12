namespace BinarySearch.Iterative
{
    using System;
    using System.Text;

    public class BinarySearchIterative
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 50;
        private const int NotFound = -1;

        // Генератор на произволни числа.
        private static readonly Random Random = new Random();

        public static void PerformSearchTest(Element<int>[] elements, int n)
        {
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                var index = BinarySearch(elements, elementToSearch);
                if (index == NotFound)
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
            int n = MaxValue;

            // Инициализация на масив със записи.            
            Element<int>[] elements = new Element<int>[n];
            for (int index = 0; index < n; index++)
            {
                int randomNumber = Random.Next(0, 2 * MaxValue);

                // Пълнене на масива с произволни числа.
                elements[index] = new Element<int>(randomNumber, index);
            }

            SortElementsArray(elements);

            Console.WriteLine("Списъкът съдържа следните елементи: ");
            PrintElements(elements);

            Console.WriteLine("\nТестване:");
            PerformSearchTest(elements, n);
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

        // Извърша двоично търсене.
        private static int BinarySearch(Element<int>[] elements, int elementToSearch)
        {
            int leftIndex = 0;
            int rightIndex = elements.Length - 1;
            int midIndex;
            int result = NotFound;
            while (leftIndex <= rightIndex)
            {
                midIndex = (leftIndex + rightIndex) / 2;
                if (elementToSearch < elements[midIndex].Key)
                {
                    rightIndex = midIndex - 1;
                }
                else if (elementToSearch > elements[midIndex].Key)
                {
                    leftIndex = midIndex + 1;
                }
                else
                {
                    result = midIndex;
                    break;
                }
            }

            return result;
        }

        // Принтира елементите на масива върху конзолата.
        private static void PrintElements(Element<int>[] elements)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < elements.Length; i++)
            {
                output.Append(elements[i].Value);
                if (i < elements.Length - 1)
                {
                    output.Append(",");
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
