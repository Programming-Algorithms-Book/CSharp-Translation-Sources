using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibunacciSearch
{
    class FibSearch
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

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }

        static Random random = new Random();         // Генератор на произволни числа.
        const int MaxValue = 50;              // Максимална стойност на елементите от масива.
        static int n = 0;              // Брой елементи в масива
        const int NotFound = -1;
        static int[] fibunacciNumbers = new int[MaxValue]; // Числата на Фибоначи, ненадвишаващи n

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

        static int FibunacciSearch(Element<int>[] elements, int keyToSearch)
        {
            int third, second, first;
            int index = FindFibNumber(n);
            third = fibunacciNumbers[index - 1];
            second = fibunacciNumbers[index - 2];
            first = fibunacciNumbers[index - 3];
            if (keyToSearch > elements[index].Key)
                third += n - fibunacciNumbers[index] + 1;
            while (third > 0 && third < elements.Length)
                if (keyToSearch == elements[third].Key)
                    return third;
                else
                    if (keyToSearch < elements[third].Key)
                        if (0 == first)
                            third = 0;
                        else
                        {
                            int exchangeVariable;
                            third -= first;
                            exchangeVariable = second;
                            second = first;
                            first = exchangeVariable - first;
                        }
                    else
                        if (1 == second)
                            third = 0;
                        else
                        {
                            third += first;
                            second -= first;
                            first -= second;
                        }
            return NotFound;
        }

        static int FindFibNumber(int n)
        {
            fibunacciNumbers[0] = 0;
            fibunacciNumbers[1] = 1;
            int index = 2;
            while (true)
            {
                fibunacciNumbers[index] = fibunacciNumbers[index - 2] + fibunacciNumbers[index - 1];
                if (fibunacciNumbers[index] > n)
                    return (index - 1);
                index++;
            }
        }

        static void PrintElements(Element<int>[] elements)        // Принтира елементите на масива върху конзолата.
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < elements.Length; i++)
            {
                output.Append(elements[i].ToString());
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
                index = FibunacciSearch(elements, elementToSearch);
                if (index == -1)
                    Console.WriteLine("Елемент с такъв ключ не съществува!");
                else
                    Console.WriteLine("Елементът е намерен! Стойност на инф. част: {0}.", index);
            }
        }

        static void Main()
        {
            n = MaxValue;                                                   // Брой елементи в масива.
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
}
