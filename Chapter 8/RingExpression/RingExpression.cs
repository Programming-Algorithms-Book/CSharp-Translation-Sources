using System;

class Program
{
    struct Goal 
    {
        
        public long Min { get; set; } 
        public long Max { get; set; } 
        public int LenMin { get; set; }
        public int LenMax { get; set; }
    } 
    
    
    static long[] x = new long[] { 0, 9, -3, 8, 7, -8, 0, 7 }; /* Стойности на числата (без първото) */
    static char[] sign = new char[]{ ' ', '+', '*', '*', '-', '+', '*', '-' }; /* Знаци между тях */
    static readonly int n = x.Length - 1;                      /* Брой числа */
    static Goal[,] f = new Goal[n+1, n+1];    /* Целеви функции Fmin() и Fmax() */
    
    static void Main()
    {
        Solve();
        Print();
    }
    
    /* Намира максимума и минимума, както и как се получават */
    static void Solve()
    {
        /* Инициализация */
        sign[0] = sign[n];
        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                f[i, j].Min = int.MaxValue;
        /* Пресмятане на стойностите на целевата функция */
        for (int i = 1; i <= n; i++)
         Calculate(i, n);
    }
    
    /* Пресмята стойностите на целевата функция */
    static void Calculate(int beg, int len)
    {
        int beg2;
        long val1, val2, val3, val4, minValue, maxValue;
        if (beg > n)
        beg -= n;
        if (f[beg, len].Min != int.MaxValue) /* Стойността вече е била сметната */
        return;
        if (len == 1)
        {
            f[beg, len].Min = f[beg, len].Max = x[beg];
            f[beg, len].LenMin = f[beg, len].LenMax = 0;
            return;
        }
        /* Стойността трябва да се пресметне */
        f[beg, len].Min = int.MaxValue;
        f[beg, len].Max = -int.MaxValue;
        for (int i = 1; i < len; i++)
        {
            /* Пресмятане на всички стойности f[beg, i] и f[beg+i, len-i] */
            Calculate(beg, i);
            if (beg + i > n)
                beg2 = beg + i - n;
            else
                beg2 = beg + i;
            Calculate(beg2, len - i);
            val1 = Oper(f[beg, i].Min, sign[beg2 - 1], f[beg2, len - i].Min);
            val2 = Oper(f[beg, i].Min, sign[beg2 - 1], f[beg2, len - i].Max);
            val3 = Oper(f[beg, i].Max, sign[beg2 - 1], f[beg2, len - i].Min);
            val4 = Oper(f[beg, i].Max, sign[beg2 - 1], f[beg2, len - i].Max);
            /* Актуализиране на минималната стойност на f[beg, len] */
            minValue = Math.Min(val1, Math.Min(val2, Math.Min(val3, val4)));
            if (minValue < f[beg, len].Min)
            {
                f[beg, len].Min = minValue;
                f[beg, len].LenMin = i;
            }
            /* Актуализиране на максималната стойност на f[beg, len] */
            maxValue = Math.Max(val1, Math.Max(val2, Math.Max(val3, val4)));
            if (maxValue > f[beg, len].Max)
            {
                f[beg, len].Max = maxValue;
                f[beg, len].LenMax = i;
            }
        }
    }
    
    /* Извършва операцията */
    static long Oper(long v1, char sign, long v2)
    {
        switch (sign)
        {
            case '+': return v1 + v2;
            case '-': return v1 - v2;
            case '*': return v1 * v2;
        }
        return 0;
    }
    
    /* Търси и извежда максимума и минимума */
    static void Print()
    {
        int i, minIndex, maxIndex;
        for (minIndex = 1, i = 2; i <= n; i++)
            if (f[i, n].Min < f[minIndex, n].Min)
             minIndex = i;
        for (maxIndex = 1, i = 2; i <= n; i++)
            if (f[i, n].Max > f[maxIndex, n].Max)
             maxIndex = i;
        Console.WriteLine("Минимална стойност: {0}", f[minIndex, n].Min);
        PrintMinMax(minIndex, n, true);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Максимална стойност: {0}", f[maxIndex, n].Max);
        PrintMinMax(maxIndex, n, false);
    }
        
    /* Извежда израз, за който се получава min/max */
    static void PrintMinMax(int beg, int len, bool printMin)
    {
        int i, beg2;
        if (beg > n)
            beg -= n;
        if (1 == len)
            Console.Write(x[beg]);
        else {
            if (len < n)
                Console.Write("(");
            i = printMin ? f[beg, len].LenMin : f[beg, len].LenMax;
            if ((beg2 = beg + i) > n)
                beg2 -= n;
            PrintMinMax(beg, i, printMin); /* Рекурсия за лявата част на израза */
            Console.Write(sign[beg2 - 1]); /* Извеждане на операцията */
            PrintMinMax(beg2, len - i, printMin); /* Рекурсия за дясната част на израза */
            if (len < n)
                Console.Write(")");
        }
    }
}