namespace FindKElement
{
    using System;

    public class FindKElement
    {
        private static readonly Random Rand = new Random();
        private static readonly int[] Array = new int[10];

        private static void InitializeArray() /* Запълва масива със случайни числа */
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = Rand.Next(int.MaxValue) % ((2 * Array.Length) + 1);
            }
        }

        private static void HeapFindKthElement(int k) /* Търсене на k-ия елемент с пирамида */
        {
            int n = Array.Length; /* Брой елементи в масива */
            int left, right;
            bool useMax = k > n / 2;
            if (useMax)
            {
                k = n - k - 1;
            }

            left = n / 2;
            right = n - 1;

            /* Построяване на пирамидата */
            while (left > 0)
            {
                left--;
                if (useMax)
                {
                    SiftMax(left, right);
                }
                else
                {
                    SiftMin(left, right);
                }
            }

            /* (k-1)-кратно премахване на минималния елемент */
            for (right = n - 1; right >= n - k; right--)
            {
                Array[0] = Array[right];
                if (useMax)
                {
                    SiftMax(0, right);
                }
                else
                {
                    SiftMin(0, right);
                }
            }
        }

        private static void SiftMax(int left, int right) /* Отсява елем. от върха на пирамидата */
        {
            int i = left;
            int j = i + i + 1;
            int x = Array[i];
            while (j <= right)
            {
                if (j < right)
                {
                    if (Array[j] < Array[j + 1])
                    {
                        j++;
                    }
                }

                if (x >= Array[j])
                {
                    break;
                }

                Array[i] = Array[j];
                i = j;
                j = (j * 2) + 1;
            }

            Array[i] = x;
        }

        private static void SiftMin(int left, int right) /* Отсява елем. от върха на пирамидата */
        {
            int i = left;
            int j = i + i + 1;
            int x = Array[i];
            while (j <= right)
            {
                if (j < right)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        j++;
                    }
                }

                if (x <= Array[j])
                {
                    break;
                }

                Array[i] = Array[j];
                i = j;
                j = (j * 2) + 1;
            }

            Array[i] = x;
        }

        private static void Main()
        {
            InitializeArray();
            Console.WriteLine("Масивът: {0}", string.Join(" ", Array));

            int k = 5;
            HeapFindKthElement(k); /* Пореден номер на търсения елемент */
            Console.WriteLine("\n K-тия елемент е: {0}", string.Join(" ", Array[0]));
        }
    }
}