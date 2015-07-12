namespace FindKElement
{
    using System;

    public class FindKElement
    {
        private static readonly Random Rand = new Random();
        private static readonly int[] Array = new int[10];

        internal static void Main()
        {
            InitializeArray();
            Console.WriteLine("Масивът: {0}", string.Join(" ", Array));

            int k = 5;

            /* Пореден номер на търсения елемент */
            HeapFindKthElement(k);
            Console.WriteLine("\n K-тия елемент е: {0}", string.Join(" ", Array[0]));
        }

        /* Запълва масива със случайни числа */
        private static void InitializeArray()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = Rand.Next(int.MaxValue) % ((2 * Array.Length) + 1);
            }
        }

        /* Търсене на k-ия елемент с пирамида */
        private static void HeapFindKthElement(int k)
        {
            /* Брой елементи в масива */
            int n = Array.Length;
            bool useMax = k > n / 2;
            if (useMax)
            {
                k = n - k - 1;
            }

            int left = n / 2;
            int right = n - 1;

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

        /* Отсява елем. от върха на пирамидата */
        private static void SiftMax(int left, int right)
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

        /* Отсява елем. от върха на пирамидата */
        private static void SiftMin(int left, int right)
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
    }
}