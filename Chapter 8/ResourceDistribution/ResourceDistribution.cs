using System;

class Program
{
    const int MAXPERCITY = 100;                          /* Максимално количество стока за град */
    const int MAXCITIES = 50;                            /* Максимален брой градове за търговия */
    const int MAXCARGO = 200;                            /* Максим. количество стока за разпределяне */
    
    static int[,] f = new int[MAXCITIES, MAXCARGO];      /* Целева функция */
    static int[,] amount = new int[MAXCITIES, MAXCARGO]; /* Оптимално количество стока */
    static int inc = 0;
    
    const int k = 3;               /* Брой градове за разпределяне на стоката */
    const int n = 5;               /* Количеството стока за разпределяне */
    const int M = 5;               /* Максим.количество за продаване в град */
    
    static int[,] v = new int[,] { /* Таблица на цените на стоките */
        { 0, 10, 15, 25, 40, 60 }, 
        { 0, 15, 20, 30, 45, 60 }, 
        { 0, 20, 30, 40, 50, 60 }
    };
    
    static void Main()
    {
        ScheduleCargo();
        PrintResults();
    }
    
    static int MaxIncome(int city, int ccargo)
    {
        int max = 0;
        if (0 == ccargo)
            return 0;                             /* Ако няма стока, няма и печалба ;) */
        else if (0 == city)
        {
            /* Ако колич.стока ccargo трябва да се разпредели само */
            /* за 1 град, се избира максим.печалба за този град от тази стока */
            for (int i = 0; i <= Math.Min(ccargo, M); i++)
                if (max < v[city, i])
                {
                    max = v[city, i];
                    amount[city, ccargo] = i;
                }
            f[city, ccargo] = max;
            return max;
        }
        else if (f[city, ccargo] != int.MaxValue) /* Ако функц. е вече изчислена, */
            return f[city, ccargo];                         /* се взема стойността й от таблицата */
        else {
            /* Взема се макс.цена, получена от колич. i стока в този град плюс */
            /* количеството останала стока ccargo-i в останалите градове */
            for (int i = 0; i <= Math.Min(ccargo, M); i++)
            {
                inc = v[city, i] + MaxIncome(city - 1, ccargo - i);
                if (max < inc)
                {
                    max = inc;
                    amount[city, ccargo] = i;
                }
            }
            f[city, ccargo] = max;
            return max;
        }
    }
    
    static void ScheduleCargo()
    {
        for (int i = 0; i <= k; i++)
            for (int j = 0; j <= n; j++)
            f[i, j] = int.MaxValue;
        f[k - 1, n] = MaxIncome(k - 1, n);
    }
    
    static void PrintResults()
    {
        int k = Program.k;
        int n = Program.n;
        k -= 1;
        Console.WriteLine("Максимален доход: {0}", f[k, n]);
        for(;;)
        {
            if (n == 0)
                Console.WriteLine("В град {0} продайте количество 0.", k+1);
            else 
            {
                Console.WriteLine("В град {0} продайте количество {1}.", k+1, amount[k, n]);
                n -= amount[k, n];
            }
            if (k-- == 0)
                break;
        }
        if (n > 0) Console.WriteLine("Остава стока: {0}", n);
    }
}
