using System;

class Program
{
    const long NOT_SOLVED = -1;
    const int n = 10;
    const int k = 7;
    
    static long[] f = new long[n+1];   /* Целева функция */
    static long[] pow = new long[n+1]; /* Степените на k */
    
    static void Main()
    {
        Init();
        f[0] = 1; f[1] = k; f[2] = k * k - 1;
        Console.WriteLine("{0}", (k - 1) * solve(n - 1));
    }
    
    static void Init()
    {
        pow[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            pow[i] = k * pow[i - 1];
            f[i] = NOT_SOLVED;
        }
    }
    
    static long solve(int s)
    {
        if (f[s] == NOT_SOLVED)
        {
            f[s] = pow[s - 2];
            for (int i = 1; i < s - 1; i++)
                f[s] += solve(i - 1) * (k - 1) * pow[s - i - 2];
            f[s] = pow[s] - f[s];
        }
        return f[s];
    }
}
