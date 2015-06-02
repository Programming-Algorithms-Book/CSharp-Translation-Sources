using System;

namespace Translations._2.brothers
{
    class alanbob2
    {
        const int MaxObjects = 100; /* Максимален брой предмети */
        const int MaxValue = 200; /* Максимална стойност на отделен предмет */
        const int NotSet = -1;
        const int N = 10; /* Общ брой на предметите за поделяне */

        static int[] lastAdded = new int[MaxObjects * MaxValue]; /* Кой предмет е бил добавен последен? */
        static readonly int[] objectValues = new int[] { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };

        static void Solve()
        {
            int totalSum; /* Обща стойност на предметите за поделяне */
            int currSum = 0;
            int i, j;

            /* Пресмятаме totalSum */
            for (totalSum = i = 0; i < N; totalSum += objectValues[i++]);

            /* Начално инициализиране */
            for (lastAdded[0] = 0, i = 1; i <= totalSum; i++)
                lastAdded[i] = NotSet;

            /* Намиране на всевъзможните суми от стойности на подаръците */
            for (i = 0; i < N; i++)
            {
                for (j = totalSum; j + 1 > 0; j--)
                    if (NotSet != lastAdded[j] && NotSet == lastAdded[j + objectValues[i]])
                        lastAdded[j + objectValues[i]] = i;
                currSum += objectValues[i];
            }

            /* Търсим на най-близка до totalSum/2 стойност и извеждане на решение */
            for (i = totalSum / 2; i > 1; i--)
            {
                if (lastAdded[i] != NotSet)
                {
                    Console.WriteLine("Сума за Алан: {0}, сума за Боб: {1}", i, totalSum - i);
                    Console.WriteLine("Алан взема:");
                    while (i > 0)
                    {
                        Console.Write("{0} ", objectValues[lastAdded[i]]);
                        i -= objectValues[lastAdded[i]];
                    }
                    Console.WriteLine("\nБоб взема останалите подаръци.");
                    return;
                }
            }
        }

        static void Main()
        {
            Solve();
        }
    }
}
