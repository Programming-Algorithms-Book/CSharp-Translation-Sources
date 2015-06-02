using System;
using System.Text;

class JumpSearchAlgorithm
{
    public class Element<T>
    {
        public int Key { get; set; }
        public T Value { get; set; }

        public Element(int key, T value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    static Random random = new Random();         // Генератор на произволни числа.
    const int MaxValue = 50;              // Максимална стойност на елементите от масива.
    const int NotFound = -1;
    const int Step = 10;

    static void SortElementsArray(Element<int>[] elements)        // Сортира елементите в масива.
    {
        for (int i = 0; i < elements.Length; i++)
            for (int j = 0; j < elements.Length; j++)
                if (elements[i].Key < elements[j].Key)
                {
                    var swapElement = elements[i];
                    elements[i] = elements[j];
                    elements[j] = swapElement;
                }
    }

    static int JumpSearch(Element<int>[] elements, int keyToSearch, int step)
    {
        int i;
        for (i = 0; i < elements.Length && elements[i].Key < keyToSearch; i += step) ;
        int leftIndex = (i + 1 < step) ? 0 : (i + 1 - step);
        int rightIndex = (elements.Length < i) ? (int)elements.Length : i;
        return SequentSearch(elements, leftIndex, rightIndex, keyToSearch);
    }

    static int SequentSearch(Element<int>[] elements, int leftIndex, int rightIndex, int keyToSearch)
    {
        while (leftIndex < rightIndex)
        {
            if (elements[leftIndex].Key == keyToSearch)
                return leftIndex;
            leftIndex++;
        }
        return NotFound;
    }

    static void PrintElements(Element<int>[] elements)        // Принтира елементите на масива върху конзолата.
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < elements.Length; i++)
        {
            output.Append(elements[i].Value);
            if (i < elements.Length - 1)
                output.Append(",");
        }
        Console.WriteLine(output.ToString());
    }

    public static void PerformSearchTest(Element<int>[] elements)
    {
        int index;
        for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
        {
            Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
            index = JumpSearch(elements, elementToSearch, Step);
            if (index == -1)
                Console.WriteLine("Елемент с такъв ключ не съществува!");
            else
                Console.WriteLine("Елементът е намерен! Стойност на инф. част: {0}.", index);
        }
    }

    static void Main()
    {                                                    // Брой елементи в масива.
        Element<int>[] elements = new Element<int>[MaxValue];                  // Инициализация на масив със записи.
        for (int index = 0; index < MaxValue; index++)
        {
            int randomNumber = random.Next(0, 2 * MaxValue);
            elements[index] = new Element<int>(randomNumber, index);     // Пълнене на масива с произволни числа.
        }

        SortElementsArray(elements);

        Console.WriteLine("Списъкът съдържа следните елементи: ");
        PrintElements(elements);

        Console.WriteLine("\nТестване:");
        PerformSearchTest(elements);
    }
}

