using System;
using System.Diagnostics;

struct Element
{
    public int Key { get; set; }
}

class HeapSort
{
    static Random rand = new Random();
    private const int MaxValue = 100;

    static void Swap(ref Element element1, ref Element element2)
    {
        Element tempElement = element1;
        element1 = element2;
        element2 = tempElement;
    }

    static void Initialize(Element[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
            array[i].Key = rand.Next() % n;
    }

    private static void Sift(Element[] array, int left, int right)
    {
        int i = left;
        int j = i * 2 + 1;
        Element temp = array[i];
        while (j <= right)
        {
            if (j < right)
                if (array[j].Key < array[j + 1].Key)
                    j++;
            if (temp.Key < array[j].Key)
            {
                array[i] = array[j];
                i = j;
                j = 2 * i + 1;
            }
            else
            {
                j = right + 1;
            }
        }
        array[i] = temp;
    }

    private static void HeapSortArray(Element[] array)
    {
        int n = array.Length;
        int k;
        /* 1. Построяване на пирамидата */
        for (k = (n - 1) / 2; k >= 0; k--)
            Sift(array, k, n - 1);

        /* 2. Построяване на сортирана последователност */
        for (k = n - 1; k >= 1; k--)
        {
            Swap(ref array[0], ref array[k]);
            Sift(array, 0, k - 1);
        }
    }

    static void Print(Element[] array)
    {
        for (int i = 0; i < array.Length; i++)
            Console.Write("{0} ", array[i].Key);
        Console.WriteLine();
    }

    static void Check(Element[] array, Element[] coppiedArray)
    {
        /* 1. Проверка за наредба във възходящ ред */
        for (int i = 0; i < array.Length - 1; i++)
            Debug.Assert(array[i].Key <= array[i + 1].Key);

        /* 2. Проверка за пермутация на изходните елементи */
        bool[] found = new bool[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            int j;
            for (j = 0; j < array.Length; j++)
                if (!found[j] && array[i].Equals(coppiedArray[j]))
                {
                    found[j] = true;
                    break;
                }
            Debug.Assert(j <= array.Length); /* Пропада, ако не е намерен съответен */
        }
    }

    static void Main()
    {
        Element[] array = new Element[MaxValue];
        Element[] saveArray = new Element[MaxValue];
        Array.Copy(array, saveArray, array.Length); /* Запазва се копие на масива */
            
        Initialize(array);
        Console.WriteLine("Масивът преди сортирането");
        Print(array);
        HeapSortArray(array);
        Console.WriteLine("Масивът след сортирането");
        Print(array);

        Check(array, saveArray);
    }
}