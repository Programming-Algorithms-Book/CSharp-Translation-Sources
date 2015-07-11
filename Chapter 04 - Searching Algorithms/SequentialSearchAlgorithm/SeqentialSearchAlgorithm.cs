namespace SequentialSearchAlgorithm
{
    using System;
    using System.Text;

    public class SeqentialSearchAlgorithm
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 50;

        // Генератор на произволни числа.
        private static readonly Random Random = new Random();

        public static void PerformSearchTest(Element<int>[] elements)
        {
            int index;
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                index = SequentialSearch(elements, elementToSearch);
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
            Element<int>[] elements = new Element<int>[MaxValue];

            // Инициализация на масив със записи.
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

        private static int SequentialSearch(Element<int>[] elements, int keyToSearch)
        {
            int i;
            for (i = elements.Length - 1; i > -1 && keyToSearch != elements[i].Key; i--)
            {
            }

            return i;
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
