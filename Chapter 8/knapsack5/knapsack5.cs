using System;

class knapsack5
{
    const int MaxN = 30;    /* Максимален брой предмети */
    const int MaxCapacity = 1000;  /* Максимална вместимост на раницата */
    const int TotalCapacity = 70;   /* Обща вместимост на раницата */
    const int N = 8;    /* Брой предмети */

    static int[] f = new int[MaxCapacity];     /* Целева функция */
    static int[] best = new int[MaxCapacity];  /* Последен добавен предмет при достигане на максимума */

    static readonly int[] weights = new int[] { 0, 30, 15, 50, 10, 20, 40, 5, 65 }; /* Тегло на предметите */
    static readonly int[] values = new int[] { 0, 5, 3, 9, 1, 2, 7, 1, 12 };       /* Стойност на предметите */

    static bool IsUsed(int i, int j)
    {
        /* Проверява дали j участва в оптималното множество, определено от f[i] */
        while (i != 0 && best[i] != 0)
            if (best[i] == j)
                return true;
            else
                i -= weights[best[i]];

        return false;
    }

    static void Calculate()
    {
        for (int i = 1; i <= TotalCapacity; i++)
            for (int j = 1; j <= N; j++)
                if (i >= weights[j])
                    if (f[i] < f[i - weights[j]] + values[j])
                        if (!IsUsed(i - weights[j], j))
                        {
                            f[i] = f[i - weights[j]] + values[j];
                            best[i] = j;
                        }
    }

    /* Извежда едно възможно множество от предмети, за което */
    /* се постига максимална стойност на целевата функция */
    static void PrintSet() 
    {               
        int value = TotalCapacity;
        while (value != 0)
        {
            Console.Write("{0} ", best[value]);
            value -= weights[best[value]];
        }

        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Брой предмети: {0}", N);
        Console.WriteLine("Максимална допустима обща маса: {0}", TotalCapacity);
        Calculate();
        Console.WriteLine("Максимална постигната ценност: {0}", f[TotalCapacity]);
        Console.Write("Вземете следните предмети: ");
        PrintSet();
    }
}
