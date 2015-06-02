using System;
using System.Diagnostics;

struct Element
{
    public int Key { get; set; }
    /* .............
        Някакви данни
        ............. */
}

class List
{
    public Element Data { get; set; }
    public List Next { get; set; }
}

class CountSorter2
{
    static Random rand = new Random();
    private const int MaxValue = 100;

    static void Initialize(Element[] array)
    {
        for (int i = 0; i < array.Length; i++)
            array[i].Key = rand.Next() % MaxValue;
    }

    static void Print(Element[] array)
    {
        for (int i = 0; i < array.Length; i++)
            Console.Write("{0} ", array[i].Key);
        Console.WriteLine();
    }

    static void CountSort(Element[] array)
    {
        List[] list = new List[MaxValue];

        /* 1. Разпределяне на елементите по списъци */
        for (int i = 0; i < MaxValue; i++)
            list[i] = null;

        /* 1.2. Добавяне на елемента в началото на списъка */
        List p;
        for (int i = 0; i < array.Length; i++)
        {
            p = new List();
            p.Data = array[i];
            p.Next = list[array[i].Key];
            list[array[i].Key] = p;
        }

        /* 2. Извеждане на ключовете на сортираната последователност */
        for (int i = 0, j = 0; i < MaxValue; i++)
            while ((p = list[i]) != null)
            {
                array[j++] = list[i].Data;
                list[i] = list[i].Next;
            }
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
            Debug.Assert(j < array.Length); /* Пропада, ако не е намерен съответен */
        }
    }

    static void Main()
    {
        Element[] array = new Element[MaxValue];
        Element[] saveArray = new Element[MaxValue];
        Initialize(array);
        Array.Copy(array, saveArray, array.Length); /* Запазва се копие на масива */
        Console.WriteLine("Масивът преди сортирането");
        Print(array);
        CountSort(array);
        Console.WriteLine("Масивът след сортирането");
        Print(array);

        Check(array, saveArray);
    }
}