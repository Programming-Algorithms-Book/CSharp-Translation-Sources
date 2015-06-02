using System;

class insterts2
{
    struct Element
    {
        public int Key { get; set; }
        //  други данни
    }

    const int Max = 100;
    const int TestLoopCount = 100;

    static Random rand = new Random();

    /* Запълва масива със случайни цели числа */
    static void Init(Element[] array, int elementsCount)
    {
        for (int i = 0; i < elementsCount; i++)
        {
            array[i].Key = rand.Next() % elementsCount;
        }
    }

    static void StraightInsertion(Element[] array, int elementsCount)
    {
        Element x;
        int j;
        for (int i = 1; i <= elementsCount; i++)
        {
            x = array[i];
            array[0].Key = x.Key;
            for (j = i - 1; x.Key < array[j].Key; j--)
                array[j + 1] = array[j];
            array[j + 1] = x;
        }
    }

    static void Print(Element[] array, int elementsCount)
    {
        for (int i = 1; i <= elementsCount; i++)
        {
            Console.Write("{0} ", array[i].Key);
        }

        Console.WriteLine();
    }

    static bool Check(Element[] array, Element[] arrayCopy, int elementsCount)
    {
        bool[] found = new bool[elementsCount + 1];

        /* 1. Проверка за наредба във възходящ ред */
        for (int i = 1; i < elementsCount; i++)
            if (array[i].Key > array[i + 1].Key)
                return false;

        /* 2. Проверка за пермутация на изходните елементи */
        for (int i = 0; i < elementsCount; i++)
        {
            int j;
            for (j = 0; j < elementsCount; j++)
                if (!found[j] && array[i].Key == arrayCopy[j].Key)
                {
                    found[j] = true;
                    break;
                }

            if (j > elementsCount)
                return false;   /* Пропада, ако не е намерен съответен */
        }

        return true;
    }

    static void Main()
    {
        Element[] array = new Element[Max + 1];
        Element[] arrayCopy = new Element[Max + 1];

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
            StraightInsertion(array, Max);
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
}
