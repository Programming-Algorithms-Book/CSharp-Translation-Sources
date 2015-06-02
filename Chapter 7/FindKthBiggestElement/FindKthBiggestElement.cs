using System;

class FindKElement
{
    static readonly Random rand = new Random();
    static int[] array = new int[10];

    static void InitializeArray() /* Запълва масива със случайни числа */
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(int.MaxValue) % (2 * array.Length + 1);
        }
    }

    static void HeapFindKthElement(int k) /* Търсене на k-ия елемент с пирамида */
    {
        int n = array.Length; /* Брой елементи в масива */
        int left, right;
        bool useMax = (k > n/2);
        if (useMax)
            k = n - k - 1;

        left = n/2;
        right = n - 1;

        /* Построяване на пирамидата */
        while (left > 0)
        {
            left--;
            if (useMax) 
                SiftMax(left, right);
            else 
                SiftMin(left, right);
        }

        /* (k-1)-кратно премахване на минималния елемент */
        for (right = n - 1; right >= n - k; right--)
        {
            array[0] = array[right];
            if (useMax)
                SiftMax(0, right);
            else
                SiftMin(0, right);
        }
    }

    static void SiftMax(int left, int right) /* Отсява елем. от върха на пирамидата */
    {
        int i = left;
        int j = i + i + 1;
        int x = array[i];
        while (j <= right)
        {
            if (j < right)
            {
                if (array[j] < array[j +1])
                    j++;
            }
            if (x >= array[j])
                break;

            array[i] = array[j];
            i = j;
            j = j*2 + 1;
        }
        array[i] = x;
    }

    static void SiftMin(int left, int right) /* Отсява елем. от върха на пирамидата */
    {
        int i = left;
        int j = i + i + 1;
        int x = array[i];
        while (j <= right)
        {
            if (j < right)
            {
                if (array[j] > array[j + 1])
                    j++;
            }
            if (x <= array[j])
                break;

            array[i] = array[j];
            i = j;
            j = j*2 + 1;
        }
        array[i] = x;
    }

    static void Main()
    {
        InitializeArray();
        Console.WriteLine("Масивът: {0}", string.Join(" ", array));

        int k = 5;
        HeapFindKthElement(k); /* Пореден номер на търсения елемент */
        Console.WriteLine("\n K-тия елемент е: {0}", string.Join(" ", array[0]));
    }
}
