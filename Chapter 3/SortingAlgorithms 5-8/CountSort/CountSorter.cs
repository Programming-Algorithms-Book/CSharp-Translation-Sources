using System;
using System.Diagnostics;

class CountSorter
{
    private static Random rand = new Random();
    private const int MaxValue = 100;

    static void InitializeArray(uint[] array)
    {
        int n = array.Length;
        for (uint i = 0; i < n; i++)
        {
            int randomNumber = rand.Next(0, MaxValue);
            array[i] = (uint)(randomNumber % n);
        }
    }

    static void CountSort(uint[] array) /* Сортира чрез броене */
    {
        uint[] counter = new uint[MaxValue];
        int n = array.Length;
        /* 0. Инициализиране на множеството */
        for (int i = 0; i < MaxValue; i++)
            counter[i] = 0;

        for (int j = 0; j < n; j++)
            counter[array[j]]++;

        for (uint i = 0, j = 0; i < MaxValue; i++)
            while (counter[i]-- > 0)
                array[j++] = i;
    }

    static void PrintArray(uint[] array)
    {
        for (int i = 0; i < array.Length; i++)
            Console.Write("{0} ", array[i]);
        Console.WriteLine();
    }

    static void Check(uint[] array, uint[] coppiedArray)
    {
        /* 1. Проверка за наредба във възходящ ред */
        for (int i = 0; i < array.Length - 1; i++)
            Debug.Assert(array[i] <= array[i + 1]);

        /* 2. Проверка за пермутация на изходните елементи */
        bool[] found = new bool[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            int j;
            for (j = 0; j < array.Length; j++)
                if (!found[j] && array[i] == coppiedArray[j])
                {
                    found[j] = true;
                    break;
                }
            Debug.Assert(j < array.Length); /* Пропада, ако не е намерен съответен */
        }
    }

    static void Main()
    {
        uint[] array = new uint[MaxValue];
        InitializeArray(array);
        uint[] copiedArray = new uint[MaxValue];
        Array.Copy(array, copiedArray, array.Length); /* Запазва се копие на масива */
        Console.WriteLine("Масивът преди сортирането");
        PrintArray(array);
        CountSort(array);
        Console.WriteLine("Масивът след сортирането");
        PrintArray(array);

        Check(array, copiedArray);
    }
}