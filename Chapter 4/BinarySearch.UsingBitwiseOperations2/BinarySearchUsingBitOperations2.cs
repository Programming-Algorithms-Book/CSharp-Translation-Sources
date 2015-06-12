namespace BinarySearch.UsingBitwiseOperations2
{
    using System;
    using System.Text;

    public class BinarySearchUsingBitOperations2
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 50;
        private const int NotFound = -1;

        // Генератор на произволни числа.
        private static readonly Random Random = new Random();

        // Сортира елементите в масива.
        public static void SortElementsArray(Element<int>[] elements)
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

        internal static void Main()
        {
            // Брой елементи в масива.
            int n = MaxValue;

            // Инициализация на масив със записи.
            Element<int>[] elements = new Element<int>[n];
            for (int index = 0; index < n; index++)
            {
                int randomNumber = Random.Next(0, 2 * MaxValue);
                if (randomNumber == 99)
                {
                    Console.WriteLine("99");
                }

                // Пълнене на масива с произволни числа.
                elements[index] = new Element<int>(randomNumber, index);
            }

            SortElementsArray(elements);

            Console.WriteLine("Списъкът съдържа следните елементи: ");
            PrintElements(elements);

            Console.WriteLine("\nТестване:");
            PerformSearchTest(elements, n);
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

        // Извърша двоично търсене.
        private static int BinarySearch(Element<int>[] elements, int keyToSearch)
        {
            int index = GetMaxPower(elements.Length);
            int leftIndex;
            if (elements[index].Key >= keyToSearch)
            {
                leftIndex = 0;
            }
            else
            {
                leftIndex = elements.Length - index + 1;
            }

            while (index > 1)
            {
                index >>= 1;
                if (index + leftIndex < elements.Length
                    && elements[leftIndex + index].Key < keyToSearch)
                {
                    leftIndex += index;
                }
            }

            if (leftIndex + 1 < MaxValue && elements[leftIndex + 1].Key == keyToSearch)
            {
                return leftIndex + 1;
            }

            return NotFound;
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
