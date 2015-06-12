namespace RadixSort
{
    using System;
    using System.Diagnostics;

    public class RadixSort
    {
        private const int Max = 100;
        private const int Pow2 = 4; // Броя битове - дължината на нашата група (Степен на двойката)
        private const int BitsCount = 32; // Броя битове на int в C#

        private static readonly Random Random = new Random();

        internal static void Main()
        {
            CustomElement[] elements = Init(Max);
            Console.WriteLine("Масивът преди сортирането:");
            Print(elements);

            elements = SortRadix(elements);
            Console.WriteLine("Масивът след сортирането:");
            Print(elements);

            Check(elements);
        }

        private static CustomElement[] Init(int n)
        {
            CustomElement[] elements = new CustomElement[n];

            for (int i = 0; i < n; i++)
            {
                CustomElement currentElement = new CustomElement
                {
                    Key = Random.Next()
                };

                elements[i] = currentElement;
            }

            return elements;
        }

        private static CustomElement[] SortRadix(CustomElement[] elements)
        {
            // Допълнителен помощен масив
            CustomElement[] helper = new CustomElement[elements.Length];

            // Масив брояч и масив с префикси
            int[] count = new int[1 << Pow2];
            int[] prefixes = new int[1 << Pow2];

            // Брой групи 
            int groups = (int)Math.Ceiling((double)BitsCount / (double)Pow2);

            // Битова маска за идентифициране на групи
            int mask = (1 << Pow2) - 1;

            // Алгоритъмът 
            for (int c = 0, shiftRight = 0; c < groups; c++, shiftRight += Pow2)
            {
                // Нулиране на масива брояч
                for (int j = 0; j < count.Length; j++)
                {
                    count[j] = 0;
                }

                // Изброяване на елементите в C-тата група
                for (int i = 0; i < elements.Length; i++)
                {
                    count[(elements[i].Key >> shiftRight) & mask]++;
                }

                // Изчисляване на префиксите
                prefixes[0] = 0;
                for (int i = 1; i < count.Length; i++)
                {
                    prefixes[i] = prefixes[i - 1] + count[i - 1];
                }

                // Прехвърляне на елементите от основния в 
                // спомагателния масив подредени по C-тата група
                for (int i = 0; i < elements.Length; i++)
                {
                    helper[prefixes[(elements[i].Key >> shiftRight) & mask]++] = elements[i];
                }

                // Копиране на спомагателния масив в основния
                // и започване отначало до последната група
                helper.CopyTo(elements, 0);
            }

            // Масивът е сортиран
            return elements;
        }

        private static void Print(CustomElement[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write("{0} ", elements[i].Key);
            }

            Console.WriteLine();
        }

        // TODO: Transfer to unit tests
        private static void Check(CustomElement[] elements)
        {
            // 1. Проверка за наредба във възходящ ред
            for (int i = 0; i < elements.Length - 1; i++)
            {
                Debug.Assert(elements[i].Key <= elements[i + 1].Key, "Wrong order");
            }

            // 2. Проверка за пермутация на изходните елементи
            bool[] found = new bool[elements.Length];

            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length; j++)
                {
                    if (!found[j] && elements[i].Key == elements[j].Key)
                    {
                        found[j] = true;
                        break;
                    }

                    // Пропада, ако не е намерен съответен
                    Debug.Assert(j < elements.Length, "No element found");
                }
            }
        }
    }
}
