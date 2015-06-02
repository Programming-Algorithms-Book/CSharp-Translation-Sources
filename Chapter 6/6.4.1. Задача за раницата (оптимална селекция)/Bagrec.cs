using System;

class Program
{
    const int MAXN = 100;
    const uint n = 10;
    const float M = 10.5F;
    //was float
    static double[] c = new double[] { 10.3, 9.0, 12.0, 8.0, 4.0, 8.4, 9.1, 17.0, 6.0, 9.7 };
    static double[] m = new double[] { 4.0, 2.6, 3.0, 5.3, 6.4, 2.0, 4.0, 5.1, 3.0, 4.0 };
    static uint[] taken = new uint[MAXN],
    saveTaken = new uint[MAXN];
    static uint tn, sn;
    static float VmaX, Vtemp, Ttemp, totalV;

    static void generate(uint i)
    {
        uint k;
        if (Ttemp > M)
            return;
        if (Vtemp + totalV < VmaX)
            return;
        if (i == n)
        {
            if (Vtemp > VmaX)
            { /* запазване на оптималното решение */
                VmaX = Vtemp;
                sn = tn;
                for (k = 0; k < tn; k++)
                    saveTaken[k] = taken[k];
            }
            return;
        }
        taken[tn++] = i;
        Vtemp += c[i];
        totalV -= c[i];
        Ttemp += m[i];
        generate(i + 1);
        tn--;
        Vtemp -= c[i];
        Ttemp -= m[i];
        generate(i + 1);
        totalV += c[i];
    }

    static void Main(string[] args)
    {
        uint i;
        tn = 0;
        VmaX = 0;
        totalV = 0;
        for (i = 0; i < n; i++)
            totalV += c[i];
        generate(0);
        Console.WriteLine("Максимално тегло: {0:F2}\nИзбрани предмети: ", VmaX);
        for (i = 0; i < sn; i++)
            Console.Write("{0} ", saveTaken[i] + 1);
        Console.WriteLine();
    }
}