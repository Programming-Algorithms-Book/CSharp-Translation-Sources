using System;

class Program
{
    const int LEFT = 1;
    const int UP = 2;
    const int UPLEFT = 3;
    
    static readonly int m = x.Length;    /* Дължина на първата редица */
    static readonly int n = y.Length;    /* Дължина на втората редица */
    static int[,] b = new int[m+1, n+1]; /* Указател към предходен елемент */
    static int[,] f = new int[m+1, n+1]; /* Целева функция */
    
    const string x = "acbcacbcaba";      /* Първа редица */
    const string y = "abacacacababa";    /* Втора редица */
    
    static void Main()
    {
        Console.WriteLine("Дължина на най-дългата обща подредица: {0}", LCS_Length());
        Console.Write("PrintLCS:  Максимална обща подредица (в обратен ред): ");
        PrintLCS();
        Console.WriteLine();
        Console.Write("PrintLCS2: Максимална обща подредица: ");
        PrintLCS2(x.Length, y.Length);
        Console.WriteLine();
        Console.Write("PrintLCS3: Максимална обща подредица: ");
        PrintLCS3(x.Length, y.Length);
    }
    
    /* Намира дължината на най-дългата обща подредица */
    static int LCS_Length()
    {
        /* Начална инициализация */
        for (int i = 1; i <= m; i++)
            f[i, 0] = 0;
        for (int j = 0; j <= n; j++)
            f[0, j] = 0;
        /* Основен цикъл */
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (x[i - 1] == y[j - 1])
                {
                    f[i, j] = f[i - 1, j - 1] + 1;
                    b[i, j] = UPLEFT;
                }
                else if (f[i - 1, j] >= f[i, j - 1])
                {
                    f[i, j] = f[i - 1, j];
                    b[i, j] = UP;
                }
                else {
                    f[i, j] = f[i, j - 1];
                    b[i, j] = LEFT;
                }
            }
        }
        return f[m, n];
    }
    
    /* Намира една възможна максимална обща подредица (обърната) */
    static void PrintLCS()
    {
        int i = x.Length;
        int j = y.Length;
        while (i > 0 && j > 0)
            switch (b[i, j])
            {
                case UPLEFT:  Console.Write(x[i - 1]); i--; j--; break;
                case UP:      i--; break;
                case LEFT:    j--; break;
            }
    }
    
    /* Намира една възможна максимална обща подредица */
    static void PrintLCS2(int i, int j)
    {
        if (i == 0 || j == 0)
            return;
        if (b[i, j] == UPLEFT)
        {
            PrintLCS2(i - 1, j - 1);
            Console.Write(x[i - 1]);
        }
        else if (b[i, j] == UP)
            PrintLCS2(i - 1, j);
        else
            PrintLCS2(i, j - 1);
    }
    
    /* Намира една възможна максимална обща подредица */
    static void PrintLCS3(int i, int j)
    {
        if (i == 0 || j == 0)
            return;
        if (x[i - 1] == y[j - 1])
        {
            PrintLCS3(i - 1, j - 1);
            Console.Write(x[i - 1]);
        }
        else if (f[i, j] == f[i - 1, j])
            PrintLCS3(i - 1, j);
        else
            PrintLCS3(i, j - 1);
    }
}
