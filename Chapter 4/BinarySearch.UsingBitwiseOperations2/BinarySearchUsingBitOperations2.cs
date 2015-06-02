using System;
using System.Text;

//binsear3.c
class BinarySearchUsingBitOperations2
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

    public static Random random = new Random();         // Генератор на произволни числа.
    public const int MaxValue = 50;                    // Максимална стойност на елементите от масива.
    const int NotFound = -1;

    public static void SortElementsArray(Element<int>[] elements)        // Сортира елементите в масива.
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

    public static int GetMaxPower(int number)
    {
        int power = 1;
        while (power <= number)
            power <<= 1;
        power >>= 1;
        return power;
    }

    static int BinarySearch(Element<int>[] elements, int keyToSearch)     // Извърша двоично търсене.
    {
        int index = GetMaxPower(elements.Length);
        int leftIndex;
        if (elements[index].Key >= keyToSearch)
            leftIndex = 0;
        else
            leftIndex = elements.Length - index + 1;
        while (index > 1)
        {
            index >>= 1;
            if (index + leftIndex < elements.Length
                && elements[leftIndex + index].Key < keyToSearch)
                leftIndex += index;
        }
        if (leftIndex + 1 < MaxValue && elements[leftIndex + 1].Key == keyToSearch)
            return leftIndex + 1;
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

    static void PerformSearchTest(Element<int>[] elements, int n)
    {
        int index;
        for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
        {
            Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
            index = BinarySearch(elements, elementToSearch);
            if (index == NotFound)
                Console.WriteLine("Елемент с такъв ключ не съществува!");
            else
                Console.WriteLine("Елементът е намерен! Стойност на инф. част: {0}.", index);
        }
    }

    static void Main()
    {
        int n = MaxValue;                                                    // Брой елементи в масива.
        Element<int>[] elements = new Element<int>[n];                  // Инициализация на масив със записи.
        for (int index = 0; index < n; index++)
        {
            int randomNumber = random.Next(0, 2 * MaxValue);
            if (randomNumber == 99)
            {
                Console.WriteLine("99");
            }
            elements[index] = new Element<int>(randomNumber, index);     // Пълнене на масива с произволни числа.
        }

        SortElementsArray(elements);

        Console.WriteLine("Списъкът съдържа следните елементи: ");
        PrintElements(elements);

        Console.WriteLine("\nТестване:");
        PerformSearchTest(elements, n);
    }
}
