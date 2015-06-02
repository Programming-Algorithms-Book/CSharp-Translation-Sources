using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryMerge
{
    struct Element
    {
        public int Key { get; set; }

        public Element(int key) : this()
        {
            this.Key = key;
        }

        /* ............. 
          Някакви данни 
        ............. */
    }

    class BinaryMerger
    {
        static Random rand = new Random();
        private const int N = 12;
        private const int M = 14;

        static void InitializeArray(Element[] array, int modul1, int modul2)
        {
            array[0].Key = rand.Next() % modul1;
            for (int i = 1; i < array.Length; i++)
                array[i].Key = array[i - 1].Key + (rand.Next() % modul2);
        }

        static int BinarySearch(Element[] elements, int left, int right, Element element)
        {
            do
            {
                int middle = (left + right) / 2;
                if (elements[middle].Key < element.Key)
                    left = middle + 1;
                else
                    right = middle - 1;
            } while (left <= right);
            return right;
        }

        static void BinaryMerge(Element[] a, Element[] b, Element[] c)
        {
            int n = a.Length;
            int m = b.Length;
            int power, elementsCount;
            int totalLength = a.Length + b.Length;
            int k;
            while (n > 0 && m > 0)
            {
                power = (int)(Math.Log(n / m) / Math.Log(2));
                elementsCount = 1 << power; /* elementsCount <-- 2^power */
                if (m <= n)
                {
                    if (b[m - 1].Key < a[n - elementsCount].Key)
                    {
                        /* Прехвърляне на a[n-t2-1],...,a[n] в изходната последователност */
                        totalLength -= elementsCount;
                        n = elementsCount;
                        for (int j = 0; j < elementsCount; j++)
                            c[totalLength + j] = a[n + j];
                    }
                    else
                    {
                        k = BinarySearch(a, n - elementsCount, n - 1, b[m - 1]);
                        for (int j = 0; j < n - k - 1; j++)
                            c[totalLength - n + k + j + 1] = a[k + j + 1];
                        totalLength -= n - k - 1;
                        n = k + 1;
                        c[--totalLength] = b[--m];
                    }
                }
                else
                {
                    if (a[n - 1].Key < b[m - elementsCount].Key)
                    {
                        totalLength -= elementsCount;
                        m -= elementsCount;
                        for (int j = 0; j < elementsCount; j++)
                        {
                            c[totalLength + j] = b[m + j];
                        }
                    }
                    else
                    {
                        k = BinarySearch(b, m - elementsCount, m - 1, a[n - 1]);
                        for (int j = 0; j < m - k - 1; j++)
                            c[totalLength - m + k + j + 1] = b[k + j + 1];
                        totalLength -= m - k - 1;
                        m = k + 1;
                        c[--totalLength] = a[--n];
                    }
                }
            }
            if (n == 0)
                for (int i = 0; i < m; i++)
                    c[i] = b[i];
            else
                for (int i = 0; i < n; i++)
                    c[i] = a[i];
        }

        static void PrintArrays(Element[] list) /* Извежда ключовете на масива на екрана */
        {
            foreach (var element in list)
                Console.Write("{0} ", element.Key);
            Console.WriteLine();
        }
        
        static void Check(Element[] elemets) /* Проверява за възходящ ред */
        {
            for (int i = 1; i < elemets.Length; i++)
                Debug.Assert(elemets[i - 1].Key <= elemets[i].Key);
        }

        static void Main()
        {
            Element[] a = new Element[N];
            Element[] b = new Element[M];
            Element[] c = new Element[N + M];
            InitializeArray(a, 200, 20);
            InitializeArray(b, 200, 20);
            Console.WriteLine("Преди сливането:");
            Console.WriteLine("Масивът A:");
            PrintArrays(a);
            Console.WriteLine("Масивът B:");
            PrintArrays(b);
            BinaryMerge(a, b, c);
            Console.WriteLine("След сливането C:");
            PrintArrays(c);
        }
    }
}
