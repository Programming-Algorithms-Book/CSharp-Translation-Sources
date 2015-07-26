namespace CombSort
{
    using System;
    using System.Text;

    public class CombSorter
    {
        private const int MaxValue = 100;
        private static readonly Random Rand = new Random();

        public static void Initialize(Element[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                array[i].Key = Rand.Next() % n;
            }
        }

        public static void CombSort(Element[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(
                    nameof(array), 
                    "Input array must not be null");
            }

            int n = array.Length;
            int gap = array.Length, s;
            do
            {
                s = 0;
                gap = (int)(gap / 1.3);
                if (gap < 1)
                {
                    gap = 1;
                }

                for (int i = 0; i < n - gap; i++)
                {
                    int j = i + gap;
                    if (array[i].Key > array[j].Key)
                    {
                        Swap(ref array[i], ref array[j]);
                        s++;
                    }
                }
            }
            while (s != 0 || gap == 0);
        }

        internal static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Element[] array = new Element[MaxValue];
            Element[] saveArray = new Element[MaxValue];
            Initialize(array);
            Array.Copy(array, saveArray, array.Length); /* Запазва се копие на масива */
            Console.WriteLine("Масивът преди сортирането");
            Print(array);
            CombSort(array);
            Console.WriteLine("Масивът след сортирането");
            Print(array);
        }

        private static void Swap(ref Element element1, ref Element element2)
        {
            Element tempElement = element1;
            element1 = element2;
            element2 = tempElement;
        }

        private static void Print(Element[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i].Key);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}