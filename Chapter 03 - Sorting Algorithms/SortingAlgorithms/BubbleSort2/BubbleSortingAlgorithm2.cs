namespace BubbleSort2
{
    using System;
    using System.Text;

    public class BubbleSortingAlgorithm2
    {
        private const int MaxValue = 100;
        private const int TestsCount = 100;
        private static readonly Random Rand = new Random();

        public static void Initialize(Element[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = new Element
                {
                    Key = Rand.Next(0, MaxValue * 2)
                };
            }
        }

        public static void BubbleSort(Element[] elements)
        {
            int k;
            for (int i = elements.Length - 1; i > 0; i = k)
            {
                for (int j = k = 0; j < i; j++)
                {
                    if (elements[j].Key > elements[j + 1].Key)
                    {
                        SwapValues(ref elements[j], ref elements[j + 1]);
                        k = j;
                    }
                }
            }
        }

        internal static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

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

        private static void SwapValues(ref Element first, ref Element second)
        {
            Element swapper = first;
            first = second;
            second = swapper;
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
