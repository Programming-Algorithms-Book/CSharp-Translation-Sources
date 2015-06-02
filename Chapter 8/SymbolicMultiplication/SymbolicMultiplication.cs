using System;

class Program
{
    static readonly bool? NOT_CALCULATED = null;
    const int LETTS = 3;     /* Брой букви */
    
    /* Таблица на умножение */
    static char[,] rel = {
        { 'b', 'b', 'a' }, 
        { 'c', 'b', 'a' }, 
        { 'a', 'c', 'c' } 
    };
    
    const string s = "bacacbcabbbcacab";
    
    static bool?[,,] table = new bool?[s.Length, s.Length, LETTS];
    static int[,] split = new int[s.Length, s.Length];
    
    static void Main()
    {
        int len = s.Length;
        
        if (Can(0, len - 1, 0))
            PutBrackets(0, len - 1);
        else
            Console.Write("Няма решение");
    }
    
    static bool Can(int i, int j, int ch)
    {
        int c1, c2, pos;
        if (table[i, j, ch] != NOT_CALCULATED)
            return table[i, j, ch].Value; /* Вече сметнато */
        if (i == j)
            return s[i] == (ch + 'a');
        for (c1 = 0; c1 < LETTS; c1++)
            for (c2 = 0; c2 < LETTS; c2++)
                if (rel[c1, c2] == ch + 'a')
                    for (pos = i; pos <= j - 1; pos++)
                        if (Can(i, pos, c1))
                            if (Can(pos + 1, j, c2))
                            {
                                table[i, j, ch] = true;
                                split[i, j] = pos;
                                return true;
                            }
        table[i, j, ch] = false;
        return false;
    }
    
    static void PutBrackets(int i, int j)
    {
        /* Поставя скобите с израза */
        if (i == j)
            Console.Write(s[i]);
        else 
        {
            Console.Write("(");
            PutBrackets(i, split[i, j]);
            Console.Write("*");
            PutBrackets(split[i, j] + 1, j);
            Console.Write(")");
        }
    }
}