using System;

class coins_problem
{
    struct Element
    {
        public int Num { get; set; }
        public int Last { get; set; }
    }

    const int MaxCoins = 100;
    const int MaxSum = 1000;
    const int Sum = 31; /* Сума, чието представяне минимизираме */
    const int N = 14; /* Общ брой налични монети */

    static Element[] sums = new Element[MaxSum];
    static readonly int[] coins = new int[] /* Стойности на монетите */
        { 0, 5, 2, 2, 3, 2, 2, 2, 4, 3, 5, 8, 6, 7, 9 };

    /* Дали можем да използваме j-тата монета в i-тата сума? */
    static bool CanJ(int i, int j)
    {
        int k = i - coins[j];
        if (k > 0 && sums[k].Num < MaxCoins)
            while (k > 0)
            {
                if (sums[k].Last == j)
                    break; /* монета j участва в сумата */
                k -= coins[sums[k].Last];
            }

        return (k == 0);
    }

    /* Намира представяне на сумата Sum с минимален брой монети */
    static void FindMinSolution(int sum)
    {
        sums[0].Num = 0;
        for (int i = 1; i <= sum; i++)
        {
            sums[i].Num = MaxCoins;
            for (int j = 1; j <= N; j++)
            {
                if (CanJ(i, j))
                    if ((sums[i - coins[j]].Num + 1) < sums[i].Num)
                    {
                        sums[i].Num = 1 + sums[i - coins[j]].Num;
                        sums[i].Last = j;
                    }
            }
        }
    }

    /* Извежда намереното представяне */
    static void PrintSolution(int sum)
    {
        if (sums[sum].Num == MaxCoins)
            Console.WriteLine("Сумата не може да се получи с наличните монети.");
        else
        {
            Console.WriteLine("Минимален брой необходими монети: {0}", sums[sum].Num);
            Console.WriteLine("Ето и стойностите на самите монети: ");
            while (sum > 0)
            {
                Console.Write("{0} ", coins[sums[sum].Last]);
                sum -= coins[sums[sum].Last];
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        Console.WriteLine("Как да получим сума от {0} лева с минимален брой монети?", Sum);
        FindMinSolution(Sum);
        PrintSolution(Sum);
    }
}
