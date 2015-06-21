namespace Board
{
    using System;

    public class Board
    {
        private const int Max = 100;
        private const int N = 9; /* Брой накрайници */

        private static readonly int[] F = new int[Max]; /* Целева функция */
        private static readonly int[] NextConductor = new int[Max];
        private static readonly int[] Permutation = new int[] { 0, 9, 1, 3, 6, 2, 7, 5, 4, 8 }; /* Изх. пермутация */

        internal static void Main()
        {
            Solve();
            Print();
        }

        private static void Solve()
        {
            /* Инициализиране */
            for (int i = 1; i <= N; i++)
            {
                F[i] = 1;
            }

            /* Основен цикъл */
            for (int k = N; k >= 1; k--)
            {
                for (int i = k + 1; i <= N; i++)
                {
                    if (Permutation[k] < Permutation[i])
                    {
                        if (1 + F[i] > F[k])
                        {
                            F[k] = 1 + F[i];
                            NextConductor[k] = i;
                        }
                    }
                }
            }
        }

        private static void Print()
        {
            int i, max, index = 1;
            for (max = F[index], i = 2; i <= N; i++)
            {
                if (F[i] > max)
                {
                    max = F[i];
                    index = i;
                }
            }

            Console.WriteLine("Максимален брой кабели: {0}", max);
            do
            {
                Console.Write("{0} ", index);
                index = NextConductor[index];
            }
            while (index != 0);

            Console.WriteLine();
        }
    }
}