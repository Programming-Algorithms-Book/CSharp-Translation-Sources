namespace JumpSearch
{
    using System;
    using System.Text;

    public class JumpSearchAlgorithm
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 50;
        private const int NotFound = -1;
        private const int Step = 10;

        // Генератор на произволни числа.
        private static Random random = new Random();

        public static void PerformSearchTest(Element<int>[] elements)
        {
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                int index = JumpSearch(elements, elementToSearch, Step);
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
                int randomNumber = random.Next(0, 2 * MaxValue);

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

        private static int JumpSearch(Element<int>[] elements, int keyToSearch, int step)
        {
            int i;
            for (i = 0; i < elements.Length && elements[i].Key < keyToSearch; i += step)
            {
            }

            int leftIndex = (i + 1 < step) ? 0 : (i + 1 - step);
            int rightIndex = (elements.Length < i) ? (int)elements.Length : i;
            return SequentSearch(elements, leftIndex, rightIndex, keyToSearch);
        }

        private static int SequentSearch(Element<int>[] elements, int leftIndex, int rightIndex, int keyToSearch)
        {
            while (leftIndex < rightIndex)
            {
                if (elements[leftIndex].Key == keyToSearch)
                {
                    return leftIndex;
                }

                leftIndex++;
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
    }
}
