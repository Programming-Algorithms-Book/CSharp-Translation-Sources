namespace ShakerSort
{
    using System;

    public class Program
    {
        private const int Max = 100;
        private const int TestLoopCnt = 100;

        internal static void Main(string[] args)
        {
            Element[] m = new Element[Max];
            Element[] saveM = new Element[Max];
            uint loopInd;
            Console.WriteLine("start -- ");
            for (loopInd = 1; loopInd <= TestLoopCnt; loopInd++)
            {
                Init(m, Max);
                m.CopyTo(saveM, 0); /* Запазва се копие на масива */
                Console.WriteLine("Масивът преди сортирането:");
                Print(m, Max);
                ShakerSort(m, Max);
                Console.WriteLine("Масивът след сортирането:");
                Print(m, Max);
                Check(m, saveM, Max);
            }
        }

        private static void Swap(ref Element x1, ref Element x2)
        {
            Element tmp = x1;
            x1 = x2;
            x2 = tmp;
        }

        private static void Init(Element[] m, uint n) /* Запълва масива със случайни цели числа */
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                m[i].Key = (int)(rand.Next() % n);
            }
        }

        private static void ShakerSort(Element[] m, uint n)
        {
            uint k = n, r = n - 1;
            uint l = 1;
            do
            {
                for (uint j = r; j >= l; j--)
                {
                    if (m[j - 1].Key > m[j].Key)
                    {
                        Swap(ref m[j - 1], ref m[j]);
                        k = j;
                    }
                }

                l = k + 1;
                for (uint j = l; j <= r; j++)
                {
                    if (m[j - 1].Key > m[j].Key)
                    {
                        Swap(ref m[j - 1], ref m[j]);
                        k = j;
                    }
                }

                r = k - 1;
            }
            while (l <= r);
        }

        private static void Print(Element[] m, uint n) /* Извежда ключовете на масива на екрана */
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,4}", m[i].Key);
            }

            Console.WriteLine();
        }

        private static void Check(Element[] m, Element[] saveM, uint n)
        {
            bool[] found = new bool[n + 1]; /* третира се като масив от булев тип */

            /* 1. Проверка за наредба във възходящ ред */
            for (int i = 0; i < n - 1; i++)
            {
                if (m[i].Key <= m[i + 1].Key == false)
                {
                    Environment.Exit(0);
                }
            }

            /* 2. Проверка за пермутация на изходните елементи */

            int j;

            for (int i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (found[j] == false && m[i].Key == saveM[j].Key)
                    {
                        found[j] = true;
                        break;
                    }
                }

                /* Пропада, ако не е намерен съответен */
                if (j < n == false)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}