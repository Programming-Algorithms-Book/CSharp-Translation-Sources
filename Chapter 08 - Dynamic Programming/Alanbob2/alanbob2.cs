namespace Alanbob2
{
    using System;

    public class Alanbob2
    {
        private const int MaxObjects = 100; /* Максимален брой предмети */
        private const int MaxValue = 200; /* Максимална стойност на отделен предмет */
        private const int NotSet = -1;
        private const int N = 10; /* Общ брой на предметите за поделяне */

        private static readonly int[] LastAdded = new int[MaxObjects * MaxValue]; /* Кой предмет е бил добавен последен? */
        private static readonly int[] ObjectValues = new int[] { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };

        internal static void Main()
        {
            Solve();
        }

        private static void Solve()
        {
            int totalSum; /* Обща стойност на предметите за поделяне */
            int currSum = 0;
            int i, j;

            /* Пресмятаме totalSum */
            for (totalSum = i = 0; i < N; totalSum += ObjectValues[i++])
            {
            }

            /* Начално инициализиране */
            for (LastAdded[0] = 0, i = 1; i <= totalSum; i++)
            {
                LastAdded[i] = NotSet;
            }

            /* Намиране на всевъзможните суми от стойности на подаръците */
            for (i = 0; i < N; i++)
            {
                for (j = totalSum; j + 1 > 0; j--)
                {
                    if (NotSet != LastAdded[j] && NotSet == LastAdded[j + ObjectValues[i]])
                    {
                        LastAdded[j + ObjectValues[i]] = i;
                    }
                }

                currSum += ObjectValues[i];
            }

            /* Търсим на най-близка до totalSum/2 стойност и извеждане на решение */
            for (i = totalSum / 2; i > 1; i--)
            {
                if (LastAdded[i] != NotSet)
                {
                    Console.WriteLine("Сума за Алан: {0}, сума за Боб: {1}", i, totalSum - i);
                    Console.WriteLine("Алан взема:");
                    while (i > 0)
                    {
                        Console.Write("{0} ", ObjectValues[LastAdded[i]]);
                        i -= ObjectValues[LastAdded[i]];
                    }

                    Console.WriteLine("\nБоб взема останалите подаръци.");
                    return;
                }
            }
        }
    }
}