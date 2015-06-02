using System;

class Program
{
    const int COST_DELETE = 1;
    const int COST_INSERT = 2;
    
    static string s1 = "_abracadabra";    /* Изходен низ (първият символ няма значение) */
    static string s2 = "_mabragabra";     /* Низ-цел (първият символ няма значение) */
    static int n1 = s1.Length - 1;        /* Дължина на първия низ */
    static int n2 = s2.Length - 1;        /* Дължина на втория низ */
    
    static int[,] f = new int[n1+1, n2+1];     /* Целева функция */
        
    static void Main()
    { 
        Console.WriteLine("Минимално разстояние между двата низа: {0}", EditDistance());
        PrintEditOperations(n1, n2);
    }
    
    static int ReplaceOrMatch(char c1, char c2)
    {
        return (c1 == c2) ? 0 : 3;
    }
    
    /* Намира разстоянието между два низа */
    static int EditDistance()
    {
        /* Инициализация */
        for (int i = 0; i <= n1; i++)
            f[i, 0] = i * COST_DELETE;
        for (int j = 0; j <= n2; j++)
            f[0, j] = j * COST_INSERT;
        /* Основен цикъл */
        for (int i = 1; i <= n1; i++)
            for (int j = 1; j <= n2; j++)
                f[i, j] = Math.Min(f[i - 1, j - 1] + ReplaceOrMatch(s1[i], s2[j]), 
                          Math.Min(f[i, j - 1] + COST_INSERT, 
                                   f[i - 1, j] + COST_DELETE));
        return f[n1, n2];
    }
    
    /* Извежда операциите по редактирането */
    static void PrintEditOperations(int i, int j)
    {
        if (j == 0)
            for (j = 1; j <= i; j++)
                Console.Write("DELETE({0}) ", j);
        else if (i == 0)
            for (i = 1; i <= j; i++)
                Console.Write("INSERT({0}, {1}) ", i, s2[i]);
        else if (i > 0 && j > 0)
        {
            if (f[i, j] == f[i - 1, j - 1] + ReplaceOrMatch(s1[i], s2[j]))
            {
                PrintEditOperations(i - 1, j - 1);
                if (ReplaceOrMatch(s1[i], s2[j]) > 0)
                    Console.Write("REPLACE({0}, {1}) ", i, s2[j]);
            }
            else if (f[i, j] == f[i, j - 1] + COST_INSERT)
            {
                PrintEditOperations(i, j - 1);
                Console.Write("INSERT({0}, {1}) ", i, s2[j]);
            }
            else if (f[i, j] == f[i - 1, j] + COST_DELETE)
            {
                PrintEditOperations(i - 1, j);
                    Console.Write("DELETE({0}) ", i);
            }
        }
    }
}
