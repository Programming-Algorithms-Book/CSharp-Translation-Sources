namespace ReorderSearchingAlgorithm
{
    using System;
    using System.Text;

    public class ReorderAlgorithm
    {
        // Максимална стойност на елементите от масива.
        private const int MaxValue = 50;

        // Генератор на произволни числа.
        private static readonly Random Random = new Random();
        private static Element<int> head;

        public static void PerformSearchTest()
        {
            Element<int> current = null;
            for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
            {
                Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
                current = ListSearch(elementToSearch);
                if (current == null)
                {
                    Console.WriteLine("Елемент с такъв ключ не съществува!");
                }
                else
                {
                    Console.WriteLine("Елементът е намерен! Стойност на инф. част: {0}.", current.Value);
                }
            }
        }

        internal static void Main()
        {
            Element<int> previous = null;
            for (int index = 0; index < MaxValue; index++)
            {
                // Пълнене на списъка с произволни числа.
                int randomNumber = Random.Next(0, 2 * MaxValue);
                Element<int> element = new Element<int>(randomNumber, index);
                if (index == 0)
                {
                    head = element;
                }
                else
                {
                    previous.Next = element;
                }

                previous = element;
            }

            Console.WriteLine("Списъкът съдържа следните елементи: ");
            PrintElements();

            Console.WriteLine("\nТестване:");
            PerformSearchTest();
        }

        private static Element<int> ListSearch(int keyToSearch)
        {
            Element<int> current = null;
            Element<int> previous = head;
            if (previous == null)
            {
                return null;
            }

            if (previous.Key == keyToSearch)
            {
                return previous;
            }

            for (current = head.Next; current != null;)
            {
                if (current.Key != keyToSearch)
                {
                    previous = current;
                    current = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                    current.Next = head;
                    head = current;
                    return head;
                }
            }

            return null;
        }

        // Принтира елементите на масива върху конзолата.
        private static void PrintElements()
        {
            StringBuilder output = new StringBuilder();
            Element<int> currentElement = head;
            while (currentElement != null)
            {
                output.Append(currentElement.Value);
                if (currentElement.Next != null)
                {
                    output.Append(",");
                }

                currentElement = currentElement.Next;
            }

            Console.WriteLine(output.ToString());
        }
    }
}
