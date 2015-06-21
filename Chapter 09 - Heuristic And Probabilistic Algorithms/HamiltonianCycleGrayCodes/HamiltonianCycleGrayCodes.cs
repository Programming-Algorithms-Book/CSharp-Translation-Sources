namespace HamiltonianCycleGrayCodes
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            /* код на Грей, Хамилтонов цикъл в n-мерен двоичен куб (Хиперкуб) */
            const int DIMENSIONS = 3;
            int[] a = new int[DIMENSIONS + 1];
            Forwgray(a, DIMENSIONS);
        }

        private static void Forwgray(int[] a, int k)
        {
            if (k == 0)
            {
                Print(a);
                return;
            }

            a[k] = 0;
            Forwgray(a, k - 1);
            a[k] = 1;
            Backgray(a, k - 1);
        }

        private static void Backgray(int[] a, int k)
        {
            if (k == 0)
            {
                Print(a);
                return;
            }

            a[k] = 1;
            Forwgray(a, k - 1);
            a[k] = 0;
            Backgray(a, k - 1);
        }

        private static void Print(int[] a)
        {
            Console.WriteLine(string.Join(" ", a.Skip(1)));
        }
    }
}