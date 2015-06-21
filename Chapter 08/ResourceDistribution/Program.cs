namespace ResourceDistribution
{
    using System;

    public class Program
    {
        private const int MaxPercity = 100; /* Максимално количество стока за град */
        private const int MaxCities = 50; /* Максимален брой градове за търговия */
        private const int MaxCargo = 200; /* Максим. количество стока за разпределяне */

        private const int K = 3; /* Брой градове за разпределяне на стоката */
        private const int N = 5; /* Количеството стока за разпределяне */
        private const int M = 5; /* Максим.количество за продаване в град */

        private static readonly int[,] F = new int[MaxCities, MaxCargo]; /* Целева функция */
        private static readonly int[,] Amount = new int[MaxCities, MaxCargo]; /* Оптимално количество стока */
        private static readonly int[,] V = new int[,]
        {
            /* Таблица на цените на стоките */
            { 0, 10, 15, 25, 40, 60 },
            { 0, 15, 20, 30, 45, 60 },
            { 0, 20, 30, 40, 50, 60 }
        };

        private static int inc = 0;

        internal static void Main()
        {
            ScheduleCargo();
            PrintResults();
        }

        private static int MaxIncome(int city, int ccargo)
        {
            int max = 0;
            if (0 == ccargo)
            {
                return 0; /* Ако няма стока, няма и печалба ;) */
            }
            else if (0 == city)
            {
                /* Ако колич.стока ccargo трябва да се разпредели само */
                /* за 1 град, се избира максим.печалба за този град от тази стока */
                for (int i = 0; i <= Math.Min(ccargo, M); i++)
                {
                    if (max < V[city, i])
                    {
                        max = V[city, i];
                        Amount[city, ccargo] = i;
                    }
                }

                F[city, ccargo] = max;
                return max;
            }
            else if (F[city, ccargo] != int.MaxValue)
            {
                /* Ако функц. е вече изчислена, */
                return F[city, ccargo]; /* се взема стойността й от таблицата */
            }
            else
            {
                /* Взема се макс.цена, получена от колич. i стока в този град плюс */
                /* количеството останала стока ccargo-i в останалите градове */
                for (int i = 0; i <= Math.Min(ccargo, M); i++)
                {
                    inc = V[city, i] + MaxIncome(city - 1, ccargo - i);
                    if (max < inc)
                    {
                        max = inc;
                        Amount[city, ccargo] = i;
                    }
                }

                F[city, ccargo] = max;
                return max;
            }
        }

        private static void ScheduleCargo()
        {
            for (int i = 0; i <= K; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    F[i, j] = int.MaxValue;
                }
            }

            F[K - 1, N] = MaxIncome(K - 1, N);
        }

        private static void PrintResults()
        {
            int k = Program.K;
            int n = Program.N;
            k -= 1;
            Console.WriteLine("Максимален доход: {0}", F[k, n]);
            for (;;)
            {
                if (n == 0)
                {
                    Console.WriteLine("В град {0} продайте количество 0.", k + 1);
                }
                else
                {
                    Console.WriteLine("В град {0} продайте количество {1}.", k + 1, Amount[k, n]);
                    n -= Amount[k, n];
                }

                if (k-- == 0)
                {
                    break;
                }
            }

            if (n > 0)
            {
                Console.WriteLine("Остава стока: {0}", n);
            }
        }
    }
}