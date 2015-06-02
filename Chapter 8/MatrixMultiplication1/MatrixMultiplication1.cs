using System;

class Program
{
    
    
    static long[] r = new long[]{12, 13, 35, 3, 34, 2, 21, 10, 21, 6}; /* Размерности на матриците */
    static readonly int n = r.Length - 1;                              /* Брой матрици */
    static long[,] m = new long[n+1, n+1];                             /* Таблица - целева функция */
    
    static void Main()
    {
        Console.WriteLine("Минималният брой умножения е: {0}", SolveRecursive(1, n));
        PrintMatrix();
    }
    
    /* Неефективна рекурсивна функция */
    static long SolveRecursive(int i, int j)
    {
        if (i == j) return 0;
        m[i, j] = int.MaxValue;
        for (int k = i; k <= j - 1; k++)
        {
            long q = SolveRecursive(i, k) +
                SolveRecursive(k + 1, j) +
                r[i - 1] *
                r[k] *
                r[j];
            if (q < m[i, j])
                m[i, j] = q;
        }
    
        return m[i, j];
    }
    
    static void PrintMatrix() /* Извежда матрицата на минимумите на екрана */
    {
        Console.Write("Матрица на минимумите:");
        for (int i = 1; i <= n; i++)
        {
            Console.Write("\n");
            for (int j = 1; j <= n; j++)
                Console.Write("{0, 8}", m[i, j]);
        }
    }
}
