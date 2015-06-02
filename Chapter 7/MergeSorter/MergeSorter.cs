using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSorter
{
    class MergeSorter
    {
        const int n = 100; /* Брой елементи за сортиране */

        static void Main()
        {
            int[] a = new int[n]; /* Основен масив - за сортиране */
            int[] b = new int[n]; /* Помощен масив */
            Generate(a);
            Console.WriteLine("Преди сортирането:");
            PrintArray(a);
            Console.WriteLine();
            MergeSort(a, b, 0, n - 1);
            Console.WriteLine("След сортирането:");
            PrintArray(a);
        }

        /* Генерира примерно множество */
        static void Generate(int[] array)
        {
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next() % (2 * n + 1);
        }

        /* Извежда списъка на екрана */
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < n; ++i)
                Console.Write("{0,4}", array[i]);
        }

        /* Сортиране */
        static void MergeSort(int[] a, int[] b, int left, int right)
        {
            if (right <= left) return;    /* Проверка дали има какво да се сортира */
            int mid = (right + left) / 2;
            MergeSort(a, b, left, mid);             /* Сортиране на левия дял */
            MergeSort(a, b, mid + 1, right);    /* Сортиране на десния дял */

            /* Копиране на елементите на a[] в помощния масив b[] */
            int i, j;
            for (i = mid + 1; i > left; i--)
                b[i - 1] = a[i - 1];           /* Права посока */
            for (j = mid; j < right; j++)
                b[right + mid - j] = a[j + 1]; /* Обратна посока */

            /* Сливане на двата масива в a[] */
            for (int k = left; k <= right; k++)
                a[k] = (b[i] < b[j]) ? b[i++] : b[j--];
        }
    }
}
