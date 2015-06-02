using System;
using System.Linq;

class Program
{
    static readonly Random rand = new Random();
    
    /* трябва да бъде такова, че psize % 4 == 0 */
    const int PSIZE = 200;
    const int maxSteps = 1000;
    const int n = 20;     /* брой върхове на графа */
    const int MAXN = 100;
    
    static void Main()
    {
        int[,] population = new int[PSIZE, MAXN]; /* цикли на популацията */
        int[] result = new int[PSIZE];
    
        int[,] A = InitGraph(); /* матрица на теглата */
    
        /* Решение с генериране на произволни цикли */    
        for (int s = 0; s < maxSteps; s++)
        {
            for (int i = 0; i < PSIZE; i++)
            {
                RandomCycle(population, i);
                result[i] = Evaluate(A, population, i);
            }
        }
        Console.WriteLine("Оптимално решение, намерено при генериране на произволни {0} цикъла: {1}", 
            PSIZE*maxSteps, result.Min());
    
        /* Решение с Генетичен Алгоритъм със същия брой итерации */    
        for (int s = 0; s < maxSteps; s++) Reproduce(result, A, s, population);
        Console.WriteLine("Най-късите цикли, намерени от генетичния алгоритъм:");
        Console.WriteLine(string.Join(", ", result.Take(10)));
    }
    
    /* създаване на произволен граф */
    static int[,] InitGraph()
    {
        int[,] A = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++) A[i, j] = rand.Next(100) + 1;
        return A;
    }
    
    static int Evaluate(int[,] A, int[,] population, int t)
    {
        int res = 0;
        for (int i = 0; i < n - 1; i++)
            res += A[population[t, i], population[t, i + 1]];
        return res + A[population[t, n - 1], population[t, 0]];
    }
    
    static void RandomCycle(int[,] population, int t)
    {
        bool[] used = new bool[n];
        for (int i = 0; i < n; i++)
        {
            int p = rand.Next(n - i) + 1;
            int j = 0;
            while (p > 0)
            {
                while (used[j]) j++;
                p--; j++;
            }
            population[t, i] = j - 1;
            used[j - 1] = true;
        }
    }
    
    static void Combine(int[] result, int[,] A, int[,] population, int p1, int p2, int q1, int q2)
    {
        int[] uq1 = new int[n];
        int[] uq2 = new int[n];
        /* генерира наследници q1, q2 от родителите p1, p2 */
        int k = rand.Next(n - 1) + 1;    /* разменя в точката k */
        for (int i = 0; i < n; i++)
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
    
        for (int i = k; i < n; i++)
        {
            if (uq1[population[p2, i]] == 0)
            {
                population[q1, i] = population[p2, i];
                uq1[population[p2, i]]++;
            }
            else 
            {
                int j = 0;
                for (; uq1[j] != 0; j++);
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
                for (j = 0; uq2[j] != 0; j++);
                population[q2, i] = j;
                uq2[j]++;
            }
        }
    
        result[q1] = Evaluate(A, population, q1);
        result[q2] = Evaluate(A, population, q2);
    }
    
    static void Mutate(int[] result, int[,]A, int[,] population)
    {
        /* ако се получат две поредни еднакви решения - едното "мутира" */
        for (int i = 0; i < PSIZE - 1; i++)
        {
            bool flag = false;
            for (int k = 0; k < n; k++)
                if (population[i, k] != population[i + 1, k])
                {
                    flag = true;
                    break;
                }
    
            if (!flag)
            {
                /* цикъл i мутира */
                int p1 = rand.Next(n);
                int p2 = rand.Next(n);
                int swap = population[i, p1];
                population[i, p1] = population[i, p2];
                population[i, p2] = swap;
                result[i] = Evaluate(A, population, i);
            }
        }
    }
    
    static void Reproduce(int[] result, int[,] A, int s, int[,] population)
    {
        /* замества най-неоптималните цикли, като комбинира произволни Ј
         * от първата половина */
    
        for (int i = 0; i < (PSIZE-1)/2; i += 2)
        {
            /* randomCycle(i); */
            Combine(result, A, population, i, i+1, PSIZE-i-1, PSIZE-i-2);
            result[i] = Evaluate(A, population, i);
            
        }
    
        /* сортира популацията по оптималност */
        for (int i = 0; i < PSIZE - 1; i++)
        {
            for (int j = i + 1; j < PSIZE; j++)
            {
                if (result[j] < result[i])
                {
                    for (int k = 0; k < n; k++)
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
    
        if (s == maxSteps - 1) return;
    
        Mutate(result, A, population);
    }
}