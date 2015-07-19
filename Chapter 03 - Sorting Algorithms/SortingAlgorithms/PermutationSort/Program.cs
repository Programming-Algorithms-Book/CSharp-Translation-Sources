namespace PermutationSort
{
    using System;
    using System.Text;

    public class PermutationSort
    {
        private const int Max = 100;
        private const int TestLoopCount = 100;

        private static readonly Random Rand = new Random();

        internal static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Element[] array = new Element[Max];
            Element[] arrayCopy = new Element[Max];

            for (int loopInd = 1; loopInd <= TestLoopCount; loopInd++)
            {
                Console.WriteLine("<<<<< Тест {0} >>>>>", loopInd);
                Init(array, Max);
                for (int p = 0; p < array.Length; p++)
                {
                    arrayCopy[p] = array[p];
                }

                Console.WriteLine("Масивът преди сортирането:");
                Print(array, Max);
                PermSort(array, Max);
                Console.WriteLine("Масивът след сортирането:");
                Print(array, Max);

                bool testPassed = Check(array, arrayCopy, Max);
                if (!testPassed)
                {
                    Console.WriteLine("Масивът не е сортиран.");
                    return;
                }
            }
        }

        private static void Swap(ref Element first, ref Element second)
        {
            Element temp = first;
            first = second;
            second = temp;
        }

        /* Запълва масива със случайни цели числа */
        private static void Init(Element[] array, int elementsCount)
        {
            for (int i = 0; i < elementsCount; i++)
            {
                array[i].Key = i;
            }

            for (int i = 0; i < elementsCount; i++)
            {
                Swap(ref array[i], ref array[Rand.Next() % elementsCount]);
            }
        }

        private static void PermSort(Element[] array, int elementsCount)
        {
            for (int i = 0; i < elementsCount; i++)
            {
                while (array[i].Key != i)
                {
                    Swap(ref array[i], ref array[array[i].Key]);
                }
            }
        }

        private static void Print(Element[] array, int elementsCount)
        {
            for (int i = 0; i < elementsCount; i++)
            {
                Console.Write("{0} ", array[i].Key);
            }

            Console.WriteLine();
        }

        private static bool Check(Element[] array, Element[] arrayCopy, int elementsCount)
        {
            bool[] found = new bool[elementsCount + 1];

            /* 1. Проверка за наредба във възходящ ред */
            for (int i = 0; i < elementsCount - 1; i++)
            {
                if (array[i].Key > array[i + 1].Key)
                {
                    return false;
                }
            }

            /* 2. Проверка за пермутация на изходните елементи */
            for (int i = 0; i < elementsCount; i++)
            {
                int j;
                for (j = 0; j < elementsCount; j++)
                {
                    if (!found[j] && array[i].Key == arrayCopy[j].Key)
                    {
                        found[j] = true;
                        break;
                    }
                }

                if (j >= elementsCount)
                {
                    return false;   /* Пропада, ако не е намерен съответен */
                }
            }

            return true;
        }
    }
}
