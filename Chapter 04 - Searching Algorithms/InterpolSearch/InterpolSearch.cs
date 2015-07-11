namespace InterpolSearch
{
    using System;
    using System.Text;

    public class InterpolationSearch
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 50;
        private const int NotFound = -1;

        // Генератор на произволни числа.
        private static readonly Random Random = new Random();

        public static void PerformSearchTest(Element<int>[] elements)
        {
            int index;
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                index = InterpolSearch(elements, elementToSearch);
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

        private static int InterpolSearch(Element<int>[] elements, int keyToSearch)
        {
            int leftIndex = 0;
            int rightIndex = elements.Length - 1;
            while (leftIndex <= rightIndex)
            {
                if (elements[rightIndex].Key == elements[leftIndex].Key)
                {
                    if (elements[leftIndex].Key == keyToSearch)
                    {
                        return leftIndex;
                    }
                    else
                    {
                        return NotFound;
                    }
                }

                float interpolCoefficent = (float)(keyToSearch - elements[leftIndex].Key)
                                           / (elements[rightIndex].Key - elements[leftIndex].Key);
                if (interpolCoefficent < 0 || interpolCoefficent > 1)
                {
                    return NotFound;
                }

                int midIndex = (int)(leftIndex + (interpolCoefficent * (rightIndex - leftIndex)) + 0.5);
                if (keyToSearch < elements[midIndex].Key)
                {
                    rightIndex = midIndex - 1;
                }
                else if (keyToSearch > elements[midIndex].Key)
                {
                    leftIndex = midIndex + 1;
                }
                else
                {
                    return midIndex;
                }
            }

            return NotFound;
        }

        // Принтира елементите на масива върху конзолата.
        private static void PrintElements(Element<int>[] elements)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < elements.Length; i++)
            {
                output.Append(elements[i].ToString());
                if (i < elements.Length - 1)
                {
                    output.Append(",");
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
