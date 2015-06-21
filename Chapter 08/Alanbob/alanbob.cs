namespace Alanbob
{
    using System;

    public class Alanbob
    {
        private const int MaxObjects = 100; /* Максимален брой предмети */
        private const int MaxValue = 200; /* Максимална стойност на отделен предмет */
        private const int N = 10; /* Общ брой на предметите за поделяне */

        private static readonly bool[] Possible = new bool[MaxObjects * MaxValue]; /* Може ли да се получи сумата? */
        private static readonly int[] ObjectValues = new int[] { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };

        internal static void Main()
        {
            Solve();
        }

        private static void Solve()
        {
            int totalSum; /* Обща стойност на предметите за поделяне */
            int i, j;

            /* Пресмятаме totalSum */
            for (totalSum = i = 0; i < N; totalSum += ObjectValues[i++])
            {
            }

            Possible[0] = true;

            /* Намиране на всевъзможните суми от стойности на подаръците */
            for (i = 0; i < N; i++)
            {
                for (j = totalSum; j + 1 > 0; j--)
                {
                    if (Possible[j])
                    {
                        Possible[j + ObjectValues[i]] = true;
                    }
                }
            }

            /* Намиране на най-близката до p/2 стойност */
            for (i = totalSum / 2; i > 1; i--)
            {
                if (Possible[i])
                {
                    Console.WriteLine("сума за Алан: {0}, сума за Боб: {1}", i, totalSum - i);
                    return;
                }
            }
        }
    }
}