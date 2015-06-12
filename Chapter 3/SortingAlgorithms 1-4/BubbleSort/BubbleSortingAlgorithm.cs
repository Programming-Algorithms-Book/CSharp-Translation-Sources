namespace BubbleSort
{
    using System;

    public class BubbleSortingAlgorithm
    {
        private const int MaxValue = 100;
        private const int TestsCount = 100;
        private static readonly Random Rand = new Random();

        internal static void Main()
        {
            Element[] elements = new Element[MaxValue];
            for (int i = 0; i < TestsCount; i++)
            {
                Console.WriteLine("----------Тест " + i + "----------");
                Initialize(elements);
                Console.WriteLine("Масив преди сортиране : ");
                PrintElements(elements);
                BubbleSort(elements);
                Console.WriteLine("Масив след сортиране : ");
                PrintElements(elements);
                Check(elements);
            }
        }

        private static void Initialize(Element[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = new Element();
                elements[i].Key = Rand.Next(0, MaxValue * 2);
            }
        }

        private static void SwapValues(ref Element first, ref Element second)
        {
            Element swapper = first;
            first = second;
            second = swapper;
        }

        private static void BubbleSort(Element[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = elements.Length - 1; j > i; j--)
                {
                    if (elements[j - 1].Key > elements[j].Key)
                    {
                        SwapValues(ref elements[j - 1], ref elements[j]);
                    }
                }
            }
        }

        private static void PrintElements(Element[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(elements[i].Key + " ");
            }

            Console.WriteLine();
        }

        private static void Check(Element[] elements)
        {
            bool isSorted = true;
            for (int i = 0; i < elements.Length - 1; i++)
            {
                if (elements[i].Key > elements[i + 1].Key)
                {
                    isSorted = false;
                    break;
                }
            }

            if (!isSorted)
            {
                throw new Exception("Масива не е сортиран правилно.");
            }
        }
    }
}
