namespace BinarySearch.UsingBitwiseOperations
{
    using System;
    using System.Text;

    public class BinarySearchUsingBitOperations
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 50;
        private const int NotFound = -1;

        // Генератор на произволни числа.
        private static readonly Random Random = new Random();

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

        private static int GetMaxPower(int number)
        {
            int power = 1;
            while (power <= number)
            {
                power <<= 1;
            }

            power >>= 1;
            return power;
        }

        private static int BinarySearch(Element<int>[] elements, int elementToSearch)     // Извърша двоично търсене.
        {
            int power = GetMaxPower(elements.Length);
            int leftIndex;
            if (elements[power].Key >= elementToSearch)
            {
                leftIndex = 0;
            }
            else
            {
                leftIndex = elements.Length - power + 1;
            }

            int index;
            int result = NotFound;
            while (power > 0)
            {
                power >>= 1;
                index = leftIndex + power;
                if (index >= elements.Length)
                {
                    break;
                }

                if (elements[index].Key == elementToSearch)
                {
                    result = index;
                    break;
                }
                else if (elements[index].Key < elementToSearch)
                {
                    leftIndex = index;
                }
            }

            return result;
        }

        private static void PrintElements(Element<int>[] elements)        // Принтира елементите на масива върху конзолата.
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
            int index;
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                index = BinarySearch(elements, elementToSearch);
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
