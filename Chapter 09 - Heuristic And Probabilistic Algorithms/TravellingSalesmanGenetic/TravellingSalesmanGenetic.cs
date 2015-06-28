namespace TravellingSalesmanGenetic
{
    using System;
    using System.Linq;

    public class Program
    {
        /* трябва да бъде такова, че psize % 4 == 0 */
        private const int SizeP = 200;
        private const int MaxSteps = 1000;
        private const int N = 20; /* брой върхове на графа */
        private const int MaxN = 100;

        private static readonly Random Rand = new Random();

        internal static void Main()
        {
            int[,] population = new int[SizeP, MaxN]; /* цикли на популацията */
            int[] result = new int[SizeP];

            int[,] a = InitGraph(); /* матрица на теглата */

            /* Решение с генериране на произволни цикли */
            for (int s = 0; s < MaxSteps; s++)
            {
                for (int i = 0; i < SizeP; i++)
                {
                    RandomCycle(population, i);
                    result[i] = Evaluate(a, population, i);
                }
            }

            Console.WriteLine(
                "Оптимално решение, намерено при генериране на произволни {0} цикъла: {1}",
                SizeP * MaxSteps,
                result.Min());

            /* Решение с Генетичен Алгоритъм със същия брой итерации */
            for (int s = 0; s < MaxSteps; s++)
            {
                Reproduce(result, a, s, population);
            }

            Console.WriteLine("Най-късите цикли, намерени от генетичния алгоритъм:");
            Console.WriteLine(string.Join(", ", result.Take(10)));
        }

        /* създаване на произволен граф */

        private static int[,] InitGraph()
        {
            int[,] a = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    a[i, j] = Rand.Next(100) + 1;
                }
            }

            return a;
        }

        private static int Evaluate(int[,] a, int[,] population, int t)
        {
            int res = 0;
            for (int i = 0; i < N - 1; i++)
            {
                res += a[population[t, i], population[t, i + 1]];
            }

            return res + a[population[t, N - 1], population[t, 0]];
        }

        private static void RandomCycle(int[,] population, int t)
        {
            bool[] used = new bool[N];
            for (int i = 0; i < N; i++)
            {
                int p = Rand.Next(N - i) + 1;
                int j = 0;
                while (p > 0)
                {
                    while (used[j])
                    {
                        j++;
                    }

                    p--;
                    j++;
                }

                population[t, i] = j - 1;
                used[j - 1] = true;
            }
        }

        private static void Combine(
            int[] result,
            int[,] a,
            int[,] population,
            int p1,
            int p2,
            int q1,
            int q2)
        {
            int[] uq1 = new int[N];
            int[] uq2 = new int[N];
            /* генерира наследници q1, q2 от родителите p1, p2 */
            int k = Rand.Next(N - 1) + 1; /* разменя в точката k */
            for (int i = 0; i < N; i++)
            {
                uq1[i] = 0;
                uq2[i] = 0;
            }

            for (int i = 0; i < k; i++)
            {
                population[q1, i] = population[p1, i];
                uq1[population[p1, i]]++;
                population[q2, i] = population[p2, i];
                uq2[population[p2, i]]++;
            }

            for (int i = k; i < N; i++)
            {
                if (uq1[population[p2, i]] == 0)
                {
                    population[q1, i] = population[p2, i];
                    uq1[population[p2, i]]++;
                }
                else
                {
                    int j = 0;
                    for (; uq1[j] != 0; j++)
                    {
                    }

                    population[q1, i] = j;
                    uq1[j]++;
                }

                if (uq2[population[p1, i]] == 0)
                {
                    population[q2, i] = population[p1, i];
                    uq2[population[p1, i]]++;
                }
                else
                {
                    int j = 0;
                    for (j = 0; uq2[j] != 0; j++)
                    {
                    }

                    population[q2, i] = j;
                    uq2[j]++;
                }
            }

            result[q1] = Evaluate(a, population, q1);
            result[q2] = Evaluate(a, population, q2);
        }

        private static void Mutate(int[] result, int[,] a, int[,] population)
        {
            /* ако се получат две поредни еднакви решения - едното "мутира" */
            for (int i = 0; i < SizeP - 1; i++)
            {
                bool flag = false;
                for (int k = 0; k < N; k++)
                {
                    if (population[i, k] != population[i + 1, k])
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    /* цикъл i мутира */
                    int p1 = Rand.Next(N);
                    int p2 = Rand.Next(N);
                    int swap = population[i, p1];
                    population[i, p1] = population[i, p2];
                    population[i, p2] = swap;
                    result[i] = Evaluate(a, population, i);
                }
            }
        }

        private static void Reproduce(int[] result, int[,] a, int s, int[,] population)
        {
            /* замества най-неоптималните цикли, като комбинира произволни Ј
         * от първата половина */

            for (int i = 0; i < (SizeP - 1) / 2; i += 2)
            {
                /* randomCycle(i); */
                Combine(result, a, population, i, i + 1, SizeP - i - 1, SizeP - i - 2);
                result[i] = Evaluate(a, population, i);
            }

            /* сортира популацията по оптималност */
            for (int i = 0; i < SizeP - 1; i++)
            {
                for (int j = i + 1; j < SizeP; j++)
                {
                    if (result[j] < result[i])
                    {
                        for (int k = 0; k < N; k++)
                        {
                            int swap = population[i, k];
                            population[i, k] = population[j, k];
                            population[j, k] = swap;
                        }

                        {
                            int swap = result[i];
                            result[i] = result[j];
                            result[j] = swap;
                        }
                    }
                }
            }

            if (s == MaxSteps - 1)
            {
                return;
            }

            Mutate(result, a, population);
        }
    }
}