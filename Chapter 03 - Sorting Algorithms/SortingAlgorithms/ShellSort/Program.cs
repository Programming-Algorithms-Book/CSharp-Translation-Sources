namespace ShellSort
{
    using System;

    public class Program
    {
        private const int Max = 100;
        private const int TestLoopCount = 100;

        private const int StepsCount = 4;
        private const int Steps0 = 40;

        private static readonly uint[] Steps = new uint[StepsCount] { Steps0, 13, 4, 1 };

        internal static void Main(string[] args)
        {
            Element[] pm = new Element[Max + Steps0 + 2];
            Element[] saveM = new Element[Max + 1];
            Element[] m = new Element[Max + 1];
            uint loopInd;

            // m = pm + steps0 + 1;
            Console.WriteLine("start -- ");
            for (loopInd = 1; loopInd <= TestLoopCount; loopInd++)
            {
                Init(m, Max);
                m.CopyTo(saveM, 0);
                Console.WriteLine("Масивът преди сортирането:");
                Print(m, Max);
                ShellSort(m, Max);
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

        private static void ShellSort(Element[] m, uint n)
        {
            for (uint stepInd = 0; stepInd < StepsCount; stepInd++)
            {
                int k;
                int s = (k = (int)Steps[stepInd]);
                for (int i = k + 1; i <= (int)n; i++)
                {
                    Element x = m[i];
                    int j = i - k;
                    if (0 == s)
                    {
                        s = -k;
                    }

                    m[++s] = x;
                    while (x.Key < m[j].Key)
                    {
                        m[j + k] = m[j];
                        j -= k;
                    }

                    m[j + k] = x;
                }
            }
        }

        private static void Print(Element[] m, uint n) /* Извежда ключовете на масива на екрана */
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write("{0,8}", m[i].Key);
            }
        }

        private static void Check(Element[] m, Element[] saveM, uint n)
        {
            bool[] found = new bool[n + 1]; /* третира се като масив от булев тип */

            /* 1. Проверка за наредба във възходящ ред */
            for (int i = 1; i < n; i++)
            {
                if (m[i].Key <= m[i + 1].Key == false)
                {
                    Environment.Exit(0);
                }
            }

            /* 2. Проверка за пермутация на изходните елементи */

            for (int i = 1; i <= n; i++)
            {
                uint j;
                for (j = 1; j <= n; j++)
                {
                    if (found[j] == false && m[i].Key == saveM[j].Key)
                    {
                        found[j] = true;
                        break;
                    }
                }

                if (j <= n == false)
                {
                    /* Пропада, ако не е намерен съответен */
                    Environment.Exit(0);
                }
            }
        }
    }
}