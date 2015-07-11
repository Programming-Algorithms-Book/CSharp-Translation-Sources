namespace BinarySearch.WithoutCycles
{
    using System;
    using System.Text;

    public class BinarySearchWithoutCycles
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 1000;
        private const int NotFound = -1;

        // Генератор на произволни числа.
        private static Random random = new Random();

        internal static void Main()
        {
            // Брой елементи в масива.
            int n = MaxValue;

            // Инициализация на масив със записи.
            Element<int>[] elements = new Element<int>[n];
            for (int index = 0; index < n; index++)
            {
                int randomNumber = random.Next(0, 2 * MaxValue);

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
            if (elements[512].Key < elementToSearch)
            {
                leftIndex = 1000 - 512 + 1;
            }

            if (elements[leftIndex + 256].Key < elementToSearch)
            {
                leftIndex += 256;
            }

            if (elements[leftIndex + 128].Key < elementToSearch)
            {
                leftIndex += 128;
            }

            if (elements[leftIndex + 64].Key < elementToSearch)
            {
                leftIndex += 64;
            }

            if (elements[leftIndex + 32].Key < elementToSearch)
            {
                leftIndex += 32;
            }

            if (elements[leftIndex + 16].Key < elementToSearch)
            {
                leftIndex += 16;
            }

            if (elements[leftIndex + 8].Key < elementToSearch)
            {
                leftIndex += 8;
            }

            if (elements[leftIndex + 4].Key < elementToSearch)
            {
                leftIndex += 4;
            }

            if (elements[leftIndex + 2].Key < elementToSearch)
            {
                leftIndex += 2;
            }

            if (leftIndex + 1 < MaxValue && elements[leftIndex + 1].Key < elementToSearch)
            {
                leftIndex += 1;
            }

            int result = NotFound;
            if (leftIndex + 1 < 1000 && elements[++leftIndex].Key == elementToSearch)
            {
                result = leftIndex;
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

        private static void PerformSearchTest(Element<int>[] elements, int n)
        {
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                int index = BinarySearch(elements, elementToSearch);
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
    }
}
