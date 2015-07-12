namespace MergeSorter
{
    using System;

    public class MergeSorter
    {
        /* Брой елементи за сортиране */
        private const int N = 100;

        internal static void Main()
        {
            /* Основен масив - за сортиране */
            int[] a = new int[N];

            /* Помощен масив */
            int[] b = new int[N];
            Generate(a);
            Console.WriteLine("Преди сортирането:");
            PrintArray(a);
            Console.WriteLine();
            MergeSort(a, b, 0, N - 1);
            Console.WriteLine("След сортирането:");
            PrintArray(a);
        }

        /* Генерира примерно множество */
        private static void Generate(int[] array)
        {
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next() % ((2 * N) + 1);
            }
        }

        /* Извежда списъка на екрана */
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < N; ++i)
            {
                Console.Write("{0,4}", array[i]);
            }
        }

        /* Сортиране */
        private static void MergeSort(int[] a, int[] b, int left, int right)
        {
            if (right <= left)
            {
                /* Проверка дали има какво да се сортира */
                return;
            }

            int mid = (right + left) / 2;

            /* Сортиране на левия дял */
            MergeSort(a, b, left, mid);

            /* Сортиране на десния дял */
            MergeSort(a, b, mid + 1, right);

            /* Копиране на елементите на a[] в помощния масив b[] */
            int i, j;
            for (i = mid + 1; i > left; i--)
            {
                /* Права посока */
                b[i - 1] = a[i - 1];
            }

            for (j = mid; j < right; j++)
            {
                /* Обратна посока */
                b[right + mid - j] = a[j + 1];
            }

            /* Сливане на двата масива в a[] */
            for (int k = left; k <= right; k++)
            {
                a[k] = (b[i] < b[j]) ? b[i++] : b[j--];
            }
        }
    }
}