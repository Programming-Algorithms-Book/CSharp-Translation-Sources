using System;
using System.Text;

class SeqentialSearchAlgorithm
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

    static int SequentialSearch(Element<int>[] elements, int keyToSearch)
    {
        int i;
        for (i = elements.Length - 1; i > -1 && keyToSearch != elements[i].Key ; i--) ;
        return i;
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

    static void PerformSearchTest(Element<int>[] elements)
    {
        int index;
        for (int elementToSearch = 0; elementToSearch < 2 * MaxValue; elementToSearch++)
        {
            Console.WriteLine("Търсим елемент с ключ {0}.", elementToSearch);
            index = SequentialSearch(elements, elementToSearch);
            if (index == -1)
                Console.WriteLine("Елемент с такъв ключ не съществува!");
            else
                Console.WriteLine("Елементът е намерен! Стойност на инф. част: {0}.", index);
        }
    }

    static void Main()
    {
        Element<int>[] elements = new Element<int>[MaxValue];
        for (int index = 0; index < MaxValue; index++)       // Инициализация на масив със записи.
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

