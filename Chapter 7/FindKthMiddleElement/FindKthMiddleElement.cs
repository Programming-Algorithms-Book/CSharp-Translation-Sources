using System;

internal class FindKthMiddleElement
{
    private static readonly Random rand = new Random();

    private static void InitializeArray(int[] array) /* Запълва масива със случайни числа */
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next()%(2*array.Length + 1);
        }
    }

    public static void PrintArray(int[] numbers) /* Извежда масива на екрана */
    {
        foreach (int number in numbers)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();
    }

    public static void Swap(ref int element1, ref int element2) /* Разменя стойностите на две променливи */
    {
        int temp = element1;
        element1 = element2;
        element2 = temp;
    }

    public static void FindKthElement(int[] array, int n, int k)
    {
        int left = 0;
        int right = n - 1;

        while (left < right)
        {
            int x = array[k];
            int i = left;
            int j = right;

            while (true)
            {
                while (x > array[i]) i++;
                while (x < array[j]) j--;
                if (i > j)
                    break;

                Swap(ref array[i], ref array[j]);
                i++;
                j--;
            }
            if (j < k)
                left = i;
            if (k < i)
                right = j;
        }
    }

    private static void Main()
    {
        int n = 10; /* Брой елементи в масива */
        int k = 4; /* Пореден номер на търсения елемент */

        int[] array = new int[n];
        InitializeArray(array);
        Console.WriteLine("Масивът преди търсенето: ");
        PrintArray(array);

        Console.WriteLine("\nТърсим k-ия елемент: k={0}", k);
        FindKthElement(array, n, k);
        Console.WriteLine("\nМасивът след търсенето:");
        PrintArray(array);

        Console.WriteLine("\nk-ият елемент е: {0}", array[k]);
    }
}