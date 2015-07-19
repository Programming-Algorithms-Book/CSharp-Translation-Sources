namespace ShellSort2
{
    using System;
    using System.Text;

    public class Program
    {
        private const int Max = 100;
        private const int TestLoopCount = 100;

        internal static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Element[] m = new Element[Max + 1];
            Element[] saveM = new Element[Max + 1];
            uint loopInd;
            Console.WriteLine("start -- ");
            for (loopInd = 1; loopInd <= TestLoopCount; loopInd++)
            {
                Init(m, Max);
                m.CopyTo(saveM, 0);
                Console.WriteLine("Масивът преди сортирането:");
                Print(m, Max);
                ShellSort(m, 1, Max);
                Console.WriteLine("Масивът след сортирането:");
                Print(m, Max);
                Check(m, saveM, Max);
            }
        }

        private static void Init(Element[] m, uint n) /* Запълва масива със случайни цели числа */
        {
            uint i;
            Random rand = new Random();
            for (i = 1; i <= n; i++)
            {
                m[i].Key = (int)(rand.Next() % n);
            }
        }

        private static void ShellSort(Element[] m, uint l, uint r)
        {
            uint[] incs =
            {
                1391376, 463792, 198768, 86961, 33936,
                13776, 4592, 1968, 861, 336, 112, 48,
                21, 7, 3, 1
            };

            for (int k = 0; k < 16; k++)
            {
                for (uint h = incs[k], i = l + h; i <= r; i++)
                {
                    var v = m[i];
                    uint j = i;
                    while (j > h && m[j - h].Key > v.Key)
                    {
                        m[j] = m[j - h];
                        j -= h;
                    }

                    m[j] = v;
                }
            }
        }

        private static void Print(Element[] m, uint n) /* Извежда ключовете на масива на екрана */
        {
            uint i;
            for (i = 1; i <= n; i++)
            {
                Console.Write("{0}, ", m[i].Key);
            }

            Console.WriteLine();
        }

        private static void Check(Element[] m, Element[] saveM, uint n)
        {
            uint j;
            bool[] found = new bool[n + 1]; /* третира се като масив от булев тип */
            /* 1. Проверка за наредба във възходящ ред */
            for (int i = 1; i < n; i++)
            {
                if (m[i].Key > m[i + 1].Key)
                {
                    Environment.Exit(0);
                }
            }

            /* 2. Проверка за пермутация на изходните елементи */
            for (int i = 1; i <= n; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    if (found[j] == false && m[i].Key == saveM[j].Key)
                    {
                        found[j] = true;
                        break;
                    }
                }

                if (j > n)
                {
                    Environment.Exit(0); /* Пропада, ако не е намерен съответен */
                }
            }
        }
    }
}